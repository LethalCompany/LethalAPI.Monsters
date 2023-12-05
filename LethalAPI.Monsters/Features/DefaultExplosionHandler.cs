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
using Enums;
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
    /// <param name="distance">The distance to deal damage.</param>
    /// <param name="curve">The damage curve for calculating damage to deal damage.</param>
    public DefaultExplosionHandler(float distance = 5, AnimationCurve? curve = null)
    {
        this.Distance = distance;
        this.DamageCurve = curve ?? new(new Keyframe(0, 100), new Keyframe(100, 100));
    }

    /// <summary>
    /// Gets or sets the distance that the explosion can deal damage.
    /// </summary>
    public float Distance { get; set; }

    /// <summary>
    /// Gets the damage curve to apply to the explosion.
    /// </summary>
    public AnimationCurve DamageCurve { get; }

    /// <inheritdoc />
    public void Explode(Vector3 position)
    {
        DealDamage(GetDamageables(position));
    }

    /// <inheritdoc />
    public DamageInfo[] GetDamageables(Vector3 position)
    {
        List<DamageInfo> damageablesFound = new();
        RaycastHit[] hits = Array.Empty<RaycastHit>();
        Physics.SphereCastNonAlloc(position, this.Distance, Vector3.forward, hits);
        foreach (RaycastHit obj in hits)
        {
            DamageableComponent damageablePlayer = obj.collider.GetComponentInParent<DamageableComponent>();
            if (damageablePlayer is null)
                continue;

            float distance = Vector3.Distance(damageablePlayer.transform.position, position);
            damageablesFound.Add(new DamageInfo(damageablePlayer, DamageCurve.Evaluate((this.Distance - distance) / this.Distance)));
        }

        return damageablesFound.ToArray();
    }

    /// <inheritdoc />
    public void DealDamage(DamageInfo[] damageHandlers)
    {
        foreach (DamageInfo damageHandler in damageHandlers)
        {
            damageHandler.Damageable.OnDamaged(damageHandler.Damage, DamageType.Explosion);
        }
    }
}