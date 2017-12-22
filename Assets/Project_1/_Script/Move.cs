using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	//public float Speed;
	//public float RotationSpeed;

	//public Vector3 NextPoint;
	public float speed;
	public Vector3 curPosition;
	public Vector3 nextPosition;
	Vector3 defaultPos = new Vector3(0, 0, 0);
	public float speedRot;
	public float tre;
	public bool isMove;
	int playingAnim = 0;
	public bool weapon = false;
	public CharacterController controller;
	public bool isAttack;
	
	// Use this for initialization
	void Start () {
		curPosition = transform.position;
		nextPosition = transform.position;
		GetComponent<Animation> ().Play ("idle");
		playingAnim = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		controller = GetComponent<CharacterController>();

		if (Input.GetMouseButtonDown(1)){

			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {

				if (hit.collider.tag == "floor") {
					nextPosition = hit.point + defaultPos;
					isMove = true;

					if (playingAnim != 1) {
						GetComponent<Animation> ().Stop ();
						GetComponent<Animation> ().Play ("Going");
						playingAnim = 1;						
					}
				}
			}
		}

		float distance = Vector3.Distance (new Vector3(transform.position.x, 0, transform.position.z), new Vector3(nextPosition.x, 0, nextPosition.z));

		if (transform.position != nextPosition && isMove) {
			//transform.LookAt (nextPosition);
			//transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed*Time.deltaTime);

			Quaternion tRot = Quaternion.LookRotation(nextPosition - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, tRot, speedRot * Time.deltaTime);

			Vector3 forward = transform.TransformDirection (Vector3.forward);
			controller.SimpleMove (forward * speed);

			if (distance < tre || isAttack) {

				playingAnim = 0;
				GetComponent<Animation> ().Stop ();
				GetComponent<Animation> ().Play ("idle");

				isMove = false;
				controller.SimpleMove (Vector3.zero);
			}
		} else {

			if (Input.GetKey(KeyCode.A)) {
				//transform.Rotate(Vector3.down * speed * Time.deltaTime);
				//transform.LookAt (nextPosition * speed * Time.deltaTime);
				Debug.Log ("A");
			} else if (Input.GetKey(KeyCode.D)) {
				//transform.Rotate(Vector3.up * speed * Time.deltaTime);
				Debug.Log ("D");
			}


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

		*/

	}
}
