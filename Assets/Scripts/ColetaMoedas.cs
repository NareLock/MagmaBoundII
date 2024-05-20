using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ColetaMoedas : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private int collectedCoins = 0;
    public bool gameOver = false;

    float timer = 60f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moeda"))
        {
            Destroy(other.gameObject);
            collectedCoins++;

            if (collectedCoins >= 10)
            {
                Debug.Log("Voc� coletou todas as moedas!");
                //Anima��o do personagem ganhando
            }
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Time Left: " + (int)timer;

        if (timer <= 0)
        {
            GameOver();
        }
    }

    private void Start()
    {
        //Invoke("GameOver", 25f);
    }

    private void GameOver()
    {
        if (collectedCoins < 10)
        {
            Debug.Log("Tempo esgotado! Voc� n�o coletou todas as moedas a tempo.");
            //Carregar anim��o de morte e depois tela de game over
            Destroy(gameObject);
            gameOver = true;

            if (gameOver == true)
            {
                SceneManager.LoadScene("GameOverScene");

            }
        }
    }
}




