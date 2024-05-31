using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidade = 5;
    [SerializeField] private float alturaDoPulo = 30;
    [SerializeField] private Transform castPoint;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D playerRb;
    private Animator anim;
    private bool isGrounded;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Verifica se o jogador está no chão
        isGrounded = Physics2D.OverlapCircle(castPoint.position, 0.2f, groundLayer);

        // Se o jogador estiver no chão, aplica o pulo
        if (isGrounded)
        {
            // Zera a velocidade vertical antes de aplicar o pulo
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
            playerRb.AddForce(new Vector2(0, alturaDoPulo), ForceMode2D.Impulse);
        }

        // Movimento horizontal
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(movimentoHorizontal * velocidade, playerRb.velocity.y);

        // Limita a velocidade vertical para evitar a acumulação excessiva de força
        if (playerRb.velocity.y > alturaDoPulo)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, alturaDoPulo);
        }
    }
}
