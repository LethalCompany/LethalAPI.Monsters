// -----------------------------------------------------------------------
// <copyright file="PlayerControllerDamageablePatch.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

#pragma warning disable SA1313 // parameter name should not start with _
namespace LethalAPI.Monsters.Patches;

using Components;
using GameNetcodeStuff;
using HarmonyLib;

/// <summary>
/// Patches the <see cref="PlayerControllerB.Start"/> to attach the <see cref="DamageablePlayerComponent"/>.
/// </summary>
[HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.Start))]
internal static class PlayerControllerDamageablePatch
{
    [HarmonyPostfix]
    private static void Postfix(PlayerControllerB __instance)
    {
        __instance.transform.gameObject.AddComponent<DamageablePlayerComponent>().Init(__instance);
    }
}