﻿// -----------------------------------------------------------------------
// <copyright file="EnemyAIDamageablePatch.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

#pragma warning disable SA1313 // parameter name should not start with _
namespace LethalAPI.Monsters.Patches;

using Components;
using HarmonyLib;

/// <summary>
/// Patches the <see cref="EnemyAI.Start"/> to attach the <see cref="DamageableEnemyComponent"/>.
/// </summary>
[HarmonyPatch(typeof(EnemyAI), nameof(EnemyAI.Start))]
internal static class EnemyAIDamageablePatch
{
    [HarmonyPostfix]
    private static void Postfix(EnemyAI __instance)
    {
        __instance.transform.gameObject.AddComponent<DamageableEnemyComponent>().Init(__instance);
    }
}