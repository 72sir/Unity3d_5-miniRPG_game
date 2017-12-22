using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipTrigger : MonoBehaviour {

	public Text text;
	public GameObject canvas;
	public bool open = true;
	public string textTip;

	void OnTriggerStay(Collider col) {
		if (col.tag == "Player") {

			canvas.SetActive (true);
			text.text = textTip;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			canvas.SetActive (false);
		}
	}

}
