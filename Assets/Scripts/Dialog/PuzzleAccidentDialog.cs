using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleAccidentDialog : Dialog
{
    public GameObject masterImahe;
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

            if (indexDialogs == 1 && indexSentences == 3)
            {
                masterImahe.SetActive(false);
            }
            else
                if (indexDialogs == 1 && indexSentences == 4)
            {
                khan1Image.SetActive(true);
            }
            else
                if (indexDialogs == 1 && indexSentences == 13)
            {
                khan1Image.SetActive(false);
            }
        }
        else
        {
            if (indexDialogs >= dialogs.Length - 1)
            {
                indexDialogs = 0;
                indexSentences = 0;

                Manager.geometry = false;
                Manager.khanTalking = false;
                Manager.plants = false;
                Manager.puzzle = false;
                Manager.accident = false;
                Manager.water = false;
                Destroy(Manager.Instance);
                Destroy(FindObjectOfType<Manager>().gameObject);
                SceneManager.LoadScene(0);
            }
            else
            {
                if (indexDialogs == 0)
                {
                    Manager.Instance.MusicStop();
                    SceneManager.LoadScene("puzzle");
                    //return;
                }

                NextDialog();
                if (indexDialogs == 2 && indexSentences == 0)
                {
                    khan2Image.SetActive(true);
                    masterImahe.SetActive(true);
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
