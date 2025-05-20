using Exiled.API.Features;
using PlayerRoles;
using Player = Exiled.API.Features.Player;
using Server = Exiled.Events.Handlers.Server;
using MEC;

namespace ScpSpawnAdjuster;

public class Plugin : Plugin<Config> {
    static Plugin? Instance;

    public override string Name => "ScpSpawnAdjuster";
    public override string Author => "Zawadzki Wielki";
    public override string Prefix { get; } = "ScpSpawnAdjuster";
    public override Version Version => new Version(1, 1, 0);

    public override void OnEnabled() {
        Instance = this;
        Server.RoundStarted += OnRoundStarted;
        base.OnEnabled();
    }
    public override void OnDisabled() {
        Instance = null;
        Server.RoundStarted -= OnRoundStarted;
        base.OnDisabled();
    }

    
    // this exists because I had instabilities without a delay
    public void OnRoundStarted() => Timing.CallDelayed(1, () => SSA());
    

    // plugin functionality
    public void SSA() {
        var scps = Player.List.Where(player => player.Role.Team == Team.SCPs).ToList();
        int? allowed = GetAllowed(Player.List.Count());

        if (allowed == null)
            return;
        
        if (scps.Count > allowed)
            foreach (var scp in scps.Skip(allowed.Value))
                if (Enum.TryParse<RoleTypeId>(Config.replacementRole, out var replacement))
                    scp.Role.Set(replacement);
    }

    private int? GetAllowed(int playerCount) {
        

        // this is here so the plugin doesnt error on 0 keys, skips the plugin completely
        if (Config.SpawnLimits == null || Config.SpawnLimits.Count == 0)
            return null;

        // skip plugin functionality if there isnt a key as big as the player count
        if (playerCount > Config.SpawnLimits.Keys.Max())
            return null;

        var validLimits = Config.SpawnLimits
            .Where(kv => kv.Key <= Player.List.Count())
            .OrderByDescending(kv => kv.Key)
            .FirstOrDefault();

        return validLimits.Value;
    }
}


