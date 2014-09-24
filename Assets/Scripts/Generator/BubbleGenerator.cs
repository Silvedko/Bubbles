using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleGenerator : MonoBehaviour 
{
	public List <GameObject> prefabs = null;
	static int objCounter = 0;
	NotificationCenter ntfCenter;

	void Start ()
	{
		ntfCenter = NotificationCenter.DefaultCenter;
		ntfCenter.AddObserver (this, GameConstants.onTextureCreated);
	}
	
	void OnTextureCreated () 
	{
		Debug.Log ("OnTextureCreate");
		StartCoroutine (PutBubbleInGameWithDelay (0.5f));
	}

	//Method created or if pool is not empty get objects from pool
	private IEnumerator PutBubbleInGameWithDelay (float delay)
	{
		while (true) 
		{
			yield return new WaitForSeconds (delay);
			if(GameManager.Instance.objectPool.Count == 0)
			{
				CreateBubble ();
			}
			else
			{
				GetBubbleFromPool ();
			}
		}
	}

	private void GetBubbleFromPool ()
	{
		var gO = GameManager.Instance.GetGameObjectFromPool ();
		BubbleController bblController = gO.GetComponent <BubbleController> ();
		int bubbleSize = (int) bblController.textureWidth;
		bblController.isMoving = true;
		gO.transform.position = GetRandomPosition (bubbleSize);

		bblController.InitObject ();		
	}
	
	private void CreateBubble ()
	{
		var bubbleGo = (GameObject)Instantiate (prefabs [Random.Range (0, prefabs.Count)]);
		int bubbleSize = (int) bubbleGo.GetComponent <BubbleController> ().textureWidth;
		bubbleGo.transform.position = GetRandomPosition (bubbleSize);
		bubbleGo.name = bubbleGo.GetComponent <BubbleController> ().textureWidth.ToString () + objCounter;
		objCounter ++;
	}

	//Generate bubble start position
	private Vector3 GetRandomPosition (int size)
	{
		Vector3 startPos;
		float xPos = Random.Range (-1f + (float)size / 100f / 4f, 1f - (float)size / 100f / 4f);// 100 - Default ratio Pixels to Unit
		float yPos = 1f + size / 100f / 2f;
		startPos = new Vector3 (xPos, yPos, 0f);
		return startPos;
	}	
}
