// -----------------------------------------------------------------------
// <copyright file="DamageableEnemyComponent.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Components;

using Enums;
using UnityEngine;

/// <summary>
/// Contains the implementation for damageing a player.
/// </summary>
public sealed class DamageableEnemyComponent : DamageableComponent
{
    /// <inheritdoc />
    public override void OnDamaged(float damage, DamageType damageType)
    {
    }
}