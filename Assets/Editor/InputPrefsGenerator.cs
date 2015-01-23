#pragma warning disable 0168
#pragma warning disable 0219

using UnityEngine;
using UnityEditor;
using System.IO;

public class InputPrefsGenerator : MonoBehaviour
{
	private enum AxisType
	{
		KeyMouseButton = 0,
		MouseMovement,
		JoystickAxis
	}

	[MenuItem ("Custom/InputPreferencesGenerator")]
	private static void GenerateInputPreferences()
	{
		//configuration variables
		int nPlayers = 4;
		int snap = 0; //boolean
		int invert = 0; //boolean

		//axis specific
		int nAxes = 10;
		int axisSensitivity = 1;
		float axisDead = 0.1f;
		int axisGravity = 1;

		//buttons specific
		int nButtons = 20;
		int buttonSensitivity = 1000;
		int buttonDead = 0;
		int buttonGravity = 1000;

		string path = "Assets/Editor/InputManager.asset";
		StreamWriter sw;

		if(File.Exists(path))
		{
			Debug.Log("Input Preferences already exists");
			sw = new StreamWriter(path);
		}
		else
		{
			Debug.Log("Creating Input Preferences");
			sw = File.CreateText(path);
		}

		sw.Write("%YAML 1.1\n" +
			"%TAG !u! tag:unity3d.com,2011:\n" +
			"--- !u!13 &1\nInputManager:\n" +
			"  m_ObjectHideFlags: 0\n" +
		    "  m_Axes:\n");

		//Joystick axes
		for(int p=0; p<nPlayers; p++)
		{
			for(int a=0; a<nAxes; a++)
			{
				string axisName = "Axis";

				sw.WriteLine("  - serializedVersion: 3");
				sw.WriteLine("    m_Name: " + p + "_" + axisName + a);
				sw.WriteLine("    descriptiveName: Player" + p + " " + axisName + a + " (pos)");
				sw.WriteLine("    descriptiveNegativeName: Player" + p + " " + axisName + a + " (neg)");
				sw.WriteLine("    negativeButton:");
				sw.WriteLine("    positiveButton:");
				sw.WriteLine("    altNegativeButton:");
				sw.WriteLine("    altPositiveButton:");
				sw.WriteLine("    gravity: " + axisGravity);
				sw.WriteLine("    dead: " + axisDead.ToString());
				sw.WriteLine("    sensitivity: " + axisSensitivity);
				sw.WriteLine("    snap: " + snap);
				sw.WriteLine("    invert: " + invert);
				sw.WriteLine("    type: " + ((int)AxisType.JoystickAxis).ToString());
				sw.WriteLine("    axis: " + a);
				sw.WriteLine("    joyNum: " + (p+1).ToString());
			}

			//Buttons removed, use GetButton instead
			/*
			for(int b=0; b<nButtons; b++)
			{
				string buttonName = "Button";

				sw.WriteLine("  - serializedVersion: 3");
				sw.WriteLine("    m_Name: " + p + "_" + buttonName + b);
				sw.WriteLine("    descriptiveName: Player" + p + " " + buttonName + b + " (pos)");
				sw.WriteLine("    descriptiveNegativeName: Player" + p + " " + buttonName + b + " (neg)");
				sw.WriteLine("    negativeButton:");
				sw.WriteLine("    positiveButton:");
				sw.WriteLine("    altNegativeButton:");
				sw.WriteLine("    altPositiveButton:");
				sw.WriteLine("    gravity: " + buttonGravity);
				sw.WriteLine("    dead: " + buttonDead);
				sw.WriteLine("    sensitivity: " + buttonSensitivity);
				sw.WriteLine("    snap: " + snap);
				sw.WriteLine("    invert: " + invert);
				sw.WriteLine("    type: " + ((int)AxisType.KeyMouseButton).ToString());
				sw.WriteLine("    axis: " + p);
				sw.WriteLine("    joyNum: " + (p+1).ToString());
			}
			 */
		}

		sw.Close();
	}
}
