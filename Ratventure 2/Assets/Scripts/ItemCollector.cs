using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int food = 0;

    [SerializeField] private Text foodText;

    [SerializeField] private AudioSource collectionSoundEffect;
    //if player collides with collectable item the food counter increases and the item gets destroyed
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectibles"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            food++;
            foodText.text = "Food: " +  food;
        }
    }
}
