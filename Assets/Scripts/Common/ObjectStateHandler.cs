using UnityEngine;
using System.Collections;

public class ObjectStateHandler : MonoBehaviour
{
	void Start ()
	{
		NotificationCenter.DefaultCenter.AddObserver (this, GameConstants.bubbleBlowNotificationMessage);
		NotificationCenter.DefaultCenter.AddObserver (this, GameConstants.bubbleDeniedNotificationMessage);
	}

	void BubbleBlow(NotificationCenter.Notification sender)
	{
//		Destroy(sender);
	}
}
