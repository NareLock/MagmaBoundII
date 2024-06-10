using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Collider2D HitKill;
    public bool isDead;
    //public Rigidbody2D meteorRb;


    //public class MeteorSpawn;
    public GameObject MeteorDown;
    public Transform[] spawnPoints;
    public int totalMeteors = 15;
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private Rigidbody2D _meteorRB;

    //public object Position { get; private set; }

    //private Transform[] GetSpawnPoints()
    //{
    //    return spawnPoints;
    //}

    // Start is called before the first frame update
    private void Start()
    {
        //Position = new Vector3();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void SpawnCoins()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Obtém a posição do ponto de spawn
            Vector3 spawnPosition = spawnPoint.position;
            // Define a profundidade do eixo Z
            spawnPosition.z = -0.2f;

            Instantiate(MeteorDown, spawnPosition, Quaternion.identity);
        }
    }


    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D HitKill)
    {
        {
            if (HitKill.gameObject.CompareTag("Player"))
            {
                Destroy(HitKill.gameObject);
                isDead = true;
            }

            if (isDead == true)
            {
                SceneManager.LoadScene("GameOverScene");

            }

            if (HitKill.gameObject.CompareTag("Ground"))
            {
                _meteorRB.constraints = RigidbodyConstraints2D.FreezeAll;
                _anim.SetBool("DestruirPedrinha", true);
                Destroy(gameObject, .5f);

                //Destroy(gameObject);
            }
        }
    }
}
