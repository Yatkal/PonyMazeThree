using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerScript : MonoBehaviour {

    public static AnimationManagerScript instance;

    GameObject dominantAnimation;
    GameObject slaveAnimation;
    GameObject dominantCharacter;
    GameObject slaveCharacter;

    void Start () {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	void SetUpAnimationCharacters(AnimationSetObject animationSet)
    {
        string animationPath = "Animations/" + animationSet.animationName;
        //set up the first animation character
        dominantCharacter.GetComponent<CreateBaseCharacterScript>().CreateCharacter(animationSet.dominantCharacterName);
        //set up the second animation character
        slaveCharacter.GetComponent<CreateBaseCharacterScript>().CreateCharacter(animationSet.slaveCharacterName);
        //spawn in an animation object for each character
        dominantAnimation = (GameObject)Resources.Load(animationPath + "Dom");
        slaveAnimation = (GameObject)Resources.Load(animationPath + "Sub");
        //put the animation in the right place
        dominantAnimation.transform.position = animationSet.dominantPosition;
        slaveAnimation.transform.position = animationSet.slavePosition;

        //link the animation and the model
        gameObject.GetComponent<AnimationLinkScript>().LinkAnimationToModel(dominantAnimation.name, dominantCharacter.name);
        gameObject.GetComponent<AnimationLinkScript>().LinkAnimationToModel(slaveAnimation.name, slaveCharacter.name);
    }

    public void MoveAnimationForwardOne()
    {
        //check to see if we're at the end of the animation

        //if not move the animation stage forward one
    }

    public void MoveAnimationBackOne()
    {
        //check to see if we're at the beginning of the animation

        //if not move the animation stage back one
    }

    public void AutoAnimation()
    {

    }

    public void HideUi()
    {

    }
}
