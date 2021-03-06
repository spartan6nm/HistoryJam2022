using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingDialog : Dialog
{

    public GameObject ceramicSprite;

    private void Start()
    {
        //Debug.LogError(PlayerPrefs.GetInt("Played"));
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
        }
        else
        {
            if (indexDialogs >= dialogs.Length - 1)
            {
                indexDialogs = 0;
                indexSentences = 0;
                SceneManager.LoadScene(2);
            }
            else
            {

                NextDialog();
            }
        }
    }

    public override void NextDialog()
    {
        StopCoroutine(Type());
        indexSentences = 0;
        indexDialogs++;
        if (indexDialogs == 2)
        {
            Destroy(ceramicSprite);
        }
        DialogText.text = "";
        StartCoroutine(Type());
    }
}
