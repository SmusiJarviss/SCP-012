namespace SCP012;

using Exiled.API.Features;
using UnityEngine;

public static class Extensions
{
    public static bool IsValidTarget(this Player player, Vector3 target, float maxDistance) => Vector3.Distance(player.Position, target) < maxDistance;
}