using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacterLeftButton : MonoBehaviour {

    GameObject modelLoader;

    void Start()
    {
        modelLoader = GameObject.Find("ModelLoader");
    }

    void Trigger()
    {
        modelLoader.GetComponent<ModelLoaderScript>().SwapCharacterLeft();
    }
}
