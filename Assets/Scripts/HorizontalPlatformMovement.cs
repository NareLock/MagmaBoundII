using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatformMovement : MonoBehaviour
{
    private Vector3 startPosition; // Posi��o inicial da plataforma
    public float velocidade = 2f; // Velocidade plataforma
    public float distancia = 4f; // Dist�ncia m�xima

    private float atrasoInicial;

    void Start()
    {
        startPosition = transform.position;
        atrasoInicial = Random.Range(0f, 2f);
    }

    void Update()
    {
        if (Time.time >= atrasoInicial)
        {
            float movimento = Mathf.PingPong((Time.time - atrasoInicial) * velocidade, distancia * 2) - distancia;
            transform.position = startPosition + Vector3.right * movimento;
        }
    }
}

