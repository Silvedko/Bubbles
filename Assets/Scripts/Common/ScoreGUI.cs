using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour 
{
	int scoreWidth = 100;
	int scoreHeight = 50;
	
	void OnGUI () 
	{
		GUIStyle myStyle = new GUIStyle();
		myStyle.normal.textColor = Color.cyan;
		myStyle.fontSize = 35;

		GUI.Label (new Rect(0f, Screen.height - scoreHeight, scoreWidth, scoreHeight), GameManager.Instance.gamePoints.ToString(), myStyle);
	}
}
