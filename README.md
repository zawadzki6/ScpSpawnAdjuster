# SCP Spawn Adjuster
 An SCP:SL EXILED plugin that dynamically adjusts the number of SCPs spawned replacing SCPs with a configurable role based on player count 

In the `spawn_limits` config set the player counts as the keys and the SCPs amount at that player counts as the value

## Default Config
```yaml
# Role to replace SCPs with
replacement_role: 'FacilityGuard'
# Map of player count to allowed SCP count
spawn_limits:
  6: 0
  8: 1
  10: 2
is_enabled: true
debug: false
```

### This project is licensed under the GNU General Public License v3.0.
You may use, modify, and distribute it, provided that all copies and derivatives are released under the same license.
For full terms, see the [LICENSE](LICENSE)


