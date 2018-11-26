using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationManagerScript : MonoBehaviour {

    public string currentApplicationState;
    string previousApplicationState;

    public GameObject loadingScreen;

    public static ApplicationManagerScript instance;

    public Scene managementScene;
    string currentLevelScene;

	void Start ()
    {
        managementScene = SceneManager.GetActiveScene();

        currentApplicationState = "APPLICATIONSTART";
        previousApplicationState = "null";

        currentLevelScene = null;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	void LateUpdate ()
    {
        if (currentApplicationState != previousApplicationState)
        {
            //set up the loading screen
            //if (currentLevelScene != null)
            //{
            //    SceneManager.UnloadSceneAsync(currentLevelScene);
            //}

            if (!GameObject.FindGameObjectWithTag("LoadingScreen"))
            {
                Instantiate(loadingScreen);
            }

            //find out what we need to load and start the load process
            if (currentApplicationState == "APPLICATIONSTART")
            {
                LoadScene("MainMenuScene");
            }
            else if (currentApplicationState == "MAINMENU")
            {
                LoadScene("MainMenuScene");
            }
            else if (currentApplicationState == "CHARSELECT")
            {
                LoadScene("CharacterCreationScene");

            }
            else if (currentApplicationState == "LEVEL1PLAY")
            {
                LoadScene("Level1");

            }
            else if (currentApplicationState == "WINSCREEN")
            {
                LoadScene("WinScreen");

            }
            else if (currentApplicationState == "OPTIONSSCENE")
            {
                LoadScene("OptionsScene");

            }
            else if (currentApplicationState == "VIEWERSCENE")
            {
                LoadScene("ViewerScene");
            }

        }
        else
        {
            if(GameObject.FindGameObjectWithTag("LoadingScreen"))
            {
                Destroy(GameObject.FindGameObjectWithTag("LoadingScreen"));
            }
            previousApplicationState = currentApplicationState;
            
        }

      //if (SceneManager.)
       // SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
        
    }

    public string GetCurrentApplicationState()
    {
        return currentApplicationState;
    }

    public void SetCurrentApplicationState(string toSet)
    {
        currentApplicationState = toSet;
    }

    private void LoadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded != true)
        {
            if (currentLevelScene != null)
            {
                SceneManager.UnloadSceneAsync(currentLevelScene);
            }
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            Debug.Log(sceneName);
            currentLevelScene = sceneName;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
        }
        previousApplicationState = currentApplicationState;
    } 
}
