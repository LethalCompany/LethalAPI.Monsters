// -----------------------------------------------------------------------
// <copyright file="TurretInstance.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable once CheckNamespace
namespace LethalAPI.Monsters.Hazards;

using System;

using Core;
using Unity.Netcode;
using UnityEngine;

using GameTurret = global::Turret;

/// <summary>
/// Represents a turret and abstractions for a turret.
/// </summary>
public partial class Turret : Hazard<GameTurret, Turret>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Turret"/> class.
    /// </summary>
    /// <remarks>
    /// Developers must use <see cref="Turret.Get(GameTurret)"/> or <see cref="Turret.Create"/> to create an instance.
    /// </remarks>
    /// <param name="turret">The existing turret to use.</param>
    private Turret(GameObject turret)
        : base(turret)
    {
        try
        {
            this.GameObject = turret;
            this.Base = turret.GetComponentInChildren<GameTurret>();
        }
        catch (Exception e)
        {
            Log.Warn($"Turret Base or GameObject was null!");
            if(Plugin.Instance.Config.Debug)
                Log.Exception(e);
        }
    }

    /// <inheritdoc />
    public override Transform Transform => this.GameObject.transform;

    /// <summary>
    /// Gets or sets a value indicating whether or not the turret is disarmed.
    /// </summary>
    public bool IsDisarmed
    {
        get => !Base.turretActive;
        set => Base.turretActive = !value;
    }

    /// <summary>
    /// Gets or sets a value indicating the <see cref="TurretMode"/> of which a turret is currently operating.
    /// </summary>
    public TurretMode Mode
    {
        get => Base.turretMode;
        set => Base.turretMode = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the barrel is rotating clockwise or counter-clockwise.
    /// </summary>
    /// <remarks>Needs to use the rpc call.</remarks>
    public bool RotatingClockwise
    {
        get => Base.rotatingClockwise;
        set => Base.rotatingClockwise = value;
    }

    /// <summary>
    /// Gets or sets a value representing the detection distance of the turret.
    /// </summary>
    /// <returns>The detection distance of the turret.</returns>
    public float DetectionDistance { get; set; } = 30f;

    /// <summary>
    /// Spawns the turret instance.
    /// </summary>
    public void Spawn()
    {
        this.GameObject.GetComponent<NetworkObject>().Spawn(destroyWithScene: true);
    }
}