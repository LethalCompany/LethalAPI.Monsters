// -----------------------------------------------------------------------
// <copyright file="MineInstance.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace LethalAPI.Monsters.Hazards;

using Unity.Netcode;
using UnityEngine;

/// <summary>
/// Contains the instance implementations for the mine.
/// </summary>
public partial class Mine : Hazard<Landmine, Mine>
{
    private Mine(GameObject mine)
        : base(mine)
    {
    }

    /// <inheritdoc />
    public override Transform Transform => Base.transform;

    /// <summary>
    /// Gets or sets a value indicating whether or not the mine is disarmed.
    /// </summary>
    public bool IsDisarmed
    {
        get => !Base.mineActivated;
        set => Base.mineActivated = !value;
    }

    /// <summary>
    /// Makes a mine explode.
    /// </summary>
    public void Explode()
    {
        Base.TriggerMineOnLocalClientByExiting();
    }

    /// <summary>
    /// Spawns the mine on the network.
    /// </summary>
    public void Spawn()
    {
        this.GameObject.GetComponent<NetworkObject>().Spawn(destroyWithScene: true);
    }
}