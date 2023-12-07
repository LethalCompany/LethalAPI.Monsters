// -----------------------------------------------------------------------
// <copyright file="DamageableEnemyComponent.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Components;

using Features;

/// <summary>
/// Contains the implementation for damageing a player.
/// </summary>
public sealed class DamageableEnemyComponent : DamageableComponent
{
    /// <summary>
    /// Used to determine the force of the damage. Currently this is 1/10th of the player's health.
    /// </summary>
    private const float ForceMultiplier = 0.1f;

    /// <summary>
    /// Gets the enemy that this instance represents.
    /// </summary>
    public EnemyAI Enemy { get; private set; } = null!;

    /// <inheritdoc />
    public override void OnDamaged(DamageInfo damageInfo)
    {
        Log.Debug($"Enemy {this.Enemy.GetType().Name} damaged by {damageInfo.Type} for {damageInfo.Damage} hp.");
        this.Enemy.HitEnemy((int)(damageInfo.Damage * ForceMultiplier));
    }

    /// <summary>
    /// Initializes this component.
    /// </summary>
    /// <param name="enemy">The enemy tied to this instance.</param>
    internal void Init(EnemyAI enemy)
    {
        this.Enemy = enemy;
        this.gameObject.layer = 19;
    }
}