using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour 
{	
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
			CheckTouch ();
	}


	void CheckTouch()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		
		if(hit.collider != null)
		{
			NotificationCenter.DefaultCenter.PostNotification(this, GameConstants.onBubbleBlowNotificationMessage, hit.collider.gameObject);
		}
	}
}
