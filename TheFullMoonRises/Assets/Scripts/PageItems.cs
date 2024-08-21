using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageItems : MonoBehaviour
{
    // set variables
    // make list for the checkboxes and an array for their bools
    [SerializeField] public List<Toggle> checkBox;
    [SerializeField] public bool[] playerAnswers;

    // Start is called before the first frame update
    void Start()
    {
        // make the size of the array for answers equal to the
        // size of the list of toggles i.e checkboxes
        playerAnswers = new bool[checkBox.Count];
        Debug.Log(playerAnswers.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
