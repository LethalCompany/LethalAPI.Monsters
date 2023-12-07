// -----------------------------------------------------------------------
// <copyright file="DamageableMineComponent.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Components;

using Features;
using MEC;

/// <inheritdoc />
public class DamageableMineComponent : DamageableComponent
{
    /// <summary>
    /// Gets the mine tied to this instance.
    /// </summary>
    public Landmine Mine { get; private set; } = null!;

    /// <inheritdoc />
    public override void OnDamaged(DamageInfo damageInfo)
    {
        Log.Debug($"Mine damaged by {damageInfo.Type} for {damageInfo.Damage} hp.");
        Timing.CallDelayed(1f, () => Mine.TriggerMineOnLocalClientByExiting());
        Destroy(this);
    }

    /// <summary>
    /// Initializes this component.
    /// </summary>
    /// <param name="mine">The mine tied to this instance.</param>
    internal void Init(Landmine mine)
    {
        this.Mine = mine;
        this.gameObject.layer = 21;
    }
}