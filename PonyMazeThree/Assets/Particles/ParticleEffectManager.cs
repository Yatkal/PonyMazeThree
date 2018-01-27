using UnityEngine;
using System.Collections;

public class ParticleEffectManager : MonoBehaviour {

    public static ParticleEffectManager instance;
    public GameObject sparksPrefab;

    // Use this for initialization
    void Start ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	public void SpawnParticleEffectAtLocation(string effectName, Transform thisTransform)
    {
        if(effectName == "sparks")
        {
            Instantiate(sparksPrefab).transform.position = thisTransform.position;
        }
    }
}
