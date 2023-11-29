// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters;

using System.ComponentModel;

/// <inheritdoc />
public sealed class Config : LethalAPI.Core.Interfaces.IConfig
{
    /// <inheritdoc />
    [Description("Indicates whether or not the plugin should be loaded.")]
    public bool IsEnabled { get; set; }

    /// <inheritdoc />
    [Description("Indicates whether or not debug logs should be shown.")]
    public bool Debug { get; set; }
}