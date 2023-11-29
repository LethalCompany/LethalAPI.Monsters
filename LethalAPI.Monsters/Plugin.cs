// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters;

using System;

using LethalAPI.Core;

/// <inheritdoc />
public sealed class Plugin : Core.Features.Plugin<Config>
{
    /// <summary>
    /// Gets the main <see cref="Plugin"/> instance.
    /// </summary>
    public static Plugin Instance { get; private set; } = null!;

    /// <inheritdoc />
    public override string Name => "LethalAPI-Monsters";

    /// <inheritdoc />
    public override string Description => "Contains Monsters & Bestiary APIs.";

    /// <inheritdoc />
    public override string Author => "Lethal API Modding Community";

    /// <inheritdoc />
    public override Version Version => new Version(0, 0, 01);

    /// <inheritdoc />
    public override void OnEnabled()
    {
        if (!this.Config.IsEnabled)
        {
            return;
        }

        Log.Info($"{this.Name} is being loaded...");
    }
}