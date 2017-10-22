using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			gameObject.transform.parent.Translate (-.1f, 0, 0);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			gameObject.transform.parent.Translate (.1f, 0, 0);

		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			gameObject.transform.parent.Translate (0, 0, .1f);

		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			gameObject.transform.parent.Translate (0, 0, -.1f);

		}
		if (Input.GetKey(KeyCode.A))
		{
			gameObject.transform.parent.Rotate (new Vector3 (0, -2, 0));
		}
		if (Input.GetKey(KeyCode.D))
		{
			gameObject.transform.parent.Rotate (new Vector3 (0, 2, 0));

		}
		if (Input.GetKey(KeyCode.S))
		{
				gameObject.transform.Rotate (new Vector3 (2, 0, 0));

		}
		if (Input.GetKey(KeyCode.W))
		{
				gameObject.transform.Rotate (new Vector3 (-2, 0, 0));

		}
	}
}
