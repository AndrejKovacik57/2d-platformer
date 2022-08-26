using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField]
    private AudioSource sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sound.Play();
        GameManager.Instance.triggerEntered.Invoke();
    }

}
