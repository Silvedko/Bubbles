using UnityEngine;
using System.Collections;

public class TextureGenerator : MonoBehaviour {

	public Sprite gOSprite;
	private Texture2D generatedTexture;
	int textureWidth;

	void Start () 
	{
		gOSprite = gameObject.GetComponent<SpriteRenderer> ().sprite;
		textureWidth = gOSprite.texture.width;

		GenerateTexture (gOSprite.texture.width);

//		StartThreads ();

		gOSprite = Sprite.Create (generatedTexture, new Rect (0f, 0f, 32f, 32f), Vector2.zero);

//		gOSprite.name = "SmallIcon" ;

		gameObject.GetComponent<SpriteRenderer> ().sprite = gOSprite;
		renderer.material.mainTexture = gOSprite.texture;
	}




	private void StartThreads()
	{
		for (int i = 0; i < gOSprite.texture.height; i++)
		{
			System.Threading.ThreadStart pts = new System.Threading.ThreadStart(ThreadedColorCopy);
			System.Threading.Thread workerForOneRow = new System.Threading.Thread(pts);
			workerForOneRow.Start(i);
		}
	}

	private void ThreadedColorCopy()
	{
		GenerateTexture (textureWidth);
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
		for (int i = 0; i < texture.width; i++)
			for (int j = 0; j < texture.height; j++) 
			{
				texture.SetPixel (i, j, new Color (50f / 255f, (i * 255 / texture.width) / 255f, (j * 255 / texture.width) / 255f, 255f));
			}
			texture.Apply();

		return texture;
	}

	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
