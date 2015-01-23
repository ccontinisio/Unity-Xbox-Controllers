Unity Project for 4 Xbox Controllers
====================================

Pre-configured Unity project for using 4 Xbox pads on any desktop platform.  
  
Configuring many Xbox pads can be a hassle if you have to do it in the InputManager, and most of the time you're working on Windows but you'd like people who try your game after a game jam to be able to play it on Mac or Linux. This project tries to create a shortcut to solve these problems, while still not imposing any coding style on the programmer.  
  
The project includes:
* The InputManager already configured with 40 axes, 10 per each controller
* An InputManager.cs class to poll the 4 controllers (GetAxis, GetButton, GetButtonDown and GetButtonUp)
* A JoypadMapping.cs class with user-friendly enums for buttons and axes
* Platform-dependent compilation for Win, Mac and Linux
* An InputPrefsGenerator.cs helper Editor script in case you want to generate another InputManager.asset

I tried to keep the code is as slim as possible, so you can use the input I prepared together with your preferred coding style. More in-depth instructions are inside the InputManager class.  
For a complete list of the mappings used, check out these images on the [Unify Community Wiki] (http://wiki.unity3d.com/index.php?title=Xbox360Controller)  
  
Enjoy!

Made by **Ciro Continisio** [@ccontinisio] (http://www.twitter.com/ccontinisio)  
from existing code used in [@FatalExcError] (http://twitter.com/fatalexcerror)  
for [Global Game Jam 2015] (http://globalgamejam.org)
