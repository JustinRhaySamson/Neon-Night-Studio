# Neon-Night-Studio

Yok.AI is an action based game focused on making the player feel cool with an emphasis on bosses.

[Full playthrough video](https://www.youtube.com/watch?v=w35qqPDaZG4&ab_channel=MicheleMarcheseAndreu)
[Itch.io project](https://neonnightstudio.itch.io/neon-night)

## Contents
- Bosses
- Enemies
- Time stop

## Bosses

Every single boss uses a state machine to work. Each individual attack and each pahse are a different state in the state machine. They have either ranged attacks or melee attacks depending on the distance from the player, and they will choose the attack through either RNG or after a specific amount of attacks already made.

Each boss has close ranged and long ranged moves in both phases. The way they are determined is if the player is inside or outside a trigger that surrounds the boss. If the player is inside, the boss will do closed ranged moves and if it is outside it will do long ranged moves. The boss can pick from a pool of melee and ranged attacks that will pick randomly depending on where the player is. There is one exception to this rule, that is an attack that makes them move o the center of the arena and do a special move. This special move can only be done after a certain amount of attacks are done before. Once the attack is done, the attack counter will reset to 0.

- Flow Chart
![Flow_Chart](https://github.com/JustinRhaySamson/Neon-Night-Studio/blob/main/Assets/Programming/Github%20Images/Flow_Chart.png)

- Reiju - Oni - First Boss

Phase 1:

![Phase 1](https://github.com/JustinRhaySamson/Neon-Night-Studio/blob/main/Assets/Programming/Github%20Images/Boss1%20Yok.AI.PNG)

Phase 2: 

![Phase 2](https://github.com/JustinRhaySamson/Neon-Night-Studio/blob/main/Assets/Programming/Github%20Images/Boss1_2%20Yok.AI.PNG)
 
- Tenshin - Tengu - Second Boss

![Phase 1](https://github.com/JustinRhaySamson/Neon-Night-Studio/blob/main/Assets/Programming/Github%20Images/Boss2%20Yok.AI.PNG)

Phase 2:

![Phase_2](https://github.com/JustinRhaySamson/Neon-Night-Studio/blob/main/Assets/Programming/Github%20Images/Boss2_2.png)
  
- Yuki - Third Boss

![Phase 1](https://github.com/JustinRhaySamson/Neon-Night-Studio/blob/main/Assets/Programming/Github%20Images/Boss3%20Yok.AI.PNG)

## Enemies

There are 3 diferent enemies in the game, 2 melee enemies and 1 ranged one. All of the enemies use navmesh to find the player, but they all stop at one point. The melee enemies stop when the player enters a trigger around them and then do the attack animation, they will resume movent once the player gets out of the hitbox. The main difference between them is that one attacks forward and the other attacks around them. The ranged enemy uses a similar system in wich it will stop when the player eters a trigger arround it, the difference is that the trigger is much bigger than the melee one. They will doan animation that at at one point will make them shoot a bullet. When the player exits the trigger they will resume movement.

## Time Stop

The timestop mechanic is managed by 1 single script that will take information from every interactable entity in the room. It will obtain this information via them adding themselves to arrays upon being activated and will remove themselves after death. What happens during timestop is, for the most part, setting animation speed of every enemy to 0, deactivating the navmesh and setting the force all the buults to 0. Additionally, it will deactivate every melee hitbox, but not the bullets. Once timestop ends, all of the values will be reset. It does this through foreach loops for each of the interactable objects in both activation and deactivation.
