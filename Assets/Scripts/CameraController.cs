using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerT;
    public Transform cameraT;

    void Update()
    {
        // Verifica se a refer�ncia para o transform do jogador n�o � nula
        if (playerT != null)
        {
            // Atualiza a posi��o da c�mera usando os limites definidos e a posi��o atual do jogador
            cameraT.position = new Vector3(
                Mathf.Clamp(playerT.position.x, -6.5f, 1.5f), // Limita a posi��o horizontal da c�mera
                Mathf.Clamp(playerT.position.y, -2.5f, 8.5f), // Limita a posi��o vertical da c�mera
                -10); // Mant�m a profundidade da c�mera fixa

            // Mathf.Clamp � usado para limitar a posi��o da c�mera dentro de valores m�nimos e m�ximos
        }
    }
}



