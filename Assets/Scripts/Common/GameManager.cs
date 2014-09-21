using UnityEngine;
using System.Collections;

public class GameManager : MonoSingleton <GameManager>
{
	private int bubbleDropped;
	public int BubbleDropped
	{
		get {return bubbleDropped;}
		set {bubbleDropped = value;}
	}

	public void IncreasePoints (int points)
	{

	}

	public void DecreasePoints (int points)
	{

	}


	
	public override void Init () 
	{
		BubbleDropped = 0;
	}

}
