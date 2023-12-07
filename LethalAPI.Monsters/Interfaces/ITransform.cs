// -----------------------------------------------------------------------
// <copyright file="ITransform.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Interfaces;

using UnityEngine;

/// <summary>
/// Contains elements for easily accessing and modifying <see cref="Transform"/> properties.
/// </summary>
public interface ITransform
{
    /// <summary>
    /// Gets the <see cref="UnityEngine.Transform"/>.
    /// </summary>
    public Transform Transform { get; }

    /// <summary>
    /// Gets or sets the <see cref="UnityEngine.Transform.position">Transform.Position</see>.
    /// </summary>
    public Vector3 Position { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="UnityEngine.Transform.rotation">Transform.Rotation</see>.
    /// </summary>
    public Quaternion Rotation { get; set; }
}