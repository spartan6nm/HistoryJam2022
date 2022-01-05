using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{


    public void Left()
    {
        EventBroker.CallPlayerStop();
        int x = SceneManager.GetActiveScene().buildIndex;
        if (x != 0)
        {
            SceneManager.LoadScene(x - 1);
        }
        
    }

    public void Right()
    {
        EventBroker.CallPlayerStop();
        int x = SceneManager.GetActiveScene().buildIndex;
        Debug.LogWarning(x);
        if (x != 3)
        {
            Debug.LogWarning("mon ami");
            SceneManager.LoadScene(x + 1);
        }
        
    }
}
