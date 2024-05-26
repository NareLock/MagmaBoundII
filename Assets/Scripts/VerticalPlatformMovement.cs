using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatformMovement : MonoBehaviour
{
    private Vector3 startPosition; // Posição inicial da plataforma
    public float velocidade = 1f; // Velocidade de movimento da plataforma
    public float distancia = 7f; // Distância máxima de movimento da plataforma

    private float atrasoInicial; // Atraso inicial para começar o movimento da plataforma

    void Start()
    {
        startPosition = transform.position; // Armazena a posição inicial da plataforma
        atrasoInicial = Random.Range(0f, 2f); // Define um atraso inicial aleatório
    }

    void Update()
    {
        if (Time.time >= atrasoInicial)
        {
            // Calcula o movimento da plataforma usando a função PingPong para criar um movimento de ida e volta
            float movimento = Mathf.PingPong((Time.time - atrasoInicial) * velocidade, distancia * 2) - distancia;
            // Atualiza a posição da plataforma adicionando o movimento vertical
            transform.position = startPosition + Vector3.up * movimento;
        }
    }
}

