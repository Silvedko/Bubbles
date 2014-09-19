using UnityEngine;
using System.Collections;

public class LargeBubble : Bubble 
{
	public override void Move (GameObject gO, float speed)
	{
		Moving (gO, speed);
	}

	
	private void Moving (GameObject gO, float t)
	{
		Vector3 objPos = new Vector3 (gO.transform.localPosition.x, yPos , 0f);
		yPos -= t;
		gO.transform.localPosition = objPos;
	}
	
}
