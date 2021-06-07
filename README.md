# Survivor Mode #

![alt](https://github.com/devkiloton/SurvivorMode/blob/master/SurvivorMode/Assets/Samples/GithubImages/Gameplay.png)

- Survivor Mode is basically a game where the protagonist tries to survive after a zombie apocalypse as long as he can. To do that, you will need to control him and kill the biggest number of zombies as you can!
- While you stil alive medic kits are dropped for you survive as long as you can!
- Be careful with the bosses

# Where can i play?

- [Play Survivor Mode Here, you just need a potato to run it!](https://devkiloton.itch.io/survivor-mode)

# Why? 

- This project is my first game and it is a result of some months studying the logic of programming, C#,  Unity Framework and the Unity Engine. Here the objective was to do a simple game to introduce me in the world of 3D game developing e apply my C# knowledge, trying to respect the good pratices of programming!

- Also, you can use this project as you wish, be for study or commercial use. Just be careful with the arts, the sounds and their royalties! 

- Any ideas or suggestions:

  Email-me: dev.kiloton@gmail.com
  
# How does it really works?
- The game has 15 zombie generators.

  ![alt](https://github.com/devkiloton/SurvivorMode/blob/master/SurvivorMode/Assets/Samples/GithubImages/2021-06-06%20(16).png)

- Each zombie is generated in a sphere of 3 units of radius.
- Each sphere has a limit of zombies alive that after 10 seconds add one more zombie to the limit.
- The generator just can generate new zombies if the Player is far from 20 units, it happens for a better user experience. In this way, zombies are not generated on the Player field of view.

  ![alt](https://github.com/devkiloton/SurvivorMode/blob/master/SurvivorMode/Assets/Samples/GithubImages/2021-06-06%20(19).png)
  
- The zombies just can follow the player to attack if the distance between the zombie and the Player is less than 20 units, once every 15 seconds this distance is expanded in 10 units.
- In this project i used AI through the NavMesh in Unity. The scene "game" has a mesh where the boss knows your place and the fastest way to get where you are, differently from zombies that just follow your position and can stop if collide with objects in the scene.
  ![alt](https://github.com/devkiloton/SurvivorMode/blob/master/SurvivorMode/Assets/Samples/GithubImages/2021-06-06%20(18).png)
  
# Check the scripts
- [Click here](https://github.com/devkiloton/SurvivorMode/tree/master/SurvivorMode/Assets/C%23%20scripts)

# Final considerations
- Dedicated to the nights i did not slept because i was addicted to code this game and solve the bugs.
- Have a nice day! 
