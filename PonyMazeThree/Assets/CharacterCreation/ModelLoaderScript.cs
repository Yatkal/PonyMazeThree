using UnityEngine;
using System.Collections;

public class ModelLoaderScript : MonoBehaviour {

    GameObject character;

	// Use this for initialization
	void Start () {
        character = GameObject.FindGameObjectWithTag("Player");
        character.GetComponent<CreateBaseCharacterScript>().CreateCharacter("Rarity");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
