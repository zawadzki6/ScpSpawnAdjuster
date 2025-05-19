using Exiled.API.Features;
using PlayerRoles;
using Player = Exiled.API.Features.Player;
using Server = Exiled.Events.Handlers.Server;

namespace ScpSpawnAdjuster;

public class Plugin : Plugin<Config> {
    static Plugin? Instance;

    public override string Name => "ScpSpawnAdjuster";
    public override string Author => "Zawadzki Wielki";
    public override string Prefix { get; } = "ScpSpawnAdjuster";
    public override Version Version => new Version(1, 0, 0);

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

    public void OnRoundStarted() {
        if (Player.List.Count() < Config.minPlayersForScp) {
            foreach (Player player in Player.List) {
                if (player.Role.Team == PlayerRoles.Team.SCPs)
                    if (Enum.TryParse<RoleTypeId>(Config.replacementRole, out var replacement))
                        player.Role.Set(replacement);
            }
        }
    }
}


