using UnityEngine;
using System.Collections;

public class GameConstants  
{

	public enum GameObjectSizes : int
	{
		Small = 32,
		Medium = 64,
		Large = 128,
		ExtraLarge = 256
	}

	public static string bubbleBlowNotificationMessage = "BubbleBlow";
	public static string bubbleDeniedNotificationMessage = "BubbleDenied";

	public string bubble32Link = "http://s2.postimg.org/hp36elwpx/circle_32.png";
	public string bubble64Link = "http://s2.postimg.org/s0k4l0dt1/circle_64.png";
	public string bubble128Link = "http://s2.postimg.org/waysgliw5/circle_128.png";
	public string bubble256Link = "http://s2.postimg.org/ad2bmt3vt/circle_256.png";
}
