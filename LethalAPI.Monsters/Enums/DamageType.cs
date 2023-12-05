// -----------------------------------------------------------------------
// <copyright file="DamageType.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Enums;

using Interfaces;

/// <summary>
/// Indicates the damaage type when an <see cref="IDamageable"/> is damaged.
/// </summary>
public enum DamageType
{
    /// <summary>
    /// Indicates that the damage was due to melee from a shovel, sign, or other melee damage type.
    /// </summary>
    Melee,

    /// <summary>
    /// Indicates that the damage was due to an enemy.
    /// </summary>
    Enemy,

    /// <summary>
    /// Indicates that the damage was due to a hazard.
    /// </summary>
    Hazard,

    /// <summary>
    /// Indicates that the damage was self-inflicted.
    /// </summary>
    Self,

    /// <summary>
    /// Indicates that the damage was due to falling.
    /// </summary>
    Falling,

    /// <summary>
    /// Indicates that the damage was due to an extension ladder.
    /// </summary>
    Ladder,

    /// <summary>
    /// Indicates that the damage was due to an explosion.
    /// </summary>
    Explosion,
}