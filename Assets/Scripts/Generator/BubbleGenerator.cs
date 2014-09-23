using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleGenerator : MonoBehaviour 
{
	public List <GameObject> prefabs = null;
	static int objCounter = 0;

	void Start () 
	{
		StartCoroutine (PutBubbleInGameWithDelay (0.5f));
	}



	private IEnumerator PutBubbleInGameWithDelay (float delay)
	{
		while (true) 
		{
			yield return new WaitForSeconds (delay);
			if(GameManager.Instance.objectPool.Count == 0)
			{
//				Debug.Log ("Create Object");
				CreateBubble ();
			}
			else
			{
//				Debug.Log ("GetFromPool");

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

		Debug.Log ( " Name = " + gO.name + " position = " + gO.transform.position);

		bblController.ReInitObject ();		
	}
	
	private void CreateBubble ()
	{
		var bubbleGo = (GameObject)Instantiate (prefabs [Random.Range (0, prefabs.Count)]);
		int bubbleSize = (int) bubbleGo.GetComponent <BubbleController> ().textureWidth;
		bubbleGo.transform.position = GetRandomPosition (bubbleSize);
		bubbleGo.name = bubbleGo.GetComponent <BubbleController> ().textureWidth.ToString () + objCounter;
		objCounter ++;
//		Debug.Log ( " Name = " + bubbleGo.name + " position = " + bubbleGo.transform.position);
	}

	private Vector3 GetRandomPosition (int size)
	{
		Vector3 startPos;
		float xPos = Random.Range (-1f + (float)size / 100f / 2f, 1f - (float)size / 100f / 2f);// 100 - Default ratio Pixels to Unit
		float yPos = 1f + size / 100f / 2f;
		startPos = new Vector3 (xPos, yPos, 0f);
		return startPos;
	}	
}
