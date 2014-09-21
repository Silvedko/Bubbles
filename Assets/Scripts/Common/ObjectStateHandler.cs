using UnityEngine;
using System.Collections;

public class ObjectStateHandler : MonoBehaviour
{
	void Start ()
	{
		NotificationCenter.DefaultCenter.AddObserver (this, GameConstants.bubbleBlowNotificationMessage);
		NotificationCenter.DefaultCenter.AddObserver (this, GameConstants.bubbleDeniedNotificationMessage);
		Debug.Log ("Textures Count = " + GameManager.Instance.textures.Count);
	}

	void OnDestroy ()
	{
		NotificationCenter.DefaultCenter.RemoveObserver (this, GameConstants.bubbleBlowNotificationMessage);
		NotificationCenter.DefaultCenter.RemoveObserver (this, GameConstants.bubbleDeniedNotificationMessage);
	}

	void BubbleBlow(NotificationCenter.Notification notification)
	{
//		notification.goSender;
	}
}
