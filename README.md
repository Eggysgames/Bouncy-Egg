# Bouncy-Egg
=== Usage ===

You are free to use all code and design, but I only ask that you use your <b>own artwork and animations</b> I have left my own in there to be used for learning purposes only for you to replace later.

=== Play === 

This game is available to play here and many other places online >

<b>WebGL</b> - https://eggysgames.com/bouncyegg

<b>Android</b> - https://play.google.com/store/apps/details?id=com.EggysGames.BouncyEgg

<b>Run your own version</b> - Upload the contents of Builds/WebGL to a working website/page/localhost

The game is quite simple, get the egg in the basket using a physics bouncing egg. The game makes use of Unitys built in physics engine to bouce the egg off springs. It plays like a 2D physics game would expect with a few custom coded changes in some classes to compensate for issues. You can use this to make your own physics drop game.

=== Developer Information === 

Made for Unity version 2020.3.38f1 (Opening in older versions can cause unexpected errors)

The full source code for Bouncy Egg released by Eggy's Games (Bradley Erkelens)

You will find all the C# coding under assets/code

You will find all available sprites under assets/sprites

The project makes use of dynamic shadows being cast, URP and basic physics. 

Developed using Unity by Eggy's Games (Bradley Erkelens). It uses a simple coding style of splitting drag and droppable classes custom coded by me. 

=== Coding === 

You will find most objects all link back to the Main.cs class. This handles everything and communicates with all objects. This handles a variable for detecting if the egg has been dropped with GameIsPlaying() to check if true then the update can keep running.
