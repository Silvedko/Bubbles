using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour {

	public Bubble bubble;
	public Sprite sprite;

	float speed = 0.01f;
	bool isMoving = true;

	void Start () 
	{

		bubble = SetBubbleObject() ;
		StartCoroutine (MonsterMove ());
	}
	
	Bubble SetBubbleObject () 
	{
		GameConstants.GameObjectSizes textureSize;
		textureSize = (GameConstants.GameObjectSizes) sprite.texture.width;
		return ChooseObjFromSize(textureSize);
	}

	Bubble ChooseObjFromSize (GameConstants.GameObjectSizes size)
	{
		switch (size) 
		{
			case GameConstants.GameObjectSizes.Small :
				return new SmallBubble {yPos = gameObject.transform.position.y};
				break;
			case GameConstants.GameObjectSizes.Medium :
				return new Mediumbubble {yPos = gameObject.transform.position.y};
				break;
			case GameConstants.GameObjectSizes.Large :
				return new LargeBubble {yPos = gameObject.transform.position.y};
				break;
			case GameConstants.GameObjectSizes.ExtraLarge :
				return new ExtraLargeBubble {yPos = gameObject.transform.position.y};
			break;
		}
	}

	IEnumerator MonsterMove ()
	{
		while (isMoving) 
		{
			yield return new WaitForSeconds (0.05f);
			if(gameObject.transform.position.y <= -1.4f)
				isMoving = false;
			bubble.Move (gameObject, speed);
		}
	}

	void OnBecameInvisible ()
	{
		Debug.Log ("INVISIBLE!!!!");
	}
}
