using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureGenerator : MonoBehaviour 
{
	public BubbleController bblCntroller;

	private Sprite gOSprite; 
	private Texture2D generatedTexture;
	private int textureWidth;
	private List <Color> colors = null;

	NotificationCenter ntfCenter;

	void Awake ()
	{
		ntfCenter = NotificationCenter.DefaultCenter;
		ntfCenter.AddObserver (this, GameConstants.onBubbleCreated);
	}

	void OnBubbleCreated () 
	{
		Init ();
	}

	void OnDisable ()
	{
		Destroy (generatedTexture);
		Destroy (gOSprite);
		colors.Clear();
		colors.TrimExcess ();
	}

	void OnDestroy ()
	{
		if(ntfCenter != null && !ntfCenter.Equals (null))
			ntfCenter.RemoveObserver (this, GameConstants.onBubbleCreated);
	}

	void Init ()
	{
		colors = new List<Color> ();
		textureWidth = (int) bblCntroller.textureWidth;
		GenerateTexture (textureWidth);
		
		gOSprite = Sprite.Create (generatedTexture, new Rect (0.0f, 0.0f, textureWidth, textureWidth), new Vector2(0.5f, 0.5f));
		
		gameObject.GetComponent<SpriteRenderer> ().sprite = gOSprite;
		renderer.material.mainTexture = generatedTexture;
		gameObject.GetComponent<SpriteRenderer> ().material.SetFloat ("_Cutoff", 0.5f);
		if(gameObject.GetComponent<SpriteRenderer> ().material.HasProperty("_Mask"))
			gameObject.GetComponent<SpriteRenderer> ().material.SetTexture ("_Mask", (Texture) GetMaskFromSize (textureWidth));
	}

	private Texture2D GetMaskFromSize (int size)
	{
		Texture2D tempTexture = null;
		foreach (var neededTexture in GameManager.Instance.textures) 
		{
			if (neededTexture.width == size)
				tempTexture = (Texture2D) neededTexture;
		}
		return tempTexture;
	}
	

	private void GenerateTexture (int textureWidth)
	{
		var texture = new Texture2D(textureWidth, textureWidth, TextureFormat.ARGB32, false);
		texture = MakeTopTexture (texture);
		
		texture.Apply();
		generatedTexture = texture;
	}
		
	private Texture2D MakeTopTexture (Texture2D texture)
	{
		int randColR = Random.Range (1, 255);
		int randColG = Random.Range (1, 255);
		int randColB = Random.Range (1, 255);

		for (int i = 0; i < texture.width * texture.height; i++) 
		{
			colors.Add (GetRandomColor (i, randColR, randColG, randColB));
		}
			
		texture.SetPixels (colors.ToArray());
		texture.Apply();

		return texture;
	}

	private Color GetRandomColor (int counter, int randColorR, int randColorG, int randColorB)
	{
		float r = ((randColorR + counter) % 255) / 255f;
		float g = ((randColorG + counter) % 255) / 255f;;
		float b = ((randColorB + counter) % 255) / 255f;;

		return new Color (r, g, b, 1.0f);
	}
}
