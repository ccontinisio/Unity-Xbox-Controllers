using UnityEngine;
using System.Collections;
using System;

public class InputManager
{
	int nOfPlayers = 4;

	/* 
	 * Use the update to cycle through the available players, and retrieve the input one by one.
	 * Optionally, you can do it in the FixedUpdate, or you can cache input and process it in the FixedUpdate
	 * if it's meant to be controlling physics.
	 * 
	 */
	private void Update()
	{
		for(int p = 0; p < nOfPlayers; p++)
		{
			ProcessJoypadInput(p);
		}
	}


	/* 
	 * Use a function like this to process inputs for each player.
	 * You can use Delegates, Actions, or direct function calls, what you prefer!
	 * 
	 * Just use GetAxisValue() to retrieve an axis value by passing the desired enum (check JoypadMapping file > AxesMapping enum).
	 * e.g. AxesMapping.LEFT_X_AXIS for the horizontal axis of the left stick
	 * 
	 * If you need a normal button, just use GetButtonDown, GetButton, or GetButtonUp and pass the right enum.
	 * e.g. ButtonMapping.BUTTON_A for the A button
	 * 
	 */
	private void ProcessJoypadInput(int joyNumber)
	{
		//Example of how to retrieve the horizontal axis
		if(GetAxisValue(joyNumber, AxesMapping.LEFT_X_AXIS) != 0f)
		{
			//perform action
			int readablePlayerNumber = joyNumber + 1;
			Debug.Log("Player " + readablePlayerNumber + " is tilting the left stick horizontally by " + GetAxisValue(joyNumber, AxesMapping.LEFT_X_AXIS));
		}

		//Example of how to retrieve a button
		if(GetButtonDown(joyNumber, ButtonMapping.BUTTON_XBOX))
		{
			//perform action
			int readablePlayerNumber = joyNumber + 1;
			Debug.Log("Player " + readablePlayerNumber + " pressed the Xbox Button");
		}

		// The right triggers require a specific treatment on Windows and Mac,
		// because on Windows they're mapped to the same axis (the 3rd)

#if UNITY_STANDALONE_WIN
        if (GetAxisValue(joyNumber, AxesMapping.TRIGGER) < -0.1f)
        {
        	//perform action
        }
        if (GetAxisValue(joyNumber, AxesMapping.TRIGGER) > 0.1f)
        {
            //perform action
        }
        if (GetButtonDown(joyNumber, ButtonMapping.BUTTON_RIGHT_CLICK))
        {
            //perform action
        }
#elif UNITY_STANDALONE_OSX
		if(GetAxisValue(joyNumber, AxesMapping.RIGHT_TRIGGER) > .1f)
		{
			//perform action
		}
		if(GetAxisValue(joyNumber, AxesMapping.LEFT_TRIGGER) > .1f)
		{
			//perform action
		}
#endif

	}
	

#region AxisHelpers
	public static float GetAxisValue(int playerNumber, AxesMapping axisName)
	{
		return Input.GetAxis(playerNumber + "_Axis" + (int)axisName);
	}
#endregion



#region ButtonHelpers
	public static bool GetButtonDown(int playerNumber, ButtonMapping buttonName)
	{
		return Input.GetKeyDown(BToCode(playerNumber, buttonName));
	}

	protected bool GetButton(int playerNumber, ButtonMapping buttonName)
	{
		return Input.GetKey(BToCode(playerNumber, buttonName));
	}

	protected bool GetButtonUp(int playerNumber, ButtonMapping buttonName)
	{
		return Input.GetKeyUp(BToCode(playerNumber, buttonName));
	}

	//converts a ButtonMapping in the right KeyCode enum
	protected static KeyCode BToCode(int playerNumber, ButtonMapping buttonName)
	{
		//This is because for Unity Player0 is the owner of Joypad1
		playerNumber++; //1-based

        return (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button" + (int)buttonName);
	}
#endregion

}