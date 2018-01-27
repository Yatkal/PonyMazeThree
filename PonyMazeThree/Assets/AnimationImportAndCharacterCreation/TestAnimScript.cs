using UnityEngine;
using System.Collections;

public class TestAnimScript : MonoBehaviour {

    Animator anim;
    Coroutine routine;
    // Use this for initialization
    void Start () {

        Debug.Log("Beginning Animation Test");
        anim = GetComponent<Animator>();
        routine = StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update () {

        if (routine == null)
        {
            if (anim)
            {
                Debug.Log("Start animation");

                anim.Play("Play");
                Destroy(this);
            }
            else
            {
                Debug.Log("Error no animator detected.");
                Destroy(this);
            }
        }
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        routine = null;
    }
}
