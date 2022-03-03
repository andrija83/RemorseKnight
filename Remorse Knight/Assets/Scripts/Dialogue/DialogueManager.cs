using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject[] choises;
    private TextMeshProUGUI[] choisesText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        choisesText = new TextMeshProUGUI[choises.Length];
        int index = 0;
        foreach (var item in choises)
        {
            choisesText[index] = item.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
        if (InputPLayer.GetInstance().GetSubmitPressed()) 
        {
            ContinueStory();
        }
    }
    public void EnterDialogueMode(TextAsset inkJSOn)
    {
       currentStory = new Story(inkJSOn.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();


    }
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            //DisplayChoises();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.3f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    //private void DisplayChoises()
    //{
    //    //List<Choice> currentChoises = currentStory.currentChoices;
    //    if (currentChoises.Count > choises.Length)
    //    {
    //        Debug.Log("MORE choises were given then UI can support" + currentChoises.Count);
    //    }
    //    int index = 0;
    //    foreach (Choice choice in currentChoises)
    //    {
    //        choises[index].gameObject.SetActive(true);
    //        choisesText[index].text = choice.text;
    //        index++;
    //    }
    //    for (int i = index; i < choises.Length; i++)
    //    {
    //        choises[i].gameObject.SetActive(false);
    //    }
    //}

   


    public static DialogueManager GetInstance() =>  instance;

}
