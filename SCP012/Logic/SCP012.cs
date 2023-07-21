namespace SCP012.Logic;

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using MapEditorReborn.API;
using MapEditorReborn.API.Features.Objects;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SCP012
{
    private List<CoroutineHandle> CoroutineHandle = new();

    private bool isAnimationPlayed;

    public void OnRoundStarted() => CoroutineHandle.Add(Timing.RunCoroutine(CheckPlayers()));

    public void OnRoundEnded(RoundEndedEventArgs _)
    {
        Timing.KillCoroutines(CoroutineHandle.ToArray()); 
        isAnimationPlayed = false;
    }

    private IEnumerator<float> CheckPlayers()
    {
        MapEditorObject SCP012Containment = API.SpawnedObjects.FirstOrDefault(x => x is SchematicObject schematic && schematic.name == "CustomSchematic-SCP012Containment");
        MapEditorObject SCP012Object = API.SpawnedObjects.First(x => x is PrimitiveObject obj && obj.Base.Color == "#FFFFFF55");

        if (SCP012Object is null || SCP012Containment is null)
        {
            Log.Error("SCP012 is null, it will not affect player anymore.");
            yield break;
        }

        while (Round.IsStarted)
        {
            yield return Timing.WaitForSeconds(0.65f);
            
            foreach (Player player in Player.List.Where(x => !x.IsTutorial && !x.IsScp && !x.IsGodModeEnabled && x.IsValidTarget(SCP012Object.Position, Plugin.Singleton.Config.AttractionDistance)))
            {
                if (!isAnimationPlayed)
                {
                    (SCP012Containment as SchematicObject).AnimationController.Play("SCP012_Start", "Containment");
                    isAnimationPlayed = true;
                }

                player.EnableEffects(Plugin.Singleton.Config.InitialEffects, 10f);
                player.Position = Vector3.MoveTowards(player.Position, SCP012Object.Position, Plugin.Singleton.Config.AttractionForce);

                if (player.IsValidTarget(SCP012Object.Position, Plugin.Singleton.Config.KillDistance))
                {
                    player.DisableAllEffects();
                    player.EnableEffect(EffectType.Ensnared, 500f);
                    yield return Timing.WaitUntilDone(VoiceLines(player));
                    player.EnableEffect(EffectType.SeveredHands, 10f);
                    player.EnableEffect(EffectType.Bleeding, 10f);
                    yield return Timing.WaitForSeconds(3f);
                    player.Kill(Plugin.Singleton.Config.DeathMessage);
                }
            }
        }
    }

    private IEnumerator<float> VoiceLines(Player player)
    {
        for (int i = 0; i < Plugin.Singleton.Config.VoiceLines.Count(); i++)
        {
            player.ShowHint(Plugin.Singleton.Config.VoiceLines[i]);
            yield return Timing.WaitForSeconds(Plugin.Singleton.Config.WaitUntilNextLine);
            player.PlaceBlood(Vector3.down);
        }
    }
}