using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSetObject : ScriptableObject {

    public string animationName;
    public string dominantCharacterName;
    public string slaveCharacterName;
    public Vector3 dominantPosition;
    public Vector3 slavePosition;
    public Quaternion dominantRotation;
    public Quaternion slaveRotation;
}
