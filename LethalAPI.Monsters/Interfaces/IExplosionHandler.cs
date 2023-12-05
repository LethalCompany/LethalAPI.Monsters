// -----------------------------------------------------------------------
// <copyright file="IExplosionHandler.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Interfaces;

using Features;
using UnityEngine;

/// <summary>
/// The interface for dealing with explosions.
/// </summary>
public interface IExplosionHandler
{
    /// <summary>
    /// Called when an explosion is triggered.
    /// </summary>
    /// <param name="position">The position the explosion is at.</param>
    public void Explode(Vector3 position);

    /// <summary>
    /// Gets the damageable objects from the explosion.
    /// </summary>
    /// <param name="position">The position the explosion is at.</param>
    /// <returns>The damaged <see cref="IDamageable"/> objects as <see cref="DamageInfo"/>.</returns>
    public DamageInfo[] GetDamageables(Vector3 position);

    /// <summary>
    /// Deals damage to <see cref="IDamageable"/> via <see cref="DamageInfo"/>.
    /// </summary>
    /// <param name="damageHandlers">The damage handlers to process.</param>
    public void DealDamage(DamageInfo[] damageHandlers);
}