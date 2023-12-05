// -----------------------------------------------------------------------
// <copyright file="IDamageable.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Interfaces;

using LethalAPI.Monsters.Enums;

/// <summary>
/// Allows damaging an object.
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// Triggered when the item is damaged.
    /// </summary>
    /// <param name="damage">Gets the damage to deal.</param>
    /// <param name="damageType">Gets the type of damage to deal.</param>
    public void OnDamaged(float damage, DamageType damageType);
}