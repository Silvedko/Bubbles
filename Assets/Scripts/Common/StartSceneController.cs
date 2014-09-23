using UnityEngine;
using System.Collections;

public class StartSceneController : MonoBehaviour 
{
	NotificationCenter ntfCenter = null;
	int notificationCounter = 0;

	void Start () 
	{
		ntfCenter = NotificationCenter.DefaultCenter;
		ntfCenter.AddObserver (this, GameConstants.onTextureDownloading);

		GameManager.Instance.linkCounter = 0;
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
		if (notificationCounter == 4) 
		{
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Start Game")) {
					Application.LoadLevel (GameConstants.gameSceneName);
			}
		}
		else
		{
			GUIStyle myStyle = new GUIStyle();
			myStyle.normal.textColor = Color.cyan;
			myStyle.fontSize = 35;

			int tempLoadingValue = 4 - notificationCounter;
			GUI.Label((new Rect (Screen.width / 2 , Screen.height / 2, 200, 100)), tempLoadingValue.ToString() + "...", myStyle);
	    }
	}

	void OnLoadComplete (NotificationCenter.Notification notification)
	{
		notificationCounter++;
		Destroy (notification.goSender);
	}

	void OnDestroy ()
	{
		if (ntfCenter != null && !ntfCenter.Equals (null)) 
		{
			ntfCenter.RemoveObserver (this, GameConstants.onTextureDownloading);
		}
	}
}
