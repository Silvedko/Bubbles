using UnityEngine;
using System.Collections;

public class TextureController : MonoBehaviour 
{
	SpriteRenderer sRenderer = null;
	BubbleController bblController = null;
	Texture2D objTexture = null;
	int textureWidth = 0;
//	NotificationCenter ntfCenter = null;

	void Awake ()
	{
//		ntfCenter = NotificationCenter.DefaultCenter;
//		ntfCenter.AddObserver (this, GameConstants.onTextureCreated);
	}

	void Start ()
	{
		sRenderer = gameObject.GetComponent <SpriteRenderer> ();
		bblController = gameObject.GetComponent <BubbleController> ();
		textureWidth = (int) bblController.textureWidth;
		SetTextureAndMask ();
		SetMask();
	}
	

	void SetTextureAndMask ()
	{
		foreach (var texture in GameManager.Instance.generatedTextures)
			if (texture.width == textureWidth) 
			{
				objTexture = (Texture2D) texture;	
				SetTexture (objTexture);
			}
	}


	private void SetTexture (Texture2D texture)
	{
		sRenderer.sprite = Sprite.Create (texture, new Rect (0f, 0f, texture.width, texture.width), new Vector2 (0.5f, 0.5f));
		renderer.material.mainTexture = texture;
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


	void SetMask ()
	{
		if (sRenderer.material.HasProperty ("_Mask"))
			sRenderer.material.SetTexture ("_Mask", (Texture)GetMaskFromSize (textureWidth));
	}

	void OnDisable ()
	{
//		Destroy (sRenderer.sprite);
//		Destroy (sRenderer.material.mainTexture);
	}
}
