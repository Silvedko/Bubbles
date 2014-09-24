using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureGenerator : MonoBehaviour 
{
	private int texturesCount = 4;
	private List <Color> colors = null;	
	private int size;
	private NotificationCenter ntfCenter;
	private bool stopNotifications = false;

	void Start ()
	{
		ntfCenter = NotificationCenter.DefaultCenter;
		colors = new List<Color> ();

		InvokeRepeating ("GenerateTexturePack", 1f, 5f );
	}

	void GenerateTexturePack ()
	{
		for (int i = 1; i <= texturesCount; i++) 
		{
			size = (int) Mathf.Pow(2, i+5);		
			StartCoroutine (GenerateTexture (size));
		}
	}

	private IEnumerator GenerateTexture (int textureWidth)
	{
		Debug.Log ("generate COLORS!");
			
		colors.Clear ();
		colors.TrimExcess ();
		colors = new List<Color> ();	
		GameManager.Instance.generatedTextures.Clear ();
		GameManager.Instance.generatedTextures.TrimExcess ();

		var texture = new Texture2D (textureWidth, textureWidth, TextureFormat.ARGB32, false);
		texture = MakeTexture (texture);
		texture.Apply ();

		yield return texture;
		GameManager.Instance.generatedTextures.Add (texture);

		if (GameManager.Instance.generatedTextures.Count == texturesCount && !stopNotifications) 
		{
			ntfCenter.PostNotification (this, GameConstants.onTextureCreated, null);
			stopNotifications = true;
		}
	}
		
	private Texture2D MakeTexture (Texture2D texture)
	{
		int randCol = Random.Range (0, 255);
		for (int i = 0; i < texture.width * texture.height; i++) 
		{
			colors.Add (GetRandomColor (i, randCol));
		}
			
		texture.SetPixels (colors.ToArray());
		texture.Apply();

		return texture;
	}

	private Color GetRandomColor (int counter, int randColor)
	{
		float r = ((randColor / 2 + counter) % 255) / 255f;
		float g = ((randColor * 2 + counter) % 255) / 255f;
		float b = ((randColor + counter) % 255) / 255f;

		return new Color (r, g, b, 1.0f);
	}
}
