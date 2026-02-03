This code was written for a personal game project.
The game is a submarine simulator, with gameplay that blends several games: Barotrauma, DCS World, and Iron Beast.
The project doesn't have much networking code, as the game was originally written as a single-player game.


The project includes:

___

## A system of interactive in-world buttons
All controls are physical objects inside the game world and are operated by the player directly.

    - Interactor.cs         -   Main script for player that interacts with buttons
    - InteracteblePanel.cs  -   Main script for interacteble buttons. inherited in other scripts by being interface
    - WorldJoystic.cs       -   inherited from the InteracteblePanel.cs script
    - WorldLever.cs         -   inherited from the InteracteblePanel.cs script
    - WorldPotentiometer.cs -   inherited from the InteracteblePanel.cs script
    - WorldSwitcher.cs      -   inherited from the InteracteblePanel.cs script
    - WorldTextPanel.cs     -   Script for in game text panel, inherited from default MonoBehavior
    - WorldUpDownButton.cs  -   inherited from the InteracteblePanel.cs script

___

Inventory system and items
In project this system was written more for educational purposes and dont realize well

___

## Basic player movement

    - Walk
    - Jump
    - Crouch
    - Lying
    - Vertical stairs climbing up and down

To this category i added system that prevents player slips from moving object as submarine. Without this player stay on his position when submarine is moving

___

## Physics
Here are few small scripts that based on physics formula

    - ArchimedesForce - A submarine floats only because the volume of water it displaces is equal to its mass.

    If the mass of the submarine is equal to the volume of water it displaces, the submarine stays on same level.

    If the mass of the submarine is greater than the mass of the water it displaces, the submarine begins to sink.

    If the mass of the submarine is less than the mass of the water it displaces, the submarine begins to float.

    - Constants - in here some world constants as:
        - mass of 1^3m of water
        - Viscosity of water
        - sound speed in water

___

## Submarine systems
Most of the submarine's functionality is implemented here: doors, engines, turret consoles, etc.

    - TurretController  -   Takes inputs from world buttons to move and shoot

    - WorldShipController - Takes inputs from world buttons to controll engines, steering, balaste and show information about depth, speed, rotation etc. by using in world text panels.

    - WorldBalasteController - These are cavities that, when filled with water, become heavier, which is why the submarine is controlled vertically.

    - WorldEngineRotor  -   The engine rotates the submarine's propeller, which allows it to control its forward and reverse speed.

    - WorldReactor  -   Generates power for submarine, nothing will work without electricity

___

## Sonar

I've tried writing many different sonar system implementations. None of them replicate the real physics of sonar operation, as that would require enormous computing power. I stopped on this variant of this system.

    - WorldSonar - It works using raycasting. It's more like a camera, as it sends out a large number of rays with a slight deflection, resulting in an image of a predetermined size. For example, 128x128 with an angular resolution of 3 degrees. On the in-game screen, it has a gradient from red (near) to green (far).

___

## Summary.

In project are more scripts or systems, but not all of them are working well, some of them i took from other my projects only for few functions. 


I am not going to continue developing this project because it has many architectural misstakes to fix them i need to re write whole project, so I decided not to continue it. I need to gain experience, ideas, and think through the architecture and everything that will be implemented in the game in advance.
