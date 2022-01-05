using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzlePanel : MonoBehaviour
{
    public void LoadPuzzle()
    {
        SceneManager.LoadScene("PuzzleScene");
    }
}
