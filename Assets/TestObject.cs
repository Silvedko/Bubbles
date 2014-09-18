using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour {

	public Camera camera;
	Vector3 startObjectScale;

	void Awake ()
	{
		startObjectScale = transform.localScale;
	}
	// Use this for initialization
	void Start () 
	{
		var texture = gameObject.GetComponent<GUITexture> ();
		texture.pixelInset = new Rect (camera.pixelWidth / 2, camera.pixelHeight / 2, 0f, 0f);
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
