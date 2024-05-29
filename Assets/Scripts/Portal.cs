using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private CameraController controller;
    [SerializeField]
    private Transform teleporte;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            teleporte.position = new Vector3(-1.36f, -1.12f, 0);
            controller.portal += 1;
        }
    }
}
