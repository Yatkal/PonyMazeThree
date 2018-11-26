using UnityEngine;
using System.Collections;

public class AlwaysAtParentScript : MonoBehaviour {

    GameObject parent;
    GameObject thisobject;
    Vector3 scale;
    Vector3 pos;
    Quaternion rot;
    string animationName;

    public void Create(string name)
    {
       animationName = name;
        Setup();
    }

    // Use this for initialization
    void Setup () {
        parent = transform.parent.gameObject;
        thisobject = gameObject;
        pos = Vector3.zero;
        rot = Quaternion.identity;
        
        if (animationName == "Head")
        {
            //if (transform.parent.name == "Chest2")
            //{
            //  scale = new Vector3(0.3f, 0.3f, 0.3f);

            //}
            if (transform.parent.name == "Neck")
            {
                scale = new Vector3(5f, 5f, 5f);
            }
            else if (transform.parent.name == "HairBack1")
            {
                scale = new Vector3(5f, 5f, 5f);
                //pos = new Vector3(0.992f, 0.479f, -0.061f);
                //rot = thisobject.transform.localRotation;
            }
            else if (transform.parent.name == "jiggle_hair2")
            {
                scale = new Vector3(5f, 5f, 5f);
                //pos = new Vector3(0.008f, -0.06f, 0.374f);
            }
            else if (transform.parent.name == "LeftEar")
            {
                scale = new Vector3(5f, 5f, 5f);
               // pos = new Vector3(0.189f, 0.624f, -0.271f);
            }
            else if (transform.parent.name == "RightEar")
            {
                scale = new Vector3(5f, 5f, 5f);
                //pos = new Vector3(0.268f, 0.615f, 0.262f);
            }
            else if (transform.parent.name == "jiggle_hair1")
            {
                scale = new Vector3(4f, 4f, 4f);
                //pos = new Vector3(1.0f, 0.0f, 0.0f);
            }
            else
            {
                scale = new Vector3(0f, 0f, 0f);
            }
        }
        if (animationName == "Body")
        {
            if (transform.parent.name == "ValveBiped.Bip01_neck1" || transform.parent.name == "ValveBiped.Bip01_Head1" || transform.parent.name == "L-Ear-1"
                || transform.parent.name == "L-Ear-2" || transform.parent.name == "R-Ear-1" || transform.parent.name == "R-Ear-2" || transform.parent.name == "L-Hair-1-1"
                || transform.parent.name == "L-Hair-2-1" || transform.parent.name == "L-Hair-3-1" || transform.parent.name == "R-Hair-1-1" || transform.parent.name == "R-Hair-2-1"
                || transform.parent.name == "R-Hair-3-1" || transform.parent.name == "L-Hair-1-2" || transform.parent.name == "L-Hair-2-2" || transform.parent.name == "L-Hair-3-2" 
                || transform.parent.name == "R-Hair-1-2" || transform.parent.name == "R-Hair-2-2" || transform.parent.name == "R-Hair-3-2" || transform.parent.name == "Lips"
                || transform.parent.name == "Tongue1" || transform.parent.name == "JawBone" || transform.parent.name == "Tongue2" || transform.parent.name == "Tongue3"
                || transform.parent.name == "Tongue4")
            {
                scale = new Vector3(0f, 0f, 0f);
            }
            else
            {
                scale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            scale = new Vector3(1f, 1f, 1f);
        }

        thisobject.transform.localScale = scale;
        thisobject.transform.localPosition = pos;
        thisobject.transform.localRotation = rot;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        thisobject.transform.localScale = scale;
        thisobject.transform.localPosition = pos;
        thisobject.transform.localRotation = rot;
    }
}
