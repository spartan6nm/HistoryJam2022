using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public void Left()
    {
        Manager.Instance.Left();
    }

    public void Right()
    {
        Manager.Instance.Right();

    }
}
