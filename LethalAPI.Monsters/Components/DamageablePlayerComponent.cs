// -----------------------------------------------------------------------
// <copyright file="DamageablePlayerComponent.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Components;

using Features;
using GameNetcodeStuff;
using UnityEngine;

/// <summary>
/// Contains the implementation for damageing a player.
/// </summary>
public sealed class DamageablePlayerComponent : DamageableComponent
{
    /// <summary>
    /// Gets the player this instance is attached to.
    /// </summary>
    public PlayerControllerB Player { get; private set; } = null!;

    /// <inheritdoc />
    public override void OnDamaged(DamageInfo damageInfo)
    {
        Log.Debug($"Player {this.Player.playerUsername} damaged by {damageInfo.Type} for {damageInfo.Damage} hp.");
        Vector3 velocity = Vector3.zero;
        if (this.Player.health < damageInfo.Damage)
        {
            if (damageInfo is ExplosiveDamageInfo explosiveDamageInfo)
            {
                Vector3 playerPosition = this.Player.gameplayCamera.transform.position;
                velocity = (playerPosition - explosiveDamageInfo.ExplosionPosition) * 80f / Vector3.Distance(playerPosition, explosiveDamageInfo.ExplosionPosition);
            }

            this.Player.KillPlayer(velocity, spawnBody: true, damageInfo.Type);
            return;
        }

        this.Player.DamagePlayer(damageInfo.Damage, true, true, damageInfo.Type);
    }

    /// <summary>
    /// Initializes the component.
    /// </summary>
    /// <param name="player">The player this is attached to.</param>
    internal void Init(PlayerControllerB player)
    {
        this.Player = player;
        this.gameObject.layer = 3;
    }
}