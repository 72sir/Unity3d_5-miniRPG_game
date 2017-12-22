using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackZone : MonoBehaviour {

	public Move player;
	public bool weapon;

	// Use this for initialization
	void Start () {
		weapon = player.weapon;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay (Collider col) {
		if (col.CompareTag("Player")) {

			Animation anim = col.GetComponent<Animation> ();

			if (Input.GetKey(KeyCode.E) || Input.GetKeyDown(KeyCode.E)) {
				
				player.transform.LookAt (new Vector3 (transform.position.x, 0.5f, transform.position.z));

				player.isAttack = true;

				if (anim.IsPlaying ("walk")) anim.Stop ();
				// rotation target

				Quaternion tRot = Quaternion.LookRotation(transform.position - player.transform.position);
				tRot.x = 0;
				tRot.z = 0;
				player.transform.rotation = Quaternion.Slerp (player.transform.rotation, tRot, player.speedRot * Time.deltaTime);


				if (!anim.IsPlaying("atack")) {
					anim.Play ("attack");
				}
			} else {
				player.isAttack = false;
			}
		}
	}

	void OnTriggerExit(Collider col) {
		
	}
}
