using UnityEngine;
using System.Collections;

public class ImageDownloader : MonoBehaviour 
{
	public Texture2D textur;
	public int linkCounter;
	NotificationCenter ntfCenter = null;
	
	public void Start()
	{
		ntfCenter = NotificationCenter.DefaultCenter;
		StartCoroutine (DownloadTexture (GameConstants.bubbleLinks[linkCounter]));
	}

	IEnumerator DownloadTexture(string url) 
	{
		WWW www = new WWW(url);
		yield return www;

		textur = www.texture;
		textur.name = ((GameConstants.GameObjectSizes)textur.width).ToString ();
		GameManager.Instance.textures.Add(textur);
		ntfCenter.PostNotification (this, GameConstants.onTextureDownloading, gameObject);
	}
}
