using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private float target;
    void Start()
    {
        target = transform.position.y;
        GameManager.Instance.triggerEntered.AddListener(Open);
    }


    private void OnDestroy()
    {
        GameManager.Instance.triggerEntered.RemoveListener(Open);
    }

    private void Open()
    {
        target = 1;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x,
            Mathf.MoveTowards(transform.position.y, target, Time.deltaTime));
    }
}
