using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionTest : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // The object we collided with
        GameObject otherObject = collision.gameObject;

        // We can get the NAME of the object
        string objectName = otherObject.name;

        // We can get the TAG of the object
        string objectTag = otherObject.tag;

        // We can get the LAYER of the object
        int layer = otherObject.layer;

        // We can check if a script is attached to the object, and get it
        // Getting a component from the other object
        SpriteRenderer spriteRenderer = otherObject.GetComponent<SpriteRenderer>();


        Debug.Log("Collision");
        Debug.Log("Name: " + objectName);
        Debug.Log("Tag: " + objectTag);
        Debug.Log("Layer: " + objectTag);

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.green;
        }

        
        
    }

}
