using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidade = 5;
    [SerializeField] private float alturaDoPulo = 10;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    private Rigidbody2D playerRb;
    private Animator anim;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Verifica se o jogador está colidindo com a camada do chão
        if (((1 << collision.gameObject.layer) & groundLayer) != 0 && transform.position.y > collision.transform.position.y)
        {
            Pular();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se colidiu com uma parede
        if (((1 << collision.gameObject.layer) & wallLayer) != 0)
        {
            // Obtém o ponto médio da colisão para calcular a direção oposta
            Vector2 collisionPoint = collision.contacts[0].point;
            Vector2 playerPosition = transform.position;
            Vector2 oppositeDirection = (playerPosition - collisionPoint).normalized;

            // Aplica uma força contrária ao jogador
            playerRb.AddForce(oppositeDirection * velocidade, ForceMode2D.Impulse);
        }
    }


    private void Pular()
    {
        playerRb.velocity = Vector2.up * alturaDoPulo;
    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(movimentoHorizontal * velocidade, playerRb.velocity.y);

        if (playerRb.velocity.y > alturaDoPulo)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, alturaDoPulo);
        }
    }
}