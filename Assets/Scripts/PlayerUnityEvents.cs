using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerUnityEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent myTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
