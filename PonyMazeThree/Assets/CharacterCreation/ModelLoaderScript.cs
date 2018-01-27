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
        
        characterNames = new List<string>();
        character = GameObject.FindGameObjectWithTag("Player");
        PopulateCharacterNameList();
        character.GetComponent<CreateBaseCharacterScript>().CreateCharacter(characterNames[0]);

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
        }
        else
        {
            currentCharacter = 0;
            character.GetComponent<CreateBaseCharacterScript>().RefreshCharacter(characterNames[currentCharacter]);
        }

    }

    public void SwapCharacterLeft()
    {
        currentCharacter--;
        if (currentCharacter >= 0)
        {
            character.GetComponent<CreateBaseCharacterScript>().RefreshCharacter(characterNames[currentCharacter]);
        }
        else
        {
            currentCharacter = characterNames.Count - 1;
            character.GetComponent<CreateBaseCharacterScript>().RefreshCharacter(characterNames[currentCharacter]);
        }
    }
	
}
