using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3; //setting initial health to 3
    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

   void Awake()
    {
        health = 3; //new level should start with 3 lifes
    }

    // Changing UI hearts according to health
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < health; i++) 
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
