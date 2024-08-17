using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject nextButton;

    private void Start()
    {
        intitialState();
    }

    public void intitialState()
    {
        for (int i = 0; i < pages.Count; i++) 
        {
            pages[i].transform.rotation = Quaternion.identity;
        }
        pages[0].SetAsLastSibling();
        backButton.SetActive(false);
    }

    public void RotateNext()
    {
        if (rotate == true) 
        {
            return;
        }
        index++;
        float angle = 180;
        NextButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));
    }

    public void NextButtonActions() 
    {
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true);
        }
        if (index == pages.Count - 1)
        {
            nextButton.SetActive(false);
        }
    }

    public void RotatePrev()
    {
        if (rotate == true)
        {
            return;
        }
        float angle = 0;
        backButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, false));
    }

    public void backButtonActions()
    {
        if (nextButton.activeInHierarchy == false) 
        {
            nextButton.SetActive(true);
        }
        if (index - 1 == -1) 
        {
            backButton.SetActive(false);
        }
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0;
        while (true) 
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler( 0, angle, 0 );
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation);
            if (angle1 < 0.1f)
            {
                if (forward == false) 
                {
                    index--;
                }
                rotate = false;
                break;
            }
            yield return null;
        }
    }
}
