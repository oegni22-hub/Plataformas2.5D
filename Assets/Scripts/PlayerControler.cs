using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    private bool isGrounded=true;
    [SerializeField] private GameObject tochitosPrefab;
    [SerializeField] private GameObject moneda;

    private Vector3 startPos;

    private LevelManager lm;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward*speed*Time.deltaTime, Space.World);
            transform.eulerAngles = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.back * speed*Time.deltaTime, Space.World);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "tocho")
        {
            isGrounded = true;
        }

        if (col.gameObject.tag == "tocho")
        {
            if (col.GetContact(0).normal == Vector3.down)
            {
                //instantiate (objeto a instanciar, posicion, rotacion, (opcional) el transform del padre)
                GameObject clone = Instantiate(tochitosPrefab, col.transform.position, col.transform.rotation);
                Destroy(col.gameObject);
                Destroy(clone, 3); 
                Instantiate(moneda, col.transform.position, col.transform.rotation);
            }
        }

        if (col.gameObject.tag == "plataform")
        {
            transform.parent = col.transform;
            isGrounded = true;
        }

        if (col.gameObject.tag == "enemy")
        {
            if (col.GetContact(0).normal.y > 0.5f)
            {
                Destroy(col.gameObject);
                Instantiate(moneda, col.transform.position, col.transform.rotation);
                rb.AddForce(Vector3.up * jumpForce * 0.5f);
            }
            else
            {
                MuertePlayer();
            }
        }

        if (col.gameObject.tag == "meta")
        {
            lm.FinishLevel();
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "plataform")
        {
            transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            GameManager.instance.gameData.totalCoins += 1;
            lm.UpdateCoinsText();
        }

        if (col.gameObject.tag == "muerte")
        {
            MuertePlayer();
        }
    }

    private void MuertePlayer()
    {
        //quitamos 1 vida
        GameManager.instance.gameData.totalLives -= 1;
        if (GameManager.instance.gameData.totalLives < 0)
        {
            lm.ActivatePanelGameOver();
        }
        else
        {
            transform.position = startPos;
            lm.UpdateLivesText();
        }
    }
    
}
