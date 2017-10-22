using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public int id;
	public Shader outline;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void outlineMe(){
		this.gameObject.GetComponent<Renderer> ().material.shader = outline;
	}

	public void noOutlineMe(){
		this.gameObject.GetComponent<Renderer> ().material.shader = Shader.Find ("Standard");
	}
}
