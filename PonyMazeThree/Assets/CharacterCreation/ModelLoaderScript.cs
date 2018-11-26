using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ModelLoaderScript : MonoBehaviour {

    GameObject character;
    List<string> characterNames;
    int currentCharacter = 0;

    // Use this for initialization
    void Start() {
        //if (ApplicationManagerScript.instance.GetCurrentApplicationState() == "CHARSELECT")
        //{
            LoadModelIdle();
        //}
        //else
        //{
        //    LoadModelPlayer();
        //}
    }

    private void LoadModelPlayer()
    {

    }

    public void LoadModelIdle()
    {
        characterNames = new List<string>();
        character = GameObject.FindGameObjectWithTag("Player");
        PopulateCharacterNameList();
        character.GetComponent<CreateBaseCharacterScript>().CreateCharacter(characterNames[0]);
        gameObject.GetComponent<AnimationLinkScript>().LinkAnimationToModel("IdleTest", character.name);

    }

    void PopulateCharacterNameList()
    {
        string path;
        StreamReader charactersToRead;
        path = Application.dataPath + "/Resources/Characters.txt";

        charactersToRead = new StreamReader(path);

        string line = charactersToRead.ReadLine();
        while(line != null)
        {
            characterNames.Add(line);
            line = charactersToRead.ReadLine();
        }

        charactersToRead.Close();
    }

    public void SwapCharacterRight()
    {
        currentCharacter++;
        if(currentCharacter < characterNames.Count)
        {
            character.GetComponent<CreateBaseCharacterScript>().RefreshCharacter(characterNames[currentCharacter]);
            gameObject.GetComponent<AnimationLinkScript>().LinkAnimationToModel("IdleTest", character.name);
        }
        else
        {
            currentCharacter = 0;
            character.GetComponent<CreateBaseCharacterScript>().RefreshCharacter(characterNames[currentCharacter]);
            gameObject.GetComponent<AnimationLinkScript>().LinkAnimationToModel("IdleTest", character.name);
        }

    }

    public void SwapCharacterLeft()
    {
        currentCharacter--;
        if (currentCharacter >= 0)
        {
            character.GetComponent<CreateBaseCharacterScript>().RefreshCharacter(characterNames[currentCharacter]);
            gameObject.GetComponent<AnimationLinkScript>().LinkAnimationToModel("IdleTest", character.name);
        }
        else
        {
            currentCharacter = characterNames.Count - 1;
            character.GetComponent<CreateBaseCharacterScript>().RefreshCharacter(characterNames[currentCharacter]);
            gameObject.GetComponent<AnimationLinkScript>().LinkAnimationToModel("IdleTest", character.name);
        }
    }
	
}
