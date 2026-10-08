using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private bool tonto;
    [SerializeField] private float moveSpeed;
    private bool playerDetected;
    
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
}
