using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public string targetScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if we collided with player
        if (collision.CompareTag("Player"))
        {
            // Change scene
            SceneManager.LoadScene(targetScene);
        }


    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
