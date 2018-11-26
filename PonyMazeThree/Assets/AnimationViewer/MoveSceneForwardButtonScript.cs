using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneForwardButtonScript : MonoBehaviour {

    void Trigger()
    {

        AnimationManagerScript.instance.MoveAnimationForwardOne();
    }
}
