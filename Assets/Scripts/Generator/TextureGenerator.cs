using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureGenerator : MonoBehaviour 
{
	public BubbleController bblCntroller;
	public Shader maskShader;

	private Sprite gOSprite; 
	private Texture2D generatedTexture;
	private int textureWidth;
	private SpriteRenderer sRenderer;
	private List <Color> colors = null;

	NotificationCenter ntfCenter;

	void Awake ()
	{
		ntfCenter = NotificationCenter.DefaultCenter;
		ntfCenter.AddObserver (this, GameConstants.onBubbleCreated);
		sRenderer = gameObject.GetComponent<SpriteRenderer> ();
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
		renderer.material = CreateNewMaterial ();
		renderer.material.mainTexture = generatedTexture;
		sRenderer.material.SetFloat ("_Cutoff", 0.5f);
		if(sRenderer.material.HasProperty("_Mask"))
			sRenderer.material.SetTexture ("_Mask", (Texture) GetMaskFromSize (textureWidth));
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

	private Material CreateNewMaterial ()
	{
		return new Material (maskShader);
	}
}
