using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InvPanel : MonoBehaviour {

	public Sprite defaultAdd;
	public bool ItemIn = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void highlight(){
		game myGame = GameObject.Find ("GameHandler").GetComponent<game> ();
		GameObject selOb = myGame.selected;
		if(selOb!=null){
			int picId = selOb.GetComponent<InteractableObject> ().id;
			Sprite newPicImg = myGame.buttonSprites [picId];
			gameObject.transform.Find ("Image").gameObject.GetComponent<Image> ().sprite = newPicImg;
			selOb.GetComponent<MeshRenderer> ().enabled = false;
			ItemIn = true;
		}
	}

	public void unHighlight(){
		game myGame = GameObject.Find ("GameHandler").GetComponent<game> ();
		GameObject selOb = myGame.selected;
		if (selOb != null && ItemIn == true) {
			gameObject.transform.Find ("Image").gameObject.GetComponent<Image> ().sprite = defaultAdd;
			selOb.GetComponent<MeshRenderer> ().enabled = true;
			ItemIn = false;
		}
	}

	public void PutInBackpack(){
		Debug.Log ("called from pointer up");
		game myGame = GameObject.Find ("GameHandler").GetComponent<game> ();
		GameObject selOb = myGame.selected;
		if (selOb != null && ItemIn == true) {
			Debug.Log ("item exists");
			myGame.InventoryList.Add (selOb.GetComponent<InteractableObject>().id);
			gameObject.transform.Find ("Image").gameObject.GetComponent<Image> ().sprite = defaultAdd;
			Destroy (selOb);
			ItemIn = false;
		}
	}

	public void PutInBackpackTwo(){
		Debug.Log ("called from game");
		game myGame = GameObject.Find ("GameHandler").GetComponent<game> ();
		GameObject selOb = myGame.selected;
		if (selOb != null && ItemIn == true) {
			Debug.Log ("item exists");
			myGame.InventoryList.Add (selOb.GetComponent<InteractableObject>().id);
			gameObject.transform.Find ("Image").gameObject.GetComponent<Image> ().sprite = defaultAdd;
			Destroy (selOb);
			ItemIn = false;
		}
	}

	void OnMouseOver(){
		this.highlight ();
		Debug.Log ("MOUSE IS OVER");
	}
}
