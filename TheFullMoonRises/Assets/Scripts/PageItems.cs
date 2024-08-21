using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageItems : MonoBehaviour
{
    // set variables
    // make lists for the checkboxes and their bools
    [SerializeField] public List<Toggle> checkBox;
    [SerializeField] public List<bool> playerAnswers;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < checkBox.Count; i++)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
