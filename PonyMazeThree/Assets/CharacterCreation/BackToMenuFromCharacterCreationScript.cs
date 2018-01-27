using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenuFromCharacterCreationScript : MonoBehaviour {

    void Trigger()
    {
        ApplicationManagerScript.instance.SetCurrentApplicationState("MAINMENU");
    }
}
