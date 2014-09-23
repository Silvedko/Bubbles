using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour 
{
	public Bubble bubble;
	public Sprite sprite;
	public bool isMoving = true;
	public GameConstants.GameObjectSizes textureWidth = GameConstants.GameObjectSizes.Small;

	float speed = 0.01f;
	float delay = 0.01f;
	NotificationCenter ntfCenter = null;

	void Start () 
	{
		ntfCenter = NotificationCenter.DefaultCenter;

		bubble = SetBubbleObject((int)textureWidth);
		speed = 0.5f / (int)textureWidth;
		ReInitObject ();
		ntfCenter.PostNotification (this, GameConstants.onBubbleCreated, gameObject);

	}

	public void ReInitObject ()
	{
		StartCoroutine (BubbleMoveWithDelay (delay));
	}

	Bubble SetBubbleObject (int size) 
	{	
		return ChooseObjFromSize((GameConstants.GameObjectSizes) size);
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
				ntfCenter.PostNotification (this, GameConstants.onBubbleDeniedNotificationMessage, gameObject);
			}
			bubble.Move (gameObject, speed);
		}
	}
}
