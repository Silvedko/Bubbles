using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour {

	int counter = 0;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
			CheckTouch ();
	}


	void CheckTouch()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		
		if(hit.collider != null)
		{
			counter ++;
			Destroy(hit.collider.gameObject);
		}

	}

}
