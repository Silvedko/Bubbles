using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoSingleton <GameManager>
{
	//Dropped bubbles
	private int bubbleDropped;
	public int BubbleDropped
	{
		get {return bubbleDropped;}
		set {bubbleDropped = value;}
	}
	
	public List<GameObject> objectPool;

	public void AddGameObjectToPool (GameObject go)
	{
		objectPool.Add (go);

		go.SetActive (false);
	}

	public GameObject GetGameObjectFromPool ()
	{
		var myGo = objectPool [0];
		objectPool.RemoveAt (0);
		myGo.SetActive (true);

		return myGo;
	}

	//Textures from www
	public List <Texture> textures = null;
	
	//Counter for url strings for www.textures in GameConstants.cs
	public int linkCounter = 0;

	// Textures from Texture generator
	public List <Texture2D> generatedTextures = null;

	public int gamePoints = 0;

	//Method increase game score
	public void IncreasePoints (int points)
	{
		gamePoints += points;
	}

	public void DecreasePoints (int points)
	{
		//If need to implement penalty's
	}
	

	public override void Init () 
	{
		DontDestroyOnLoad (this);
		BubbleDropped = 0;
		objectPool = new List<GameObject> ();
		textures = new List<Texture> ();
		generatedTextures = new List<Texture2D> ();
	}

	void OnLevelWasLoaded (int level)
	{
		// Level 1 - is game scene, need to clear data when leave from this scene
		if(level != 1)
		{
			objectPool.Clear ();
			objectPool.TrimExcess ();
			textures.Clear ();
			textures.TrimExcess ();
		}
	}
}
