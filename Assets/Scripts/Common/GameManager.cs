using UnityEngine;
using System.Collections;

public class GameManager : MonoSingleton <GameManager>
{
	private int lifeCount;
	public int LifeCount
	{
		get {return lifeCount;}
		set {lifeCount = value;}
	}
	
	public override void Init () 
	{

	}

}
