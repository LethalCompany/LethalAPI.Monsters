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