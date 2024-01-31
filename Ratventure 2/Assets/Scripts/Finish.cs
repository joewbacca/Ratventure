using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private bool levelCompleted = false;

    private void Start()
    {
    }
    //If player collides with finish object next level is gona load after 1f
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)

        {
            levelCompleted = true;
            Invoke("CompleteLevel", 1f);
        }
    }
    private void CompleteLevel() //change to next level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
