using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private bool tonto;
    [SerializeField] private bool duro;
    [SerializeField] private float moveSpeed;
    private bool playerDetected;
    [SerializeField] private int vida;
    [SerializeField] private GameObject moneda;
    [SerializeField] private AudioClip enemyDeathSound;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerDetected = true;
        }

        if (col.gameObject.tag == "limiteEnemigo" && tonto == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        transform.eulerAngles += new Vector3(0, 180, 0);
    }

    public void MenysVida()
    {
        vida--;
        if (duro)
        {
            transform.localScale = new Vector3(1, 1, 1);
            moveSpeed += 2;
        }
        if (vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(moneda, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), moneda.transform.rotation);
            AudioManager.instance.PlaySFX(enemyDeathSound);
        }
    }
}
