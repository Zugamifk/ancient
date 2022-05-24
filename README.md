# Ancient

A repo to toying with architecture.

## Core
Contains any utilities and tools that are shared across all other assemblies.

## Data
Contains ScriptableObjects and any systems used for loading external config data.

## Commands
The main method of communication from the View systems to the rest of the game. Most player input should go through here.

## Systems
A set of assemblies for complicated tasks than can't  be contained in a single command script, or need behaviours that need to be shared between tools.

## Models
Data classes representing the game state. 

## Unity
The "Unity" side of things. As much as possible, all MonoBehaviours should be in this assembly.

## ViewModels
A set of read-only interfaces inplements by clsses in Model. Referenced by the  Unity assembly when updating GameObject state.
