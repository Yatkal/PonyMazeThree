using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class AnimationLinkScript : MonoBehaviour {

    public GameObject headAnimation;
    public GameObject bodyAnimation;
    GameObject bodyModel;
    GameObject headModel;
    GameObject finishedModel;
    List<GameObject> listOfChildrenOfBodyModel;
    List<GameObject> listOfChildrenOfHeadModel;
    List<GameObject> listOfChildrenOfBodyAnimation;
    List<GameObject> listOfChildrenOfHeadAnimation;

    // Use this for initialization
    void Start () {
        listOfChildrenOfBodyModel = new List<GameObject>();
        listOfChildrenOfHeadModel = new List<GameObject>();
        listOfChildrenOfBodyAnimation = new List<GameObject>();
        listOfChildrenOfHeadAnimation = new List<GameObject>();
        finishedModel = new GameObject("Model");
        bodyAnimation = GameObject.Find("UnparentedBodyWalk").transform.GetChild(0).gameObject;
        headAnimation = GameObject.Find("UnparentedHeadWalk").transform.GetChild(0).gameObject;
        bodyModel = transform.FindChild("SoriaModel(Clone)").gameObject;
        headModel = transform.FindChild("Octavia(Clone)").gameObject;

        GetChildRecursiveForBodyModel(bodyModel);
        GetChildRecursiveForHeadModel(headModel);
        GetChildRecursiveForBodyAnimation(bodyAnimation);
        GetChildRecursiveForHeadAnimation(headAnimation);

        MatchAnimationToModel();

        StartCoroutine(FinishModel());

        //Debug.Log("NUMBER OF CHILDREN");
        //Debug.Log(listOfChildrenOfAnimation.Count);
	}

    void MatchAnimationToModel()
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
                    //listOfChildrenOfModel[iter2].transform.localRotation = Quaternion.identity;
                    //listOfChildrenOfModel[iter2].transform.localPosition = Vector3.zero;
                    //listOfChildrenOfModel[iter2].transform.rotation = Quaternion.identity;
                    //listOfChildrenOfModel[iter2].transform.position = Vector3.zero;
                    //listOfChildrenOfModel[iter2].transform.localScale = listOfChildrenOfAnimation[iter2].transform.localScale;
                    iter2 = listOfChildrenOfBodyModel.Count;
                }
            }
        }

        for (int iter = 0; iter < listOfChildrenOfHeadAnimation.Count; iter++)
        {
            for (int iter2 = 0; iter2 < listOfChildrenOfHeadModel.Count; iter2++)
            {
                if (listOfChildrenOfHeadAnimation[iter].name == listOfChildrenOfHeadModel[iter2].name)
                {
                    //listOfChildrenOfModel[iter2].transform.DetachChildren();
                    listOfChildrenOfHeadModel[iter2].transform.parent = listOfChildrenOfHeadAnimation[iter].transform;
                    listOfChildrenOfHeadModel[iter2].AddComponent<AlwaysAtParentScript>();
                    //listOfChildrenOfModel[iter2].transform.localRotation = Quaternion.identity;
                    //listOfChildrenOfModel[iter2].transform.localPosition = Vector3.zero;
                    //listOfChildrenOfModel[iter2].transform.rotation = Quaternion.identity;
                    //listOfChildrenOfModel[iter2].transform.position = Vector3.zero;
                    //listOfChildrenOfModel[iter2].transform.localScale = listOfChildrenOfAnimation[iter2].transform.localScale;
                    iter2 = listOfChildrenOfHeadModel.Count;
                }
            }
        }
    }

    IEnumerator FinishModel()
    {
        yield return new WaitForSeconds(0.3f);

        headAnimation.transform.root.transform.parent = finishedModel.transform;
        bodyAnimation.transform.root.transform.parent = finishedModel.transform;

        headAnimation.transform.parent.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        bodyAnimation.transform.parent.transform.position = Vector3.zero;
        headAnimation.transform.parent.transform.position = Vector3.zero;
        headAnimation.transform.parent.transform.Rotate(0.0f, 180.0f, 180.0f);
        headAnimation.transform.parent.transform.position = new Vector3(-0.52f, -1.4f, -17.76f);
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

    private void GetChildRecursiveForHeadModel(GameObject obj)
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
            listOfChildrenOfHeadModel.Add(obj.transform.GetChild(iter).gameObject);
            GetChildRecursiveForHeadModel(obj.transform.GetChild(iter).gameObject);
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

    private void GetChildRecursiveForHeadAnimation(GameObject obj)
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
            listOfChildrenOfHeadAnimation.Add(obj.transform.GetChild(iter).gameObject);
            GetChildRecursiveForHeadAnimation(obj.transform.GetChild(iter).gameObject);
        }
    }
}
