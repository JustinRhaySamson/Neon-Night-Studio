# Neon-Night-Studio

Yok.AI is an action based game focused on making the player feel cool with an emphasis on bosses.

[Full playthrough video](https://www.youtube.com/watch?v=w35qqPDaZG4&ab_channel=MicheleMarcheseAndreu)

## Contents
- Bosses
- Enemies
- Dialogue

## Bosses

Every single boss uses a state machine to work. Each individual attack and each pahse are a different state in the state machine. They have either ranged attacks or melee attacks depending on the distance from the player, and they will choose the attack through either RNG or after a specific amount of attacks already made.

Each boss has close ranged and long ranged moves in both phases. The way they are determined is if the player is inside or outside a trigger that surrounds the boss. If the player is inside, the boss will do closed ranged moves and if it is outside it will do long ranged moves. The boss can pick from a pool of melee and ranged attacks that will pick randomly depending on where the player is. There is one exception to this rule, that is an attack that makes them move o the center of the arena and do a special move. This special move can only be done after a certain amount of attacks are done before. Once the attack is done, the attack counter will reset to 0.

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

