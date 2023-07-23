namespace SCP012;

using Exiled.API.Features;
using SCP012.Logic;
using System;

public class Plugin : Plugin<Config>
{
    public override string Name => "SCP-012";

    public override string Author => "Smusi Jarvis";

    public override Version Version => new(1, 0, 1);

    public override Version RequiredExiledVersion => new Version(7, 2, 0);

    public static Plugin Singleton { get; private set; }

    public SCP012 Handler { get; private set; }

    public override void OnEnabled()
    {
        Singleton = this;
        RegisterEvents();

        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        UnRegisterEvents();

        base.OnDisabled();
    }

    private void RegisterEvents()
    {
        Handler = new();

        Exiled.Events.Handlers.Server.RoundStarted += Handler.OnRoundStarted;
        Exiled.Events.Handlers.Server.RoundEnded += Handler.OnRoundEnded;
    }

    private void UnRegisterEvents()
    {
        Exiled.Events.Handlers.Server.RoundStarted -= Handler.OnRoundStarted;
        Exiled.Events.Handlers.Server.RoundEnded -= Handler.OnRoundEnded;

        Handler = null;
        Singleton = null;
    }
}