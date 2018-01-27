using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManagerScript : MonoBehaviour {

    public static AudioManagerScript instance;

    public GameObject soundObjectPrefab;
    public GameObject musicObjectPrefab;

    Coroutine musicSwapCoroutine;

    public GameObject currentBackgroundMusic;

    List<AudioClip> backgroundMusics;
    List<AudioClip> sounds;

    bool needToChange;
    string cachedSoundName;

	// Use this for initialization
	void Start ()
    {
        backgroundMusics = new List<AudioClip>();
        sounds = new List<AudioClip>();
        currentBackgroundMusic = null;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {

            Destroy(gameObject);
        }
        musicSwapCoroutine = null;
        needToChange = false;

    }

    void LateUpdate()
    {
        if(needToChange == true && musicSwapCoroutine == null)
        {
            musicSwapCoroutine = StartCoroutine(FadeOutThenIn(cachedSoundName));
            needToChange = false;
            cachedSoundName = null;
        }
        else
        {

        }
    }

    public void CreateNewSound(string soundName)
    {
        AudioClip clip = null;

        for (int iter = 0; sounds.Count > iter; iter++)
        {
            if (soundName == sounds[iter].name)
            {
                clip = sounds[iter];
            }
        }

        GameObject temp = Instantiate(soundObjectPrefab);
        temp.GetComponent<AudioSource>().volume = Options.GlobalOptionsSettingsScript.instance.GetFXVolume();
        temp.GetComponent<AudioSource>().clip = clip;
    }

    public void CreateNewSoundAtPosition(string soundName, Transform thisTransform)
    {
        AudioClip clip = null;

        for (int iter = 0; sounds.Count > iter; iter++)
        {
            if (soundName == sounds[iter].name)
            {
                clip = sounds[iter];
            }
        }

        GameObject temp = Instantiate(soundObjectPrefab);
        temp.transform.position = thisTransform.position;
        temp.GetComponent<AudioSource>().volume = Options.GlobalOptionsSettingsScript.instance.GetFXVolume();
        temp.GetComponent<AudioSource>().clip = clip;
    }

    public void CreateNewBackgroundMusic(string musicName)
    {
        if(currentBackgroundMusic == null)
        {
            //the object hasn't been created, so create it
            currentBackgroundMusic = Instantiate(musicObjectPrefab);

            currentBackgroundMusic.GetComponent<AudioSource>().volume = 0;

            if (musicSwapCoroutine == null)
            {
                musicSwapCoroutine = StartCoroutine(FadeOutThenIn(musicName));
            }
            else
            {
                cachedSoundName = musicName;
                needToChange = true;
            }
        }
        else
        {
            if (musicSwapCoroutine == null)
            {
                musicSwapCoroutine = StartCoroutine(FadeOutThenIn(musicName));
            }
            else
            {
                cachedSoundName = musicName;
                needToChange = true;
            }

        }

    }

    public void ResetMusicVolume()
    {
        currentBackgroundMusic.GetComponent<AudioSource>().volume = Options.GlobalOptionsSettingsScript.instance.GetMusicVolume();
    }

    IEnumerator FadeOutThenIn(string musicName)
    {
        //first fade out the current music
        while (currentBackgroundMusic.GetComponent<AudioSource>().volume > 0)
        {
            currentBackgroundMusic.GetComponent<AudioSource>().volume = currentBackgroundMusic.GetComponent<AudioSource>().volume - 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

        //select the new track

        for (int iter = 0; backgroundMusics.Count > iter; iter++)
        {
            if (musicName == backgroundMusics[iter].name)
            {
                currentBackgroundMusic.GetComponent<AudioSource>().clip = backgroundMusics[iter];
            }
        }


        //fade in the new music
        while (currentBackgroundMusic.GetComponent<AudioSource>().volume < Options.GlobalOptionsSettingsScript.instance.GetMusicVolume()) 
        {
            currentBackgroundMusic.GetComponent<AudioSource>().volume = currentBackgroundMusic.GetComponent<AudioSource>().volume + 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

        musicSwapCoroutine = null;
        yield return new WaitForSeconds(0.1f);
    }
}
