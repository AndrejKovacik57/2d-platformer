using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect_items : MonoBehaviour
{
    public static int globalScore = 0;
    public static int score = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource collectSound;
    private void Start()
    {
        scoreText.text = "Score: " + globalScore;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            CollectableBehaviour(collision, 500);
        }
        if (collision.gameObject.CompareTag("Apple"))
        {
            CollectableBehaviour(collision, 1000);
        }
        if (collision.gameObject.CompareTag("Bannana"))
        {
            CollectableBehaviour(collision, 2000);
        }
    }

    private void CollectableBehaviour(Collider2D collision, int scoreToAdd)
    {
        collectSound.Play();
        Destroy(collision.gameObject);
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
