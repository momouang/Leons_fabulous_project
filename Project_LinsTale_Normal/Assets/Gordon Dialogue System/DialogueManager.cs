﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    
    public Animator animator;

    private Queue<string> sentences;

    public float typingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue (Dialogue dialogue) {
        Debug.Log("Starting conversation with ");

        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }


        DisplayNextSentence();

        

    }

    public void DisplayNextSentence () {
            if (sentences.Count == 0) {
                EndDialogue();
                return;
            }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text= "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    void EndDialogue () {
        Debug.Log ("End of conversation");
        animator.SetBool("IsOpen", false);
    }

}
