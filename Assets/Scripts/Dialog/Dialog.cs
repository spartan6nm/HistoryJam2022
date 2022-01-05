using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public DialogBody[] dialogs;

    [SerializeField]
    private Text DialogText;



    [SerializeField]
    private float typingSpeed;

    private int indexSentences;
    private int indexDialogs;

    private void Start()
    {
        
    }

    IEnumerator Type()
    {
        foreach (var letter in dialogs[indexDialogs].sentences[indexSentences].ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (indexSentences < dialogs[indexDialogs].sentences.Length)
        {
            indexSentences++;
            DialogText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            //TODo this dialog is compelte
        }
    }

    public void NextDialog()
    {
        if (indexSentences >= dialogs[indexDialogs].sentences.Length)
        {
            indexSentences = 0;
            indexDialogs++;
            DialogText.text = "";
            StartCoroutine(Type());
        }
        
    }
         

}
