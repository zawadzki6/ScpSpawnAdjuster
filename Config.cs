using System.ComponentModel;
using Exiled.API.Interfaces;

namespace ScpSpawnAdjuster;

public class Config : IConfig {
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; }
    
    [Description("Role to replace SCPs with")]
    public string replacementRole { get; set; } = "FacilityGuard"; 

    [Description("How many players are needed in the server for SCPs to spawn")]
    public byte minPlayersForScp { get; set; } = 6;
}
