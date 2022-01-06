using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        if (PlayerPrefs.HasKey("playedBefore"))
        {
            //TODO go to the first game scene
        }
        else
        {
            //TODO go for starting story
        }
    }
}
