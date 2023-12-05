// -----------------------------------------------------------------------
// <copyright file="DefaultExplosionAnimation.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Features;

using Interfaces;
using UnityEngine;

/// <summary>
/// The default Explosion Animation.
/// </summary>
public sealed class DefaultExplosionAnimation : IExplosionAnimation
{
    /// <summary>
    /// Gets the default instance of the explosion animation.
    /// </summary>
    public static DefaultExplosionAnimation Instance => new();

    /// <inheritdoc />
    public void TriggerAnimation(Vector3 position)
    {
        Object.Instantiate(StartOfRound.Instance.explosionPrefab, position, Quaternion.Euler(-90f, 0f, 0f), RoundManager.Instance.mapPropsContainer.transform).SetActive(value: true);
    }
}