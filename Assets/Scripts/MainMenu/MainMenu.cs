using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        EventBroker.CallPlaySound("theme");
    }
    public void Play()
    {
        EventBroker.CallPlaySound("click");

        SceneManager.LoadScene("StartingScene");
    
    }

    public void Quit()
    {
        EventBroker.CallPlaySound("close");
        Application.Quit();
    }
}
