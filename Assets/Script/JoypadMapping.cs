using UnityEngine;
using System;

//http://wiki.unity3d.com/index.php?title=Xbox360Controller
//http://wiki.etc.cmu.edu/unity3d/index.php/Joystick/Controller

public enum AxesMapping
{
	/* 
	 * Axes values are one less than the ones in the image on the Unify Community,
	 * because I made them 0-based in the Input Manager:
	 * 
	 * X Axis = _Axis0
	 * Y Axis = _Axis1
	 * 3rd Axis = _Axis2
	 * 4th Axis = _Axis3
	 * etc.
	 * 
	 */

	#if UNITY_STANDALONE_WIN
	LEFT_X_AXIS = 0,
	LEFT_Y_AXIS = 1,
	RIGHT_X_AXIS = 3,
	RIGHT_Y_AXIS = 4,

	TRIGGER = 2, //corresponds to both triggers, values are (-1 to 0) and (0 to 1)

    DPAD_X = 5,
    DPAD_Y = 6
	#endif

	#if UNITY_STANDALONE_OSX
	LEFT_X_AXIS = 0,
	LEFT_Y_AXIS = 1,
	RIGHT_X_AXIS = 2,
	RIGHT_Y_AXIS = 3,

	LEFT_TRIGGER = 4,
	RIGHT_TRIGGER = 5
	#endif

	#if UNITY_STANDALONE_LINUX
	LEFT_X_AXIS = 0,
	LEFT_Y_AXIS = 1,
	RIGHT_X_AXIS = 3,
	RIGHT_Y_AXIS = 4,

	LEFT_TRIGGER = 2,
	RIGHT_TRIGGER = 5	

	DPAD_X = 6,
	DPAD_Y = 7
	#endif
}

public enum ButtonMapping
{
	#if UNITY_STANDALONE_WIN
	BUTTON_A = 0,
	BUTTON_B = 1,
	BUTTON_X = 2,
	BUTTON_Y = 3,

	BUTTON_LEFT_BUMPER = 4,
	BUTTON_RIGHT_BUMPER = 5,

	LEFT_THUMB_CLICK = 8,
	RIGHT_THUMB_CLICK = 9,

	BUTTON_BACK = 6,
	BUTTON_START = 7,
	BUTTON_XBOX = 15
	#endif
	
	#if UNITY_STANDALONE_OSX
	BUTTON_A = 16,
	BUTTON_B = 17,
	BUTTON_X = 18,
	BUTTON_Y = 19,

	BUTTON_LEFT_BUMPER = 13,
	BUTTON_RIGHT_BUMPER = 14,

	LEFT_THUMB_CLICK = 11,
	RIGHT_THUMB_CLICK = 12,

	BUTTON_BACK = 10,
	BUTTON_START = 9,
	BUTTON_XBOX = 15,

	DPAD_UP = 5,
	DPAD_DOWN = 6,
	DPAD_LEFT = 7,
	DPAD_RIGHT = 8
	#endif
	
	#if UNITY_STANDALONE_LINUX
	BUTTON_A = 0,
	BUTTON_B = 1,
	BUTTON_X = 2,
	BUTTON_Y = 3,

	BUTTON_LEFT_BUMPER = 4,
	BUTTON_RIGHT_BUMPER = 5,

	LEFT_THUMB_CLICK = 9,
	RIGHT_THUMB_CLICK = 10,

	BUTTON_BACK = 6,
	BUTTON_START = 9,
	//BUTTON_XBOX = , //Missing?
	#endif	
}