using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float velocidade = 5;
    [SerializeField] private float alturaDoPulo = 10000;

    private Rigidbody2D playerRb;
    private Animator anim;

    private bool isGrounded;
    [SerializeField] private Transform castPoint;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        anim.SetFloat("velocidade", Mathf.Abs(playerRb.velocity.x));
    }

    /*private void OnCollisionStay2D(Collision2D collision)
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
    */
    private void Update()
    {
        // Verifica se o jogador está no chão
        isGrounded = Physics2D.OverlapCircle(castPoint.position, 0.2f, groundLayer);

        // Se o jogador estiver no chão, aplica o pulo
        if (isGrounded)
        {
            playerRb.AddForce(new Vector2(playerRb.velocity.x, alturaDoPulo));
            
        }

        // Movimento horizontal
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(movimentoHorizontal * velocidade, playerRb.velocity.y);
    }
} 
