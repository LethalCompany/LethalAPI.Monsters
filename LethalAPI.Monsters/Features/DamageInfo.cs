// -----------------------------------------------------------------------
// <copyright file="DamageInfo.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Features;

using Interfaces;

/// <summary>
/// Provides a method for transporting damage information from the GetDamageables method to the DealDamage. This allows damage to be processed in either <see cref="IExplosionHandler.Explode"/> or <see cref="IExplosionHandler.GetDamageables"/>.
/// </summary>
/// <param name="Damageable">The <see cref="Damageable"/>.</param>
/// <param name="Damage">The damage to deal.</param>
public record DamageInfo(IDamageable Damageable, float Damage);