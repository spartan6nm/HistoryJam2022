using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Item ceramic1;
    public Item ceramic2;


    private static bool _khanTalking = false;

    public static bool khanTalking
    {
        get { return _khanTalking; }
        set
        {
            _khanTalking = value;
            //TODO Lunch the gate scene and enable khan conversation
            //Disale RoomButtons
        }
    }

    private static bool _water = false;

    public static bool water
    {
        get { return _water; }
        set
        {
            _water = value;
            //TODO Lunch the gate scene and enable khan conversation
            //Disale RoomButtons
        }
    }

    private static bool _plants = false;

    public static bool plants
    {
        get { return _plants; }
        set
        {
            _plants = value;
            //TODO Lunch the gate scene and enable khan conversation
            //Disale RoomButtons
        }
    }

    private static bool _geometry = false;

    public static bool geometry
    {
        get { return _geometry; }
        set
        {
            _geometry = value;
            //TODO Lunch the gate scene and enable khan conversation
            //Disale RoomButtons
        }
    }

    private static bool _accident = false;

    public static bool accident
    {
        get { return _accident; }
        set
        {
            _accident = value;
            //TODO Lunch the gate scene and enable khan conversation
            //Disale RoomButtons
        }
    }

    private static bool _puzzle = false;

    public static bool puzzle
    {
        get { return _puzzle; }
        set
        {
            _puzzle = value;
            //TODO Lunch the gate scene and enable khan conversation
            //Disale RoomButtons
        }
    }



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
        Invoke("MusicCheck", 0f);
        EventBroker.CallPlaySound("waterSound");
        EventBroker.CallPlaySound("treeSound");
        if (geometry == false)
        {
            SceneManager.LoadScene("Geometry");
        }
    }
    public void Left()
    {
        EventBroker.CallPlayerStop();
        int x = SceneManager.GetActiveScene().buildIndex;
        if (x > 2)
        {
            if (x == 3 && khanTalking == true && accident == false)
            {
                SceneManager.LoadScene("puzzleAccident");
                return;
            }
            SceneManager.LoadScene(x - 1);
        }
        if (SceneManager.GetActiveScene().buildIndex != 4)
        {
            MusicStop();

            Invoke("MusicCheck", 0.3f);
        }

    }

    public void Right()
    {
        EventBroker.CallPlayerStop();
        int x = SceneManager.GetActiveScene().buildIndex;
        if (x < 5)
        {
            if (x == 2 && water == false)
            {
                SceneManager.LoadScene("Water");
                return;
            }
            else if(x == 3 && plants == false)
            {
                SceneManager.LoadScene("Plants");
                return;
            }
            else if (x == 4 && khanTalking == false)
            {
                MusicStop();
                EventBroker.CallPlaySound("4");
                SceneManager.LoadScene("Khan");
                return;
            }
            SceneManager.LoadScene(x + 1);
            
        }
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            MusicStop();

            Invoke("MusicCheck", 0.3f);
        }
    }

    public void MusicCheck()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                EventBroker.CallPlaySound("1");
                break;
            case 3:
                EventBroker.CallPlaySound("23");
                break;
            case 4:
                EventBroker.CallPlaySound("23");
                break;
            case 5:
                EventBroker.CallPlaySound("4");
                break;
        }
    }

    public void MusicStop()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                EventBroker.CallStopSound("1");
                break;
            case 3:
                EventBroker.CallStopSound("23");
                break;
            case 4:
                EventBroker.CallStopSound("23");
                break;
            case 5:
                EventBroker.CallStopSound("4");
                break;
            case 6:
                EventBroker.CallStopSound("puzzle");
                break;
            case 7:
                EventBroker.CallStopSound("1");
                break;
            case 11:
                EventBroker.CallStopSound("23");
                break;
        }
    }


}
