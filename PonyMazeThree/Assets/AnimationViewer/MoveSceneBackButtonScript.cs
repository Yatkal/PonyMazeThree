using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneBackButtonScript : MonoBehaviour {

    void Trigger()
    {

        AnimationManagerScript.instance.MoveAnimationBackOne();
    }
}
