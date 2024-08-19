using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    // set variables
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject nextButton;

    private void Start()
    {
        // call function to setup the initial state of the book
        intitialState();
    }

    public void intitialState()
    {
        // for every page in the page list
        for (int i = 0; i < pages.Count; i++) 
        {
            // set it's rotation to 0 as in there has been no rotation
            pages[i].transform.rotation = Quaternion.identity;
        }
        // set index 0 at the end of the list
        pages[0].SetAsLastSibling();
        // deactivate the back button as you are on the first page
        backButton.SetActive(false);
    }

    public void RotateNext()
    {
        // checks if you are currently turning the page
        if (rotate == true) 
        {
            return;
        }
        // increase index in list
        index++;
        // set the rotation 180 degrees on the y axis
        float angle = 180;
        // call function to check if the button is available on the next page
        NextButtonActions();
        // set as the last item in the list
        pages[index].SetAsLastSibling();
        // start coroutine to turn the page
        // and tell it you are moving forward
        StartCoroutine(Rotate(angle, true));
    }

    public void NextButtonActions() 
    {
        // whenever we move forward in the book
        if (backButton.activeInHierarchy == false)
        {
            // ensure the back button is activated
            backButton.SetActive(true);
        }
        // if this is the last page
        if (index == pages.Count - 1)
        {
            // deactivate the next button
            nextButton.SetActive(false);
        }
    }

    public void RotatePrev()
    {
        // checks if you are currently turning the page
        if (rotate == true)
        {
            return;
        }
        // set the rotation 0 degrees on the y axis
        float angle = 0;
        // call function to check if the button is available on the previous page
        backButtonActions();
        // set as the last item in the list
        pages[index].SetAsLastSibling();
        // start coroutine to turn the page
        // and tell it you aren't moving forward
        StartCoroutine(Rotate(angle, false));
    }

    public void backButtonActions()
    {
        // whenever we move backward in the book
        if (nextButton.activeInHierarchy == false) 
        {
            // ensure the next button is activated
            nextButton.SetActive(true);
        }
        // if this is the first page
        if (index - 1 == -1) 
        {
            // deactivate the back button
            backButton.SetActive(false);
        }
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        // create a value for the amount to lerp
        float value = 0;
        while (true) 
        {
            // tells the code you are currently turning the page
            rotate = true;
            // assign the given agle to target rotation
            Quaternion targetRotation = Quaternion.Euler( 0, angle, 0 );
            // assign to value the time multiplied by the speed of turning the page
            value += Time.deltaTime * pageSpeed;
            // smoothly turns the page
            // this is done by slowly increasing the page rotation to the target rotatiom
            // by the fraction calculated for value
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            // calculates the angle between the given angle of rotation and the current angle of rotation
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation);
            if (angle1 < 0.1f)
            {
                // if your are not moving forward/to the next page
                if (forward == false) 
                {
                    // decrease index
                    index--;
                }
                // tells the code you are no longer turning the page
                rotate = false;
                break;
            }
            yield return null;
        }
    }
}