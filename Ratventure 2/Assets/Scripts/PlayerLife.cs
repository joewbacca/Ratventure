using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerLife : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public float deathYPosition = -10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    //Method for getting hit by traps
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            HealthManager.health--;
            if(HealthManager.health <= 0) //Checking if health is zero to initialize death method
            {
                Die();
            }

            else
            {
                StartCoroutine(GetHUrt()); 
            }

        }   

    }
    IEnumerator GetHUrt() //deactivet getting hurt for 1 second by traps
    {
        Physics2D.IgnoreLayerCollision(7,8);
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    private void OnTriggerEnter2D(Collider2D collision) //Bats kill you immediately 
    {
        if (collision.gameObject.name == "Bat 1")
        {
            Die();
            RestartLevel();
        }
    }
    void Update()
    {
        if (transform.position.y < deathYPosition) //Death when falling from platform 
        {
            Die();
            RestartLevel();
        }
    }

    private void Die() //Killing player
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel() //Resets level if player dies
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
