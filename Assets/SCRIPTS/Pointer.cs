using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {
    
    public PeachManager PeachManager;
	public Transform PlayerTransform;

	Peach closestPeach;
    
    void Start() {
        
    }

    void Update() {

        transform.position = PlayerTransform.position;

		closestPeach = PeachManager.GetClosest(transform.position);
        Vector3 toTarget = closestPeach.transform.position - transform.position;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(toTarget.x, 0f, toTarget.z)), Time.deltaTime * 10f);
		Debug.DrawLine(transform.position, closestPeach.transform.position);
	}

}
