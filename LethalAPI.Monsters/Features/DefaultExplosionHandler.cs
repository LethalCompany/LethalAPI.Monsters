// -----------------------------------------------------------------------
// <copyright file="DefaultExplosionHandler.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Features;

using System;
using System.Collections.Generic;

using Components;
using Interfaces;
using UnityEngine;

/// <summary>
/// The default handler for LethalAPI explosions.
/// </summary>
public class DefaultExplosionHandler : IExplosionHandler
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultExplosionHandler"/> class.
    /// </summary>
    /// <param name="killDistance">The distance to deal lethal player damage.</param>
    /// <param name="curve">The damage curve for calculating damage to deal damage.</param>
    /// <param name="animation">The explosion animation to use.</param>
    /// <param name="playShake">Indicates whether or not to play the basegame shake animation for players close enough to experience the explosion.</param>
    public DefaultExplosionHandler(float killDistance = 1, AnimationCurve? curve = null, IExplosionAnimation? animation = null, bool playShake = true)
    {
        this.Distance = killDistance;
        this.DamageCurve = curve ?? new(new Keyframe(0, 100), new Keyframe(100, 100));
        this.Animation = animation ?? DefaultExplosionAnimation.Instance;
        this.PlayShake = playShake;
    }

    /// <summary>
    /// Gets the primary instance for the handler.
    /// </summary>
    public static DefaultExplosionHandler Default => new(6);

    /// <summary>
    /// Gets or sets the distance that the explosion can deal damage.
    /// </summary>
    public float Distance { get; set; }

    /// <summary>
    /// Gets the damage curve to apply to the explosion.
    /// </summary>
    public AnimationCurve DamageCurve { get; }

    /// <summary>
    /// Gets the explosion animation handler.
    /// </summary>
    public IExplosionAnimation Animation { get; }

    /// <summary>
    /// Gets a value indicating whether or not to play the shake effect for players close enough to experience the explosion.
    /// </summary>
    public bool PlayShake { get; }

    /// <inheritdoc />
    public void Explode(Vector3 position)
    {
        Animation.TriggerAnimation(position);
        DealDamage(GetDamageables(position));
    }

    /// <inheritdoc />
    public DamageInfo[] GetDamageables(Vector3 position)
    {
        List<DamageInfo> damageablesFound = new();

        // ReSharper disable once Unity.PreferNonAllocApi
        // Search layers 3 (player), 19 (enemy), and 21 (mine)
        Collider[] hits = Physics.OverlapSphere(position, 14f, 2621448, QueryTriggerInteraction.Collide);
        foreach (Collider obj in hits)
        {
            DamageableComponent damageableComponent = obj.GetComponent<DamageableComponent>();
            if (damageableComponent is null)
                continue;

            float distance = Vector3.Distance(damageableComponent.transform.position, position);
            int damage = distance < this.Distance ? (int)this.DamageCurve.Evaluate((this.Distance - distance) / this.Distance) : 0;
            if(damage > 0)
                damageablesFound.Add(new ExplosiveDamageInfo(damageableComponent, damage, position));

            if (!this.PlayShake)
                continue;

            switch (distance)
            {
                case < 14f:
                    HUDManager.Instance.ShakeCamera(ScreenShakeType.Big);
                    break;
                case < 25f:
                    HUDManager.Instance.ShakeCamera(ScreenShakeType.Small);
                    break;
            }
        }

        Log.Debug($"[Default Explosion Handler] {damageablesFound.Count} damageables found.");
        return damageablesFound.ToArray();
    }

    /// <inheritdoc />
    public void DealDamage(DamageInfo[] damageHandlers)
    {
        foreach (DamageInfo damageHandler in damageHandlers)
        {
            damageHandler.Damageable.OnDamaged(damageHandler);
        }
    }
}