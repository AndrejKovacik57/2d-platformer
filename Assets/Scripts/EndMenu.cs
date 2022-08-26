using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonClickSound;
    public void Quit()
    {
        Debug.Log("koniec");
        buttonClickSound.Play();
        Application.Quit();
        
    }
}
