﻿// -----------------------------------------------------------------------
// <copyright file="IDamageable.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Interfaces;

using Features;

/// <summary>
/// Allows damaging an object.
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// Triggered when the item is damaged.
    /// </summary>
    /// <param name="damageInfo">Contains the damage information.</param>
    public void OnDamaged(DamageInfo damageInfo);
}