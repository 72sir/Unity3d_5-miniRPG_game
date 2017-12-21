using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	//public float Speed;
	//public float RotationSpeed;

	//public Vector3 NextPoint;
	public float speed;
	public Vector3 curPosition;
	public Vector3 nextPosition;
	Vector3 defaultPos = new Vector3(0, 0.5f, 0);
	
	// Use this for initialization
	void Start () {
		curPosition = transform.position;
		nextPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)){

			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				nextPosition = hit.point + defaultPos;
			}
		}
		
		if (transform.position != nextPosition) {
			transform.LookAt(nextPosition);
			transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed*Time.deltaTime);
		}
		
		/*
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector3.forward * Speed * Time.deltaTime);
		}

		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			Speed = Speed * 3;
		}
		
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			Speed = Speed / 3;
		} 

		if (Input.GetKey(KeyCode.A)) {
			transform.Rotate(Vector3.down * RotationSpeed * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.D)) {
			transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
		}
		*/

	}
}
