using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Will run only after all the updates are done
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
