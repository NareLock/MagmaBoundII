using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float velocidade = 5;
    [SerializeField] private float alturaDoPulo = 10;

    private Rigidbody2D playerRb;
    private Animator anim;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (transform.position.y > collision.transform.position.y)
        {
            Pular();
        }
    }

    private void Pular()
    {
        playerRb.velocity = Vector2.up * alturaDoPulo;
    }

    private void LateUpdate()
    {
        anim.SetFloat("velocidade", Mathf.Abs(playerRb.velocity.x));
    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(movimentoHorizontal * velocidade, playerRb.velocity.y);
    }

} 
