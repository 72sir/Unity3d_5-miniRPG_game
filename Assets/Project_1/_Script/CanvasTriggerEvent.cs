using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTriggerEvent : MonoBehaviour {

	public GameObject door;
	public Text text;
	public GameObject canvas;
	public bool open = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider col) {
		if (col.tag == "Player") {
			
			canvas.SetActive (true);

			if (!open) {					
				text.text = "Открыть дверь";
			} else {
				text.text = "Закрыть дверь";
			}

			if (Input.GetKeyDown(KeyCode.E)) {
				
				if (open) {					
					door.GetComponent<Animation> ().Play ("CloseDoor");
					open = false;
					return;
				} else {
					door.GetComponent<Animation> ().Play ("OpenDoor");
					open = true;
					return;
				}
			}
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			canvas.SetActive (false);
		}
	}


}
