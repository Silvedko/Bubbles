using UnityEngine;
using System.Collections;

public class AutoScaleObjects : MonoBehaviour {

	public Vector2 scaleRatio = new Vector2 (0.1f, 0.1f);
	private Transform myTrans;
	private float widthHeightRatio;

	void Start () 
	{
		myTrans = transform;
		widthHeightRatio = (float) Screen.width / Screen.height;
		SetScale ();
	}

	void SetScale ()
	{
		myTrans.localScale = new Vector3 (scaleRatio.x, widthHeightRatio * scaleRatio.y, 1f);
	}
}
