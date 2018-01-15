using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		var text = other.gameObject.GetComponent<Text>.text;
	}
}
