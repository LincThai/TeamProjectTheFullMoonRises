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
        // displayes the text
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
    }

    private void OnTriggerExit(Collider other)
    {
        // closes the popup
        dialogueBox.SetActive(false);
        // destroys this object
        Destroy(gameObject);
    }
}
