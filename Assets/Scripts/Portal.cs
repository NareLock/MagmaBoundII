using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private CameraController controller;
    [SerializeField]
    private Transform teleporte;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            teleporte.position = new Vector3(-2.73f, 2.29f, 0);
            controller.portal += 1;
        }
    }
}
