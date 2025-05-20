using System.ComponentModel;
using Exiled.API.Interfaces;

namespace ScpSpawnAdjuster;

public class Config : IConfig {
    
    [Description("Role to replace SCPs with")]
    public string replacementRole { get; set; } = "FacilityGuard"; 

    [Description("Map of player count to allowed SCP count")]
    public Dictionary<int, int> SpawnLimits { get; set; } = new() {
        { 6, 0 },
        { 8, 1 },
        { 10, 2 }
    };

    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; }
}
