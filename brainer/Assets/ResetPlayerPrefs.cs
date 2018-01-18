using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour {

	public void Reset() {
		PlayerPrefs.DeleteAll();
	}
}
