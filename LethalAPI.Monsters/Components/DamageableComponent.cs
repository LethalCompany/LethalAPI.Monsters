// -----------------------------------------------------------------------
// <copyright file="DamageableComponent.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Components;

using Features;
using Interfaces;
using UnityEngine;

/// <summary>
/// Contains the implementation for damageing a player.
/// </summary>
public class DamageableComponent : MonoBehaviour, IDamageable
{
    /// <inheritdoc />
    public virtual void OnDamaged(DamageInfo damageInfo)
    {
    }
}