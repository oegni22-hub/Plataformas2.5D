using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject player;
    [SerializeField] private int vida;
    private bool timer;
    private float time;
    [SerializeField] private AudioClip enemyDeathSound, winSound;
    private LevelManager lm;
    [SerializeField] private GameObject bala;
    [SerializeField] private int atackSpeed;
    private GameObject balazo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        timer = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
        time += Time.deltaTime;
        
        if (time > 2)
        {
            time = 0;
            balazo = Instantiate(bala, new Vector3(transform.position.x, transform.position.y, transform.position.z +1), transform.rotation);
            Destroy(balazo, 2f);
        }
        balazo.transform.Translate(Vector3.forward * atackSpeed * Time.deltaTime);
    }
    
    public void MenysVida()
    {
        vida--;
        transform.localScale = new Vector3(gameObject.transform.localScale.x * 0.8f, gameObject.transform.localScale.y * 0.8f, gameObject.transform.localScale.z * 0.8f);
        moveSpeed += 1;
        if (vida <= 0)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 0.7f, gameObject.transform.localScale.y * 0.7f, gameObject.transform.localScale.z * 0.7f);
            Destroy(gameObject, 0.5f);
            AudioManager.instance.PlaySFX(enemyDeathSound);
            moveSpeed = 0;
            gameObject.tag = "Untagged";
            lm.FinishLevel();
            AudioManager.instance.PlaySFX(winSound);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        transform.LookAt(player.transform);
    }
}
