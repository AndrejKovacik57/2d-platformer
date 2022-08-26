using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_life : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D playerBody;
    [SerializeField]
    private AudioSource deathSound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")){
            Die();
            Collect_items.score = Collect_items.globalScore;
        }
    }

    private void Die()
    {
        deathSound.Play();
        playerBody.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");      
    }

    private void LevelRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log(SceneManager.GetActiveScene().name);
    }
}
