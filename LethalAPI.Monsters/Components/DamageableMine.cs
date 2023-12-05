// -----------------------------------------------------------------------
// <copyright file="DamageableMine.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Components;

using Enums;
using MEC;

/// <inheritdoc />
public class DamageableMine : DamageableComponent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DamageableMine"/> class.
    /// </summary>
    public DamageableMine()
    {
    }

    /// <summary>
    /// Gets the mine tied to this instance.
    /// </summary>
    public Landmine Mine { get; private set; } = null!;

    /// <summary>
    /// Initializes this component.
    /// </summary>
    /// <param name="mine">The mine tied to this instance.</param>
    public void Init(Landmine mine)
    {
        this.Mine = mine;
    }

    /// <inheritdoc />
    public override void OnDamaged(float damage, DamageType damageType)
    {
        Timing.CallDelayed(1f, () => Mine.TriggerMineOnLocalClientByExiting());
        Destroy(this);
    }
}