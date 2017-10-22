using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {

	public Camera camera;
	public GameObject backpack;
	public GameObject selected;
	public List<Sprite> buttonSprites = new List<Sprite>(15);
	public List<int> InventoryList = new List<int>();
	// Use this for initialization
	void Start () {
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		//on mouse over up to 10 units away, outline object
		if (Physics.Raycast (ray, out hit, 10f)) {
			Transform objectHit = hit.transform;
			//if mouse is touching item
			if (objectHit.gameObject.CompareTag ("Interactable")) {
				//highlight item
				selected = objectHit.gameObject;
				objectHit.gameObject.GetComponent<InteractableObject> ().outlineMe ();
				if (Input.GetMouseButton (1)) {
					//pick up item if mouse is clicked
					Vector3 myNewPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5f);
					objectHit.position = camera.ScreenToWorldPoint (myNewPos);

					RaycastHit hit2;
					Ray ray2 = camera.ScreenPointToRay (Input.mousePosition);
					if (Physics.Raycast (ray, out hit2)) {
						Transform objectHit2 = hit.transform;
						if (objectHit2.gameObject.CompareTag ("InventoryBox")) {
							objectHit2.gameObject.GetComponent<InvPanel> ().highlight ();
						}
					}
						
				}
			}
		} else if(selected!= null && Input.GetMouseButton(0)){
			Vector3 myNewPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z+5f);
			selected.transform.position = camera.ScreenToWorldPoint (myNewPos);
			RaycastHit hit2;
			Ray ray2 = camera.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit2)){
				Transform objectHit2 = hit2.transform;
				if(objectHit2.gameObject.CompareTag("InventoryBox")){
					objectHit2.gameObject.GetComponent<InvPanel>().highlight();
				}
			}
		}else {
			if (selected != null && !Input.GetMouseButton(0)) {
				selected.GetComponent<InteractableObject> ().noOutlineMe ();
				if (GameObject.Find ("InvPanel").GetComponent<InvPanel> ().ItemIn == false) {
					selected = null;
				} else {
					GameObject.Find ("InvPanel").GetComponent<InvPanel> ().PutInBackpackTwo ();
				}
			}
		}


		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject isBackPack = GameObject.Find ("Backpack(Clone)");
			if (isBackPack == null) {
				GameObject newBackPack = Instantiate (backpack) as GameObject;
				newBackPack.transform.SetParent (GameObject.Find ("Canvas").transform, false);
			} else {
				Destroy (isBackPack.gameObject);
			}
		}
	}
}
