using UnityEngine;
using System.Collections;

public class StartSceneController : MonoBehaviour 
{
	NotificationCenter ntfCenter = null;

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
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Start Game")) 
		{
			Application.LoadLevel(GameConstants.gameSceneName);
		}
	}

	void OnLoadComplete (NotificationCenter.Notification notification)
	{
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
