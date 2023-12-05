// -----------------------------------------------------------------------
// <copyright file="DamageInfo.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

#pragma warning disable SA1402 // file may only contain a single type.
namespace LethalAPI.Monsters.Features;

using Interfaces;

/// <summary>
/// Provides a method for transporting damage information from the GetDamageables method to the DealDamage. This allows damage to be processed in either <see cref="IExplosionHandler.Explode"/> or <see cref="IExplosionHandler.GetDamageables"/>.
/// </summary>
/// <param name="Damageable">The <see cref="IDamageable"/>.</param>
/// <param name="Damage">The damage to deal.</param>
/// <param name="Type">The type of damage to deal.</param>
public record DamageInfo(IDamageable Damageable, int Damage, CauseOfDeath Type);

/// <summary>
/// Provides a method for transporting damage information from the GetDamageables method to the DealDamage. This allows damage to be processed in either <see cref="IExplosionHandler.Explode"/> or <see cref="IExplosionHandler.GetDamageables"/>.
/// </summary>
/// <param name="Damageable">The <see cref="IDamageable"/>.</param>
/// <param name="Damage">The damage to deal.</param>
/// <param name="ExplosionPosition">The position of the explosion.</param>
public record ExplosiveDamageInfo(IDamageable Damageable, int Damage, Vector3 ExplosionPosition) : DamageInfo(Damageable, Damage, CauseOfDeath.Blast);
