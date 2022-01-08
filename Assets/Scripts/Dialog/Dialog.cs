using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public DialogBody[] dialogs;

    [SerializeField]
    private protected Text DialogText;
    [SerializeField]
    private protected Button continueButton;



    [SerializeField]
    private protected float typingSpeed;

    public static int indexSentences;
    public static int indexDialogs;



    public virtual IEnumerator Type()
    {
        yield return new WaitForSeconds(typingSpeed);
        //for (int i = 0; i < dialogs[indexDialogs].sentences[indexSentences].ToCharArray().Length; i++)
        //{
        //    if (i <= 1)
        //    {
        //        continueButton.interactable = false;
        //    }
        //    else if (i >= dialogs[indexDialogs].sentences[indexSentences].ToCharArray().Length - 1)
        //    {
        //        continueButton.interactable = true;
        //    }
        //     DialogText.text += dialogs[indexDialogs].sentences[indexSentences].ToCharArray()[i];
        //    yield return new WaitForSeconds(typingSpeed);


        //}
    }

    public virtual void NextSentence()
    {
        
    }

    public virtual void NextDialog()
    {
        
    }
         

}
