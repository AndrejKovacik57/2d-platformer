using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private AudioSource finishSound;
    private bool levelComplete = false;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelComplete)
        {
            finishSound.Play();
            Collect_items.globalScore += Collect_items.score;
            //call level after 2s
            Invoke("CompleteLevel", 0.5f);
            levelComplete = true;
           
        }
    }
    private void CompleteLevel()
    {
        //change level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
