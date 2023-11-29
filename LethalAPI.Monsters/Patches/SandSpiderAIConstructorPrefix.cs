// -----------------------------------------------------------------------
// <copyright file="SandSpiderAIConstructorPrefix.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Patches;

using Core;
using HarmonyLib;
using Monsters.Hazards;

/// <summary>
/// Gets the instance of the SandSpiderAI.
/// </summary>
[HarmonyPatch(typeof(SandSpiderAI), MethodType.Constructor)]
internal static class SandSpiderAIConstructorPrefix
{
    [HarmonyPrefix]
    private static void Prefix(SandSpiderAI __instance)
    {
        Log.Debug("Got SandSpiderAI Instance.");
        Web.SpiderAI = __instance;
        Web.WebPrefab = __instance.webTrapPrefab;
    }
}