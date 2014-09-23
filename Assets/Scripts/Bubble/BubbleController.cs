using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour 
{
	public Bubble bubble;
	public Sprite sprite;

	//for stop moving
	public bool isMoving = true;

	public GameConstants.GameObjectSizes textureWidth = GameConstants.GameObjectSizes.Small;

	float speed = 0.01f;
	float delay = 0.01f;
	NotificationCenter ntfCenter = null;

	void Start ()
	{
		InitObject ();
	}
	
	public void InitObject () 
	{
		ntfCenter = NotificationCenter.DefaultCenter;

		bubble = SetBubbleObject((int)textureWidth);
		speed = 0.5f / (int)textureWidth;
		MoveObj ();

		//Notification for texture creation
		ntfCenter.PostNotification (this, GameConstants.onBubbleCreated, gameObject);
	}

	public void MoveObj ()
	{
		StartCoroutine (BubbleMoveWithDelay (delay));
	}

	//Set type of bubble
	Bubble SetBubbleObject (int size) 
	{	
		return ChooseObjFromSize((GameConstants.GameObjectSizes) size);
	}

	void OnDisable ()
	{
		bubble = null;
		Destroy (sprite);
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


	IEnumerator BubbleMoveWithDelay (float aDelay)
	{
		while (isMoving) 
		{
			yield return new WaitForSeconds (aDelay);
			if(gameObject.transform.position.y <= -1.0f - (int)textureWidth / 100 / 2) // 100 - Default ratio Pixels to Unit
			{
				isMoving = false;
				gameObject.transform.position = new Vector3 (transform.position.x, 1f + (float)textureWidth / 100f / 2f, 0f);
				ntfCenter.PostNotification (this, GameConstants.onBubbleDeniedNotificationMessage, gameObject);
				break;
			}
			bubble.Move (gameObject, speed);
		}
	}
}
