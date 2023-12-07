// -----------------------------------------------------------------------
// <copyright file="WebInstance.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace LethalAPI.Monsters.Hazards;

using UnityEngine;

/// <summary>
/// Contains the instance implementations for the web.
/// </summary>
public partial class Web : Hazard<SandSpiderWebTrap, Web>
{
    private Web(GameObject web)
        : base(web)
    {
    }

    /// <inheritdoc />
    public override Transform Transform => Base.transform;

    /// <summary>
    /// Gets or sets the speed multiplier for the web.
    /// </summary>
    /// <remarks>1 is normal speed. Default is 0.25f. (Player is 4x slower).</remarks>
    public float SpeedMultiplier { get; set; } = 0.25f;

    /// <summary>
    /// Orients the web towards a specific position.
    /// </summary>
    /// <param name="positionToOrientTowards">The position to orient the web towards.</param>
    public void OrientTowardsPosition(Vector3 positionToOrientTowards)
    {
        Transform.LookAt(positionToOrientTowards);
    }
}