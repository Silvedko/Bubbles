using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour 
{

	public Bubble bubble;
	public Sprite sprite;

	float speed = 0.01f;
	bool isMoving = true;

	void Start () 
	{


		sprite = gameObject.GetComponent <SpriteRenderer> ().sprite;
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
		Bubble bubble;
		switch (size) 
		{
			case GameConstants.GameObjectSizes.Small :
				bubble = new SmallBubble {yPos = gameObject.transform.position.y};
				break;
			case GameConstants.GameObjectSizes.Medium :
				bubble = new MediumBubble {yPos = gameObject.transform.position.y};
				break;
			case GameConstants.GameObjectSizes.Large :
				bubble = new LargeBubble {yPos = gameObject.transform.position.y};
				break;
			case GameConstants.GameObjectSizes.ExtraLarge :
				bubble = new ExtraLargeBubble {yPos = gameObject.transform.position.y};
				break;
			default: 
				bubble = new Bubble ();
				break;
		}
		return bubble;
	}

	IEnumerator MonsterMove ()
	{
		while (isMoving) 
		{
			yield return new WaitForSeconds (0.01f);
			if(gameObject.transform.position.y <= -1.0f - sprite.texture.width / 2 / Camera.main.pixelWidth)
			{
				isMoving = false;
				NotificationCenter.DefaultCenter.PostNotification (this, GameConstants.bubbleBlowNotificationMessage);
			}
			bubble.Move (gameObject, speed);
		}
	}

	void OnBecameInvisible ()
	{
		Debug.Log ("INVISIBLE!!!!");

	}
}
