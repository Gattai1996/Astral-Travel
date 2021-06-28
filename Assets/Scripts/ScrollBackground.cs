using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private Transform cameraPosition;

    private void Awake()
    {
        cameraPosition = Camera.main.transform;
    }

    private void Update()
    {
        if (cameraPosition.position.y - transform.position.y > 1000)
        {
            Vector3 position = transform.position;
            position.y += 2000;
            transform.position = position;
        }
    }
}
