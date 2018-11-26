using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{

    public class GoToViewerButtonScript : MonoBehaviour
    {

        void Trigger()
        {
           // AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            ApplicationManagerScript.instance.SetCurrentApplicationState("VIEWERSCENE");
        }
    }
}