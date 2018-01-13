using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Input.GetAxis("Horizontal"),0,0);
	}
}
