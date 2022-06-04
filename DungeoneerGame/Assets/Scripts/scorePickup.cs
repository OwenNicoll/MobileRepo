using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorePickup : MonoBehaviour
{
    public int scoreValue = 10;

    public Text scoreDisplay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // We only want to do anything if the other object is the player

        // We'll know they are the player if the have the ScoreTotal script
        ScoreTotal scoreTotalScript = collision.GetComponent<ScoreTotal>();

         //Check if the other object has a ScoreTotal Script
        if(scoreTotalScript != null)
        {
            // Add to the players total score
            scoreTotalScript.AddScore(scoreValue);

            Destroy(gameObject);

            scoreDisplay.text = scoreValue.ToString();
        }
    }
}
