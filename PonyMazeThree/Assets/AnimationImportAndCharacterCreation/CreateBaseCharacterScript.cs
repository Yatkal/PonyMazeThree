﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateBaseCharacterScript : MonoBehaviour {

    public GameObject character;
    public GameObject head;

	// Use this for initialization
	public void CreateCharacter (string characterName) {

        string modelString = "Models/";

        modelString += characterName;

        GameObject temp = Instantiate((GameObject)Resources.Load(modelString));
        character = temp;
        character.transform.parent = gameObject.transform;
        //ApplyBaseMaterials(characterName);

        //gameObject.AddComponent<AnimationLinkScript>();

	}
	
    public void RefreshCharacter(string characterName)
    {
        Destroy(head);
        Destroy(character);
        CreateCharacter(characterName);
    } 

    void ApplyBaseMaterials(string characterName)
    {
        Material[] materials;

        string materialsNameB = "Models/Materials/B_";
        string materialsNameP = "Models/Materials/P_";
        string materialsNameA = "Models/Materials/A_";
        string materialsNameH = "Models/Materials/H_";
        string materialsNameEL = "Models/Materials/EL_";
        string materialsNameER = "Models/Materials/ER_";
        string materialsNameHA = "Models/Materials/HA_";
        string materialsNameTA = "Models/Materials/TA_";
        string materialsNameHAF = "Models/Materials/HAF_";
        string materialsNameHAB = "Models/Materials/HAB_";
        string materialsNameHO = "Models/Materials/HO_";

        materialsNameB += characterName;
        materialsNameP += characterName;
        materialsNameA += characterName;
        materialsNameH += characterName;
        materialsNameEL += characterName;
        materialsNameER += characterName;
        materialsNameHA += characterName;
        materialsNameTA += characterName;
        materialsNameHAF += characterName;
        materialsNameHO += characterName;
        materialsNameHAB += characterName;

        materials = character.transform.Find("Reference").GetComponent<Renderer>().materials;

        for(int iter = 0; materials.Length > iter; iter++)
        {
            if(materials[iter].name == "body (Instance)")
            {
                materials[iter].mainTexture = (Texture)Resources.Load(materialsNameB);
                materials[iter].color = Color.white;
            }
            else if (materials[iter].name == "Privates (Instance)")
            {
                materials[iter].mainTexture = (Texture)Resources.Load(materialsNameP);
                materials[iter].color = Color.white;
            }
            else if (materials[iter].name == "Arms (Instance)")
            {
                materials[iter].mainTexture = (Texture)Resources.Load(materialsNameA);
                materials[iter].color = Color.white;
            }
        }

        Material[] headMaterials;
        Material[] hairMaterial;
        Material[] tailMaterial;
        Material[] hornMaterial;
        headMaterials = head.transform.Find("Reference").GetComponent<Renderer>().materials;
        hairMaterial = head.transform.Find("Hair").GetComponent<Renderer>().materials;
        tailMaterial = head.transform.Find("Tail").GetComponent<Renderer>().materials;

        if (head.transform.Find("Horn"))
        {
            hornMaterial = head.transform.Find("Horn").GetComponent<Renderer>().materials;
        }
        else
        {
            hornMaterial = null;
        }

        for (int iter = 0; headMaterials.Length > iter; iter++)
        {
            if (headMaterials[iter].name == "body (Instance)")
            {
                headMaterials[iter].mainTexture = (Texture)Resources.Load(materialsNameH);
                headMaterials[iter].color = Color.white;
            }
            else if (headMaterials[iter].name == "tongue (Instance)")
            {
                headMaterials[iter].mainTexture = (Texture)Resources.Load("Models/Materials/Generic_Tongue");
                headMaterials[iter].color = Color.white;
            }
            else if (headMaterials[iter].name == "teeth (Instance)")
            {
                headMaterials[iter].mainTexture = (Texture)Resources.Load("Models/Materials/Generic_Teeth");
                headMaterials[iter].color = Color.white;
            }
            else if (headMaterials[iter].name == "eyelashes (Instance)")
            {
                headMaterials[iter].mainTexture = (Texture)Resources.Load("Models/Materials/Generic_Eyelashes");
                headMaterials[iter].color = Color.white;
            }
            else if (headMaterials[iter].name == "eyeball_l (Instance)")
            {
                headMaterials[iter].mainTexture = (Texture)Resources.Load(materialsNameEL);
                headMaterials[iter].mainTextureOffset = new Vector2(0.8f, -0.2f);
                headMaterials[iter].color = Color.white;
            }
            else if (headMaterials[iter].name == "eyeball_r (Instance)")
            {
                headMaterials[iter].mainTexture = (Texture)Resources.Load(materialsNameER);
                headMaterials[iter].mainTextureOffset = new Vector2(0.2f, -0.2f);
                headMaterials[iter].color = Color.white;
            }

        }

        for(int iter = 0; hairMaterial.Length > iter; iter++)
        {
            if (hairMaterial[iter].name == "hair (Instance)")
            {
                hairMaterial[iter].mainTexture = (Texture)Resources.Load(materialsNameHA);
                hairMaterial[iter].color = Color.white;
            }
            else if (hairMaterial[iter].name == "hairfront (Instance)")
            {
                hairMaterial[iter].mainTexture = (Texture)Resources.Load(materialsNameHAF);
                hairMaterial[iter].color = Color.white;
            }
            else if (hairMaterial[iter].name == "hairback (Instance)")
            {
                hairMaterial[iter].mainTexture = (Texture)Resources.Load(materialsNameHAB);
                hairMaterial[iter].color = Color.white;
            }
        }
        for (int iter = 0; tailMaterial.Length > iter; iter++)
        {
            if (tailMaterial[iter].name == "tail (Instance)")
            {
                tailMaterial[iter].mainTexture = (Texture)Resources.Load(materialsNameTA);
                tailMaterial[iter].color = Color.white;
            }
        }

        if (hornMaterial != null)
        {
            for (int iter = 0; hornMaterial.Length > iter; iter++)
            {
                if (hornMaterial[iter].name == "horn (Instance)")
                {
                    hornMaterial[iter].mainTexture = (Texture)Resources.Load(materialsNameHO);
                    hornMaterial[iter].color = Color.white;
                }
            }
        }
    }
}
