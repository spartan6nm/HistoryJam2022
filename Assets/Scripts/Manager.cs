using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private static Manager _instance;


    public List<Quest> playerQuests;

    public static Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Manager>();
            }

            return _instance;
        }
    }
    private void Awake()
    {
        

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
    private void Start()
    {
        Invoke("MusicCheck", 0.2f);
    }
    public void Left()
    {
        EventBroker.CallPlayerStop();
        int x = SceneManager.GetActiveScene().buildIndex;
        if (x != 0)
        {
            SceneManager.LoadScene(x - 1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {

        }
        else
        {
            MusicStop();

            Invoke("MusicCheck", 0.3f);
        }
        

    }

    public void Right()
    {
        EventBroker.CallPlayerStop();
        int x = SceneManager.GetActiveScene().buildIndex;
        if (x != 3)
        {
            SceneManager.LoadScene(x + 1);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {

        }
        else
        {
            MusicStop();

            Invoke("MusicCheck", 0.3f);
        }
    }

    public void MusicCheck()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                EventBroker.CallPlaySound("khan");
                break;
            case 1:
                EventBroker.CallPlaySound("tar");
                break;
            case 2:
                EventBroker.CallPlaySound("tar");
                break;
            case 3:
                EventBroker.CallPlaySound("setar");
                break;
            case 4:
                EventBroker.CallPlaySound("puzzle");
                break;
        }
    }

    public void MusicStop()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                EventBroker.CallStopSound("khan");
                break;
            case 1:
                EventBroker.CallStopSound("tar");
                break;
            case 2:
                EventBroker.CallStopSound("tar");
                break;
            case 3:
                EventBroker.CallStopSound("setar");
                break;
            case 4:
                EventBroker.CallStopSound("puzzle");
                break;
        }
    }


}
