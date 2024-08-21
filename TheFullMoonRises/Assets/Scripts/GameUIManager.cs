using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    // reference UI elements
    public GameObject BookUI;

    private void Start()
    {
        ResetGameUI();
    }

    // Update is called once per frame
    private void Update()
    {
        // when the e key is pressed 
        if (Input.GetKeyDown(KeyCode.E))
        {
            // will activate or deativate the BookUI
            BookUI.SetActive(!BookUI.activeSelf);
        }
    }

    public void ResetGameUI()
    {
        BookUI.SetActive(false);
    }
}
