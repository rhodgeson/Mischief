# Mischief

2D platformer video game in progress for Video Game Design class. I am acting as project lead, delegating tasks, managing productivity, and planning gameplay and mechanics according to timeline.

All Scripts, Scenes, and Prefabs listed are ones that I have mostly or completely worked on myself.

Some detailed implementation information:

Player: Player is created as a Prefab titled Player
Movement: PlayerMovement.cs script attached to player manages player movement.
Animation: Currently there are animations created for FlyLeft, FlyRight, IdleLeft, and IdleRight. The only animations visible to the user at IdleLeft and IdleRight which flip back and forth as the player moves.
Abilities: Player's fire ability and eat ability are managed in script PlayerBehaviors.cs. If the player object is colliding with a villager and one of the abilities is called, it calls another method within the villager it is colliding with in order to trigger the reaction of the villager object to the ability.


NPC's
The NPC's in the game are known as Villagers and are created as a Villager prefab.
The VillagerController.cs script is attached to every Villager in the game and holds two methods, eaten() and fired(), which will contain the object's reactions to the player's eat and fire abilities. Currently both methods have a console print statement for testing purposes, and the eaten() method destroys the object so that the Villagers disappear when they are eaten by the player.
The VillagerMovement.cs script is attached to whichever villagers we will want to be moving back and forth. It stores a distance variable which can be different for every villager and utilizes Unity's Mathf.PingPong function to cause the villager object to move uniformly back and forth a certain distance.

Dialogue Management
A very basic dialogue management system which triggers a dialogue box whenever player comes close to certain NPC's.
A dialogue box is triggered when player runs over a sign board. The dialogue box art is assigned to a GameObject named "DialogueBox" and the text within the dialogue box is provided in the "Text" UI under the "DialogueBox" GameObject. This dialogue box is triggered by "Sign.cs" script which is assigned to the "Sign" GameObject.
A dialogue box is also triggered when the player comes close to first villager. The dialogue box art is assigned to a GameObject named "DBVillager" and the text within the dialogue box is provided in the "DBText" UI under the "DBVillager" GameObject. This dialogue box is triggered by "Villager.cs" script which is assigned to the "Villager1".
This is accomplished by detecting a collision with a NPC. If a collision is detected, the "playerInRange" is set to "true", and "DialogueBox" and "DBVillager" are set to active which display the dialogue text.
  
Main Quest Management
The script MainQuestManager.cs is attached to the player object and has 3 integer variables, level1Q, level2Q, and level3Q which hold the number of quest tokens collected for each level. These values are updated in the methods addLevel1(), addLevel2(), and addLevel3() which all add 1 to their respective variables and are called from the QuestToken.cs script.
The script QuestToken.cs is attached to any quest token object. The quest token object is what needs to be collected for main level quest, and token objects for each level are tagged "Level1Token", "Level2Token", and "Level3Token" respectively. In the script, if the object the script is attached to is collided with by the player, the script notes which level the token is for based on its tag and calls one of the addLevel methods from MainQuestManager.cs to add 1 to that specific level tracking variable in the MainQuestManager.cs script.
