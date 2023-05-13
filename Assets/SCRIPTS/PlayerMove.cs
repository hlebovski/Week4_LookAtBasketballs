using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    
	public PeachManager PeachManager;
	public Transform CameraCenter;

	public float TorqueValue;
	public float jumpHeight;

	Rigidbody rigid;

	private bool InAir;

	void Start() {
		rigid = GetComponent<Rigidbody>();
        rigid.maxAngularVelocity = 100f;
    }

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {

			if (!InAir) {
				rigid.AddForce(Vector3.up * 100f * jumpHeight);
			}

		}
	}

	void FixedUpdate() {

		rigid.AddTorque(CameraCenter.right * Input.GetAxis("Vertical") * TorqueValue);
		rigid.AddTorque(-CameraCenter.forward * Input.GetAxis("Horizontal") * TorqueValue);

	}

	private void OnTriggerEnter(Collider other) {

		if (other.GetComponent<Peach>()) {
			PeachManager.CollectPeach(other.GetComponent<Peach>());
		}

	}

	private void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "Floor" ) {
			InAir = true;
		}
	}

	private void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag == "Floor") {
			InAir = false;
		}
	}


}
