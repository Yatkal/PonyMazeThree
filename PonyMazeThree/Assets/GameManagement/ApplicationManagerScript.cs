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
                if (SceneManager.GetSceneByName("MainMenuScene").isLoaded != true)
                {
                    if (currentLevelScene != null)
                    {
                        SceneManager.UnloadSceneAsync(currentLevelScene);
                    }

                    SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Additive);
                    Debug.Log("LoadMenuScene");
                    currentLevelScene = "MainMenuScene";
                    AudioManagerScript.instance.CreateNewBackgroundMusic("MenuMusic");
                    previousApplicationState = currentApplicationState;
                }
            }
            else if (currentApplicationState == "MAINMENU")
            {
                if (SceneManager.GetSceneByName("MainMenuScene").isLoaded != true)
                {
                    if (currentLevelScene != null)
                    {
                        SceneManager.UnloadSceneAsync(currentLevelScene);
                    }
                    SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Additive);
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenuScene"));
                    Debug.Log("LoadMenuScene");
                    currentLevelScene = "MainMenuScene";
                    if (AudioManagerScript.instance.currentBackgroundMusic.GetComponent<AudioSource>().clip.name != "MenuMusic")
                    {
                        AudioManagerScript.instance.CreateNewBackgroundMusic("MenuMusic");
                    }
                    previousApplicationState = currentApplicationState;
                }
            }
            else if (currentApplicationState == "CHARSELECT")
            {
                if (SceneManager.GetSceneByName("CharacterCreationScene").isLoaded != true)
                {
                    if (currentLevelScene != null)
                    {
                        SceneManager.UnloadSceneAsync(currentLevelScene);
                    }
                    SceneManager.LoadScene("CharacterCreationScene", LoadSceneMode.Additive);
                    Debug.Log("LoadCharacterSelectionScene");
                    currentLevelScene = "CharacterCreationScene";
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
                }
                previousApplicationState = currentApplicationState;

            }
            else if (currentApplicationState == "LEVEL1PLAY")
            {
                if (SceneManager.GetSceneByName("Level1").isLoaded != true)
                {
                    if (currentLevelScene != null)
                    {
                        SceneManager.UnloadSceneAsync(currentLevelScene);
                    }
                    SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
                    Debug.Log("LoadLevel1");
                    currentLevelScene = "Level1";
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
                }
                previousApplicationState = currentApplicationState;

            }
            else if (currentApplicationState == "WINSCREEN")
            {
                if (SceneManager.GetSceneByName("WinScreen").isLoaded != true)
                {
                    if (currentLevelScene != null)
                    {
                        SceneManager.UnloadSceneAsync(currentLevelScene);
                    }
                    SceneManager.LoadScene("WinScreen", LoadSceneMode.Additive);
                    Debug.Log("LoadWinScreen");
                    currentLevelScene = "WinScreen";
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
                }
                previousApplicationState = currentApplicationState;

            }
            else if (currentApplicationState == "OPTIONSSCENE")
            {
                if (SceneManager.GetSceneByName("OptionsScene").isLoaded != true)
                {
                    if (currentLevelScene != null)
                    {
                        SceneManager.UnloadSceneAsync(currentLevelScene);
                    }
                    SceneManager.LoadScene("OptionsScene", LoadSceneMode.Additive);
                    Debug.Log("OptionsScene");
                    currentLevelScene = "OptionsScene";
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
                }
                previousApplicationState = currentApplicationState;

            }
        }
        else
        {
            if(GameObject.FindGameObjectWithTag("LoadingScreen"))
            {
                Destroy(GameObject.FindGameObjectWithTag("LoadingScreen"));
            }
            previousApplicationState = currentApplicationState;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
        }

        
    }

    public string GetCurrentApplicationState()
    {
        return currentApplicationState;
    }

    public void SetCurrentApplicationState(string toSet)
    {
        currentApplicationState = toSet;
    }
}
