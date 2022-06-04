using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Button))]

// The additional items in this list allow us to respond to mouse / touch events
public class HeldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    // We will store our button here so we can use it
    private Button button;

    // Use this to track if button is pressed
    private bool buttonPressed = false;

    // This function is called when the user first clicks the button
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!button.interactable) return;

        // Record that the button is being pressed
        buttonPressed = true;
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
    }




    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (buttonPressed)
        {
            button.onClick?.Invoke();
        }
    }
}
