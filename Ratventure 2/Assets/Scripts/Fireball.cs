using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Überprüfe, ob der Feuerball einen Gegner trifft
        if (other.CompareTag("Enemy"))
        {
            // Wenn der Feuerball einen Gegner trifft, lass den Gegner verschwinden
            Destroy(other.gameObject); // Alternativ kannst du other.gameObject.SetActive(false); verwenden, um den Gegner zu deaktivieren
        }
    }
}


