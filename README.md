# SCP Spawn Adjuster
### An SCP:SL EXILED plugin which adjusts from what player count SCPs can spawn
The plugin checks whether there's enough players for an SCP. If false, the player is changed to a specified class.

## Config
```yaml
is_enabled: true
debug: false
# Role to replace SCPs with
replacement_role: 'FacilityGuard'
# How many players are needed in the server for SCPs to spawn
min_players_for_scp: 6
```

### This project is licensed under the GNU General Public License v3.0.
You may use, modify, and distribute it, provided that all copies and derivatives are released under the same license.
For full terms, see the [LICENSE](LICENSE)
