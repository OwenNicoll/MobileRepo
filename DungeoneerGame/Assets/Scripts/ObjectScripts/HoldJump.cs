using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class HoldJump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   

    // We will store our button here so we can use it
    private Button button;

    // Use this to track if button is pressed
    private bool buttonPressed = false;

    public bool canClick = true;

    // This function is called when the user first clicks the button
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!button.interactable) return;

        // Record that the button is being pressed
        buttonPressed = true;
        canClick = false;
        

    }


    // This funtion is called when the user moves their mouse from the button
    public void OnPointerExit(PointerEventData eventData)
    {
        // Record that the button is no longer being pressed
        buttonPressed = false;
    }


    // This funtion is called when the user releases the button
    public void OnPointerUp(PointerEventData eventData)
    {
        
        // Record that the button is no longer being pressed
        buttonPressed = false;
        canClick = true;
    }




    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (canClick && buttonPressed)
        {
            button.onClick?.Invoke();
        }
    }

}
