namespace SCP012;

using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

public class Config : IConfig
{
    [Description("If the plugin is enabled or not.")]
    public bool IsEnabled { get; set; } = true;

    [Description("Whether or not debug messages should be shown.")]
    public bool Debug { get; set; } = false;

    [Description("The force applied to the player toward SCP-012.")]
    public float AttractionForce { get; set; } = 0.2f;

    [Description("The distance between the player and SCP-012 required to attract a player.")]
    public float AttractionDistance { get; set; } = 5.3f;

    [Description("The distance between the player and SCP-012 required to kill a player.")]
    public float KillDistance { get; set; } = 1.5f;

    [Description("The message displayed when SCP-012 kills a player.")]
    public string DeathMessage { get; set; } = "SCP-012 forced you to cut your hands.";

    [Description("List of effects given to a player when they are in the AttractionDistance.")]
    public IEnumerable<EffectType> InitialEffects { get; set; } = new EffectType[]
    {
        EffectType.Disabled,
        EffectType.Exhausted,
    };

    [Description("Time that indicate how long before next voicelines should be displayed.")]
    public float WaitUntilNextLine { get; set; } = 6f;

    [Description("List of voicelines, showed when the player is in the KillDistance.")]
    public string[] VoiceLines { get; set; } = new string[]
    {
        "I have to... I have to finish it...",
        "You really wanna do it?",
        "What?",
        "I... I don't... think I can do this.",
        "I-I... must do it.",
        "I-I have no ch-cho-choice...",
        "This... This makes... no sense",
        "This... This is impossible!",
        "It can't be completed!"
    };
}