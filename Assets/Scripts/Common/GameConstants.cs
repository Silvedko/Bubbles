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

	#region Notification Constants

		public static string onBubbleBlowNotificationMessage = "OnBubbleBlow";
		public static string onBubbleDeniedNotificationMessage = "OnBubbleDenied";
		public static string onTextureDownloading = "OnLoadComplete";
		public static string onTextureCreated = "OnTextureCreated";

	#endregion

	public static string gameSceneName = "GameScene";

	public static string[] bubbleLinks = 
	{
		"http://s2.postimg.org/hp36elwpx/circle_32.png",
		"http://s2.postimg.org/s0k4l0dt1/circle_64.png",
		"http://s2.postimg.org/waysgliw5/circle_128.png",
		"http://s2.postimg.org/ad2bmt3vt/circle_256.png"
	};
}
