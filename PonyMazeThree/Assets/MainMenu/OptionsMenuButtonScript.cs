using UnityEngine;
using System.Collections;

namespace UI
{

    public class OptionsMenuButtonScript : MonoBehaviour
    {
        
        void OnTrigger()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            ApplicationManagerScript.instance.SetCurrentApplicationState("OPTIONSSCENE");
        }
    }
}