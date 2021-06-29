using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float value;
    public float smoothing;
    public int direction = 1;
    bool isClicked;
    public KeyCode Activate;


    public void OnPointerDown(PointerEventData eventData)
    {

        isClicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        isClicked = false;
    }


    void Update()
    {

        if (Application.platform == RuntimePlatform.Android)
        {

            if (isClicked)
            {

                value = Mathf.SmoothStep(value, direction, smoothing); // value is lerping towards direction, loop=> if (value != direction) value += smoothing
            }

            else
            {

                value = Mathf.SmoothStep(value, 0, smoothing * 3);
            }

        }
        else
        {
            value = Input.GetAxis("Horizontal") *.25f;
            

        }





    }
}
