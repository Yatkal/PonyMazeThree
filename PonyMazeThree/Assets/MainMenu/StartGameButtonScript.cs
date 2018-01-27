using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UI
{

    public class StartGameButtonScript : MonoBehaviour
    {


        void OnTrigger()
        {
            //AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            ApplicationManagerScript.instance.SetCurrentApplicationState("CHARSELECT");
        }

    }
}