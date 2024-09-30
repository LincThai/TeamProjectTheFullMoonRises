using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // set variables
    // references
    [Header("References")]
    public GameObject dialogueBox;
    public TMP_Text dialogueText;

    // text
    [Header("Text")]
    [TextArea(3, 10)]
    public string dialogue;

    private void OnTriggerEnter(Collider other)
    {
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueBox.SetActive(false);
    }
}
