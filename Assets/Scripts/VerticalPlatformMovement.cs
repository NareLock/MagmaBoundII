using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatformMovement : MonoBehaviour
{
    private Vector3 startPosition; // Posi��o inicial da plataforma
    public float velocidade = 1f; // Velocidade de movimento da plataforma
    public float distancia = 7f; // Dist�ncia m�xima de movimento da plataforma

    private float atrasoInicial; // Atraso inicial para come�ar o movimento da plataforma

    void Start()
    {
        startPosition = transform.position; // Armazena a posi��o inicial da plataforma
        atrasoInicial = Random.Range(0f, 2f); // Define um atraso inicial aleat�rio
    }

    void Update()
    {
        if (Time.time >= atrasoInicial)
        {
            // Calcula o movimento da plataforma usando a fun��o PingPong para criar um movimento de ida e volta
            float movimento = Mathf.PingPong((Time.time - atrasoInicial) * velocidade, distancia * 2) - distancia;
            // Atualiza a posi��o da plataforma adicionando o movimento vertical
            transform.position = startPosition + Vector3.up * movimento;
        }
    }
}

