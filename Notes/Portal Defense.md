## Summary
Enemies are spawning at the evil kingdom, and moving to the portal shrine. You have to stop them.

### Game Loop
Each wave is represented as a day, with the lighting (do the lighting).
As enemies are killed, the day progresses to show wave progress.
Each morning, before the day starts, pick 3 out of 5-7 cards to play that morning.
* Gain Resources gained from last day.
* Cast Spells available.
* Use building ablities.
* Spawn day enemies.
During day, as it plays out:
* Enemies die and give xp rewards
* Workers collect resources
* Traps are used 
* Train at buildings
* Repair damage

As experience is gained, each level a new level up bonus is given.

### Level Up Bonuses
Each time you level up, choose one of 3 bonuses
* Elites: Cards of a certain types always spawn with +1 level
* Sovereign: Cards that give influence give +X influence
* Training: Play X training cards immediately
* Windfall: Gaive X resources immediately
* Inspiration: Gain X Spell cards
* Piety: Temples cost X less to use
* Community Leader: Towns provide X more workers
* Vaults: Pillage cards are much more effective, make enemies strongs
* Outlaws: Enemy building cards spawn more enemies
* Demolition: Area damage destroys X more pieces or armor
* Assassin: Piercing damage does more damage

### Card Types
* Influence Cards: increase the area you can build in. Path start is forced to the nearest point outside influence as influence expands.
* Pillage Cards: place a valueable area for enemies. If near enough the current path, the current path will redirect to pass through it. Otherwise, it will influence future paths when redirecting.
* Enemies passingh through pillage area will get stronger, gain armor/treasure
* Defender Cards: Place a building or unit that will fire at enemies and damage them
* Training Cards: Upgrade a placed unit or building
* Resource Cards: place resources that can be collected
* Spell Cards: single actions that can be used at any time
* Temple Cards: Allows you to spend resources to use abilities
* Town Cards: Provides workers, a resource for all buildings
* Resource Gatherers: a building that collects a specific resource
* Enemy Building Cards: buildings that redirect the path. spawn additional enemies on the path.
* Trap Cards: A defender type that, if the path passes through it, damages enemies on a cooldown. Can be used a certain number of times pers day, requires resources to restock.
* Crossroads Cards: Place a specific point where the the path forks. Creates one or more add

### Damage
Damage modeled very discretely, like Bloons.
Basic Enemies die in one hit. Adding extra hit point visually changes an enemy, and so does damaging them.
A 2 hit enemy has leather or chain armor. Hitting them knocked off the armor, turning them into a one hit enemy.
A 3 hit enemy has plated armor, and turns into a 2 hit enemy.
There are different Damage types.
* Normal: hurts almost everyone for 1 damage of the current layer
* Heavy: the only damage that can destroy heavy armor
* Piercing: If it hits heavy armor, destroys the layer under the heavy armor
* Area: destroys up to a maximum number of pieces of armor on the same layer
* Cursed: If damaging blessed armour, it becomes normal armour and does not regenerate.

### Armour
Armour comes in layers and types. A layer of armor has a number of pieces that are removed to show the damage status.
Armor Types:
* Normal: damaged by any type.
* Heavy: can only be damaged by heavy damage
* Blessed: If damaged becomes normal armour instead. Become blessed after a cooldown.
* Melts: Damages the layer below if destroyed by fire.
* Conducts Electricity: Electric damage peirces to first layer that does not conduct electricity.
* Metal: Melts, conducts electricity

### Traits
Enemies can have traits.
* Frozen: takes extra damage from fire. Can not be slowed.
* Burning: all attacks are fire. Dies instantly to water.
* Flesh: Dies instantly to everything.
* Electric: all attacks are electricity, dies instantly to water.