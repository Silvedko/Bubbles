using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour {

	public Bubble bubble;
	float speed = 0.01f;
	bool isMoving = true;

	void Start () 
	{

		bubble = new LargeBubble ();
		StartCoroutine (MonsterMove ());
	}
	
	void Update () 
	{
//		SetPixelInsetToGUITexture ();
		SetColliderPosition (transform.position, transform.localScale);
	}
	
	//Set collider center position
	protected void SetColliderPosition (Vector3 pos, Vector3 scale)
	{
//		CircleCollider2D collider = (CircleCollider2D) gameObject.collider2D;
//		collider.center = new Vector2 (pos.x / scale.y, 
//		                               pos.y / scale.y);
	}
	
	
	// Set PixelInset because GUITexture center is the lower left corner
	protected void SetPixelInsetToGUITexture ()
	{
		var texture = gameObject.GetComponent<GUITexture> ();
		texture.pixelInset = new Rect (Camera.main.pixelWidth / 2 * transform.position.x, Camera.main.pixelHeight / 2 * transform.position.y, 0f, 0f);
	}

	IEnumerator MonsterMove ()
	{
		while (isMoving) 
		{
			Debug.Log("Move! ");
			yield return new WaitForSeconds (0.05f);
			if(gameObject.transform.position.x >= 0.4f)
				isMoving = false;
			bubble.Move (gameObject, speed);
		}
	}
}
