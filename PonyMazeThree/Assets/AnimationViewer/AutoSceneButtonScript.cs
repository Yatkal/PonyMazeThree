using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSceneButtonScript : MonoBehaviour {

    void Trigger()
    {

        AnimationManagerScript.instance.AutoAnimation();
    }
}
