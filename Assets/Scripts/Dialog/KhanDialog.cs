using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KhanDialog : Dialog
{
    public GameObject masterImage;
    public GameObject khan1Image;


    public GameObject khan2Image;

    private void Start()
    {
        StartCoroutine(Type());
    }

    public override IEnumerator Type()
    {
        for (int i = 0; i < dialogs[indexDialogs].sentences[indexSentences].ToCharArray().Length; i++)
        {
            if (i <= 1)
            {
                continueButton.interactable = false;
            }
            else if (i >= dialogs[indexDialogs].sentences[indexSentences].ToCharArray().Length - 1)
            {
                continueButton.interactable = true;
            }
            DialogText.text += dialogs[indexDialogs].sentences[indexSentences].ToCharArray()[i];
            yield return new WaitForSeconds(typingSpeed);


        }
    }
    public override void NextSentence()
    {
        EventBroker.CallPlaySound("dialogue_advance");
        if (indexSentences < dialogs[indexDialogs].sentences.Length - 1)
        {
            StopCoroutine(Type());
            indexSentences++;
            DialogText.text = "";
            StartCoroutine(Type());
            if (indexDialogs == 2 && indexSentences == 5)
            {
                khan2Image.SetActive(true);
            }
        }
        else
        {
            if (indexDialogs >= dialogs.Length - 1)
            {
                indexDialogs = 0;
                indexSentences = 0;
                Manager.khanTalking = true;
                SceneManager.LoadScene(5);
            }
            else
            {
                NextDialog();
                if (indexDialogs == 1 && indexSentences == 0)
                {
                    khan1Image.SetActive(true);
                }
                else if (indexDialogs == 2 && indexSentences == 0)
                {
                    khan1Image.SetActive(false);
                    masterImage.SetActive(false);
                }
            }
        }
    }

    public override void NextDialog()
    {
        StopCoroutine(Type());
        indexSentences = 0;
        indexDialogs++;
        DialogText.text = "";
        StartCoroutine(Type());
    }
}
