// -----------------------------------------------------------------------
// <copyright file="MineDamageablePatch.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

#pragma warning disable SA1313 // parameter name should not start with _
namespace LethalAPI.Monsters.Patches;

using Components;
using HarmonyLib;

/// <summary>
/// Patches the <see cref="Landmine.Start"/> to attach the <see cref="DamageableMineComponent"/>.
/// </summary>
[HarmonyPatch(typeof(Landmine), nameof(Landmine.Start))]
internal static class MineDamageablePatch
{
    [HarmonyPostfix]
    private static void Postfix(Landmine __instance)
    {
        __instance.transform.gameObject.AddComponent<DamageableMineComponent>().Init(__instance);
    }
}