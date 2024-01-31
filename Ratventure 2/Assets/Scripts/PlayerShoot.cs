using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireballPrefab; 
    public Transform firePoint; // The point from where the fireball is shot

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //fireball is shot with space button
        {
            ShootFireball();
        }
    }
     //Player shoots firball method
    void ShootFireball()
    {
        // instatiate fireball and speed
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 10f; // Speed 10 frames per second in the x axis
    }
}
