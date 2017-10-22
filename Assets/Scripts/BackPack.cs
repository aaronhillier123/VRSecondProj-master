using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPack : MonoBehaviour {


	// Use this for initialization
	void Start () {

		Button[] btns = gameObject.GetComponentsInChildren<Button> ();
		Debug.Log (btns.Length);
		game myGame = GameObject.Find ("GameHandler").GetComponent<game> ();
		if(myGame.buttonSprites.Count > 0){
		GameObject.Find("Item1").GetComponent<Image>().sprite = myGame.buttonSprites [myGame.InventoryList[0]];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
