using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class AnimationLinkScript : MonoBehaviour {

    GameObject bodyAnimation;
    GameObject bodyModel;
    GameObject finishedModel;
    List<GameObject> listOfChildrenOfBodyModel;
    List<GameObject> listOfChildrenOfBodyAnimation;

    public void LinkAnimationToModel(string bodyAnimationName, string bodyModelName)
    {
        listOfChildrenOfBodyModel = new List<GameObject>();
        listOfChildrenOfBodyAnimation = new List<GameObject>();
        
        finishedModel = new GameObject(bodyModelName+"Finished");
        bodyAnimation = GameObject.Find(bodyAnimationName).transform.GetChild(0).gameObject;
       
        bodyModel = GameObject.Find(bodyModelName).transform.GetChild(0).gameObject;

        GetChildRecursiveForBodyModel(bodyModel);
        
        GetChildRecursiveForBodyAnimation(bodyAnimation);
        
        MatchAnimationToModel(bodyAnimationName);

        bodyAnimation.transform.parent.transform.position = finishedModel.transform.position;
        bodyAnimation.transform.root.transform.parent = finishedModel.transform;

        finishedModel.transform.position = new Vector3(0.0f, 0.0f, 72.0f);
        finishedModel.transform.Rotate(new Vector3(90.0f, 0.0f, -179.0f));
    }

    void MatchAnimationToModel(string bodyAnimatonName)
    {
        for(int iter = 0; iter < listOfChildrenOfBodyAnimation.Count; iter++)
        {
            for(int iter2 = 0; iter2 < listOfChildrenOfBodyModel.Count; iter2++)
            {
                if(listOfChildrenOfBodyAnimation[iter].name == listOfChildrenOfBodyModel[iter2].name)
                {
                    //listOfChildrenOfModel[iter2].transform.DetachChildren();
                    listOfChildrenOfBodyModel[iter2].transform.parent = listOfChildrenOfBodyAnimation[iter].transform;

                    listOfChildrenOfBodyModel[iter2].AddComponent<AlwaysAtParentScript>();
                    listOfChildrenOfBodyModel[iter2].GetComponent<AlwaysAtParentScript>().Create("Body");
                    //listOfChildrenOfModel[iter2].transform.localRotation = Quaternion.identity;
                    //listOfChildrenOfModel[iter2].transform.localPosition = Vector3.zero;
                    //listOfChildrenOfModel[iter2].transform.rotation = Quaternion.identity;
                    //listOfChildrenOfModel[iter2].transform.position = Vector3.zero;
                    //listOfChildrenOfModel[iter2].transform.localScale = listOfChildrenOfAnimation[iter2].transform.localScale;
                    iter2 = listOfChildrenOfBodyModel.Count;
                }
            }
        }
    }

    IEnumerator FinishModel()
    {
        yield return new WaitForSeconds(0.3f);

        
        //headAnimation.transform.parent.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //bodyAnimation.transform.parent.transform.position = finishedModel.transform.position;
        //bodyAnimation.transform.root.transform.parent = finishedModel.transform;

        
    }

    private void GetChildRecursiveForBodyModel(GameObject obj)
    {
        if (null == obj)
        {
            return;
        }

        for (int iter = 0; iter < obj.transform.childCount; iter++)
        {
            if (null == obj.transform.GetChild(iter).gameObject)
            {
                continue;
            }
            //child.gameobject contains the current child you can do whatever you want like add it to an array
            listOfChildrenOfBodyModel.Add(obj.transform.GetChild(iter).gameObject);
            GetChildRecursiveForBodyModel(obj.transform.GetChild(iter).gameObject);
        }
    }

    private void GetChildRecursiveForBodyAnimation(GameObject obj)
    {
        if (null == obj)
        {
            return;
        }

        for (int iter = 0; iter < obj.transform.childCount; iter++)
        {
            if (null == obj.transform.GetChild(iter).gameObject)
            {
                continue;
            }
            //child.gameobject contains the current child you can do whatever you want like add it to an array
            listOfChildrenOfBodyAnimation.Add(obj.transform.GetChild(iter).gameObject);
            GetChildRecursiveForBodyAnimation(obj.transform.GetChild(iter).gameObject);
        }
    }

}
