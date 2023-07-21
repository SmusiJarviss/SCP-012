namespace SCP012;

using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.Collections.Generic;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = true;

    public bool Debug { get; set; } = true;

    public float AttractionForce { get; set; } = 0.2f;

    public float AttractionDistance { get; set; } = 5.3f;

    public float KillDistance { get; set; } = 1.5f;

    public string DeathMessage { get; set; } = "SCP-012 forced you to cut your hands.";

    public IEnumerable<EffectType> InitialEffects { get; set; } = new EffectType[]
    {
        EffectType.Disabled,
        EffectType.Exhausted,
    };

    public float WaitUntilNextLine { get; set; } = 6f;

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