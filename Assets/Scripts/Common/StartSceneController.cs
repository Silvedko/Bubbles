using UnityEngine;
using System.Collections;

public class StartSceneController : MonoBehaviour 
{
	void Start () 
	{
		GameManager.Instance.linkCounter = 0;
		Debug.Log (GameConstants.bubbleLinks.Length);
		for (int i = 0; i < GameConstants.bubbleLinks.Length; i++) 
		{
			GameObject gOLoader = new GameObject("ImageLoader " + i);
			var iLoader = gOLoader.AddComponent <ImageDownloader>();
			iLoader.linkCounter = GameManager.Instance.linkCounter;
			GameManager.Instance.linkCounter ++;
		}
	}
	
	void OnGUI () 
	{
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Start Game")) 
		{
			Application.LoadLevel(GameConstants.gameSceneName);
		}
	}
}
