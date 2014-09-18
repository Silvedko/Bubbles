using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour {

	public Camera camera;

	// Use this for initialization
	void Start () 
	{
		var texture = gameObject.GetComponent<GUITexture> ();
		texture.pixelInset = new Rect (camera.pixelWidth / 2, camera.pixelHeight / 2, 0f, 0f);
		Vector3 posWorldToViewportPoint = camera.WorldToViewportPoint (gameObject.transform.position);
		Vector3 posScreenToWorldPoint = camera.ScreenToWorldPoint (gameObject.transform.position);
		CircleCollider2D collider = (CircleCollider2D) gameObject.collider2D;

		Debug.Log ("1 " + collider.bounds);

//		CircleCollider2D collider = (CircleCollider2D) gameObject.collider2D;
		collider.center = new Vector2 (gameObject.transform.position.x / gameObject.transform.localScale.x, 
		                               gameObject.transform.position.y / gameObject.transform.localScale.y);
		Debug.Log ("2 " + collider.bounds);



//		Debug.Log ("Go Pos = " + gameObject.transform.position + " Go localPos = " + gameObject.transform.localPosition);
//		Debug.Log (" posWorldToViewportPoint "+ posWorldToViewportPoint + " posScreenToWorldPoint " + posScreenToWorldPoint);
//		var pos3 = camera.pixelHeight (gameObject.transform.position);

//		Debug.Log ("camera.pixelHeight " + camera.pixelHeight + "camera.pixelW" + camera.pixelHeight);
	}

	//Go Pos = (0.8, 0.0, 0.0) Go localPos = (0.8, 0.0, 0.0)
	//  posWorldToViewportPoint (0.8, 0.5, 10.0) posScreenToWorldPoint (-1.2, -1.0, -10.0)
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
