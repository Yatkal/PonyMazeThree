using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUiButtonScript : MonoBehaviour {

	// Update is called once per frame
	void Trigger () {

        AnimationManagerScript.instance.HideUi();
	}
}
