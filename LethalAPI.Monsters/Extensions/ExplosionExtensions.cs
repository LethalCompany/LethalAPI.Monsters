// -----------------------------------------------------------------------
// <copyright file="ExplosionExtensions.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

// ReSharper disable MemberCanBePrivate.Global
namespace LethalAPI.Monsters.Extensions;

using DunGen;
using Features;
using GameNetcodeStuff;
using Interfaces;
using UnityEngine;

/// <summary>
/// Contains a set of extensions for triggering explosions.
/// </summary>
public static class ExplosionExtensions
{
    /// <summary>
    /// Spawns an explosion at a position.
    /// </summary>
    /// <param name="position">The position to spawn the explosion at.</param>
    /// <param name="explosionHandler">The explosion handler to use to spawn the explosion at. When no handler is provided the <see cref="DefaultExplosionHandler"/> will be used.</param>
    public static void SpawnExplosion(Vector3 position, IExplosionHandler? explosionHandler = null)
    {
        (explosionHandler ?? DefaultExplosionHandler.Default).Explode(position);
    }

    /// <summary>
    /// Spawns an explosion at a transform.
    /// </summary>
    /// <param name="transform">The transform to spawn the explosion at.</param>
    /// <param name="explosionHandler">The explosion handler to use to spawn the explosion at. When no handler is provided the <see cref="DefaultExplosionHandler"/> will be used.</param>
    public static void SpawnExplosion(Transform transform, IExplosionHandler? explosionHandler = null) => SpawnExplosion(transform.position, explosionHandler);

    /// <summary>
    /// Spawns an explosion at a gameObject.
    /// </summary>
    /// <param name="gameObject">The GameObject to spawn the explosion at.</param>
    /// <param name="explosionHandler">The explosion handler to use to spawn the explosion at. When no handler is provided the <see cref="DefaultExplosionHandler"/> will be used.</param>
    public static void SpawnExplosion(GameObject gameObject, IExplosionHandler? explosionHandler = null) => SpawnExplosion(gameObject.transform.position, explosionHandler);

    /// <summary>
    /// Spawns an explosion on a player.
    /// </summary>
    /// <param name="player">The player to spawn the explosion on.</param>
    /// <param name="explosionHandler">The explosion handler to use to spawn the explosion at. When no handler is provided the <see cref="DefaultExplosionHandler"/> will be used.</param>
    public static void Explode(this PlayerControllerB player, IExplosionHandler? explosionHandler = null) => SpawnExplosion(player.transform.position, explosionHandler);

    /// <summary>
    /// Spawns an explosion on a mine.
    /// </summary>
    /// <param name="mine">The landmine to spawn the explosion on.</param>
    /// <param name="explosionHandler">The explosion handler to use to spawn the explosion at. When no handler is provided the <see cref="DefaultExplosionHandler"/> will be used.</param>
    public static void Explode(this Landmine mine, IExplosionHandler? explosionHandler = null) => SpawnExplosion(mine.transform.position, explosionHandler);

    /// <summary>
    /// Spawns an explosion on an enemy.
    /// </summary>
    /// <param name="enemy">The enemy to spawn the explosion on.</param>
    /// <param name="explosionHandler">The explosion handler to use to spawn the explosion at. When no handler is provided the <see cref="DefaultExplosionHandler"/> will be used.</param>
    public static void Explode(this EnemyAI enemy, IExplosionHandler? explosionHandler = null) => SpawnExplosion(enemy.transform.position, explosionHandler);

    /// <summary>
    /// Spawns an explosion on a door.
    /// </summary>
    /// <param name="door">The door to spawn the explosion on.</param>
    /// <param name="explosionHandler">The explosion handler to use to spawn the explosion at. When no handler is provided the <see cref="DefaultExplosionHandler"/> will be used.</param>
    public static void Explode(this Door door, IExplosionHandler? explosionHandler = null) => SpawnExplosion(door.transform.position, explosionHandler);
}