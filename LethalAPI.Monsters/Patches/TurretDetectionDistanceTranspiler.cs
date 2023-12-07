// -----------------------------------------------------------------------
// <copyright file="TurretDetectionDistanceTranspiler.cs" company="LethalAPI Modding Community">
// Copyright (c) LethalAPI Modding Community. All rights reserved.
// Licensed under the LGPL-3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LethalAPI.Monsters.Patches;

using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

using HarmonyLib;
using Hazards;

using static HarmonyLib.AccessTools;

/// <summary>
/// Patches the <see cref="GameTurret.CheckForPlayersInLineOfSight"/> method. Allows the <see cref="Turret.DetectionDistance"/> feature to work.
/// </summary>
[HarmonyPatch(typeof(Turret), "CheckForPlayersInLineOfSight")]
[HarmonyWrapSafe]
public static class TurretDetectionDistanceTranspiler
{
    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        List<CodeInstruction> newInstructions = instructions.ToList();
        int index = newInstructions.FindIndex(x => x.opcode == OpCodes.Ldc_R4 && x.operand is 30f);
        CodeInstruction[] injectedInstructions =
        {
            new (OpCodes.Ldarg_0),
            new (OpCodes.Call, Method(typeof(TurretDetectionDistanceTranspiler), nameof(GetRange))),
        };
        newInstructions.RemoveRange(index, 1);
        newInstructions.InsertRange(index, injectedInstructions);

        for (int i = 0; i < newInstructions.Count; i++)
            yield return newInstructions[i];
    }

    /// <summary>
    /// Gets the new range of the turret.
    /// </summary>
    /// <param name="instance">The instance of the turret shooting.</param>
    /// <returns>The new range of the turret shooting.</returns>
    public static float GetRange(GameTurret instance)
    {
        Turret? turret = Turret.List.FirstOrDefault(x => x.Base == instance);
        if (turret is null)
            return 30;

        return turret.DetectionDistance;
    }
}