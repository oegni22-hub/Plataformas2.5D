using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody rb;
    [SerializeField]
    private float jumpForce;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
