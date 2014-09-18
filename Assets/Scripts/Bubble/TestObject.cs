using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour {


	void Awake ()
	{

	}

	void Start () 
	{
		var texture = gameObject.GetComponent<GUITexture> ();
		texture.pixelInset = new Rect (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0f, 0f);
	}

	void Update () 
	{
		SetColliderPosition (transform.position, transform.localScale);
	}

	void SetColliderPosition (Vector3 objectPos, Vector3 scale)
	{
		CircleCollider2D collider = (CircleCollider2D) gameObject.collider2D;
		collider.center = new Vector2 (objectPos.x / scale.x , 
		                               objectPos.y / scale.y);
	}
}
