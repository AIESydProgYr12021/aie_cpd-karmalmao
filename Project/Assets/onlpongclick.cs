using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onlpongclick : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    public UnityEvent onLongClick;


    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("On pointer Down");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("onpoiunterup");
    }

    private void Update()
    {
        if (pointerDown)
        {
            if (onLongClick != null)
                onLongClick.Invoke();

            //Reset(); //i have a feeling this wont work
        }
    }
    private void Reset()
    {
     pointerDown = false;
    }
}
