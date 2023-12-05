// -----------------------------------------------------------------------
// <copyright file="IExplosionAnimation.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Interfaces;

/// <summary>
/// Contains the triggers for explosion animations.
/// </summary>
public interface IExplosionAnimation
{
    /// <summary>
    /// Triggers an explosion animation.
    /// </summary>
    /// <param name="position">The position to play the animation at.</param>
    public void TriggerAnimation(Vector3 position);
}