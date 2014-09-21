using UnityEngine;
using System.Collections;

public class ObjectStateHandler : MonoBehaviour
{
	NotificationCenter ntfCenter = null;
	void Start ()
	{
		ntfCenter = NotificationCenter.DefaultCenter;
		ntfCenter.AddObserver (this, GameConstants.onBubbleBlowNotificationMessage);
		ntfCenter.AddObserver (this, GameConstants.onBubbleDeniedNotificationMessage);
	}

	void OnDestroy ()
	{
		if (ntfCenter != null && !ntfCenter.Equals (null)) 
		{
			ntfCenter.RemoveObserver (this, GameConstants.onBubbleBlowNotificationMessage);
			ntfCenter.RemoveObserver (this, GameConstants.onBubbleDeniedNotificationMessage);
		}
	}

	void OnBubbleBlow (NotificationCenter.Notification notification)
	{
		GameManager.Instance.AddGameObjectToPool(notification.goSender);
	}

	void OnBubbleDenied (NotificationCenter.Notification notification)
	{
		GameManager.Instance.AddGameObjectToPool(notification.goSender);
	}
}
