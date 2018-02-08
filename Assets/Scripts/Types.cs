using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum AlienReaction
{
    HAPPY_1,
    HAPPY_2,
    NOT_HAPPY_1,
    NOT_HAPPY_2,
    CONFUSED_1,
    CONFUSED_2,
    NOT_CONFUSED_1,
    NOT_CONFUSED_2,
    HUNGRY_1,
    HUNGRY_2,
    NOT_HUNGRY_1,
    NOT_HUNGRY_2
}

public enum Idea
{
    FRIEND,
    HUMAN,
    ALIEN,
    TRANSFER,
    SIGN_SYMBOL,
    GOD_MEANING,
    TIME_SAND,
    TENTACLE_LEG,
    ENERGY_FLOW,
    MARRIAGE_CAPTIVITY,
    BEAUTY,
    CRAZY_CONFUSION,
    EARTH,
    HOME,
    ACTION,
    WEAPON,
    VISION,
    FEAR,
    FREDDY_MERCURY,
    NOTHING_NOT_DEATH,
    LIFE_POSITIVE,
    NEED_NUTRITION,
    UNKOWN,
    VOID
};




public enum AlienState
{
    IDLE,
    ANIMATION_TRIGGERED
};





public class Types : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public enum EndState
{
    HAPPY,
    NOT_HAPPY,
    CONFUSED,
    NOT_CONFUSED,
    HUNGRY,
    NOT_HUNGRY,
    VOID
}

public enum CaracType
{
    HAPPINESS,
    CONFUSION,
    HUNGRINESS
}