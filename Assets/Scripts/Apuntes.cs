using UnityEngine;

public class Apuntes : MonoBehaviour
{
    //accesibilidad (public/private), tipo de variable, nombre de la variable, (Opcional) valor
    private bool boleano = true; // bool = puede ser o true o false (1 o 0)
    public int numEntero = 5; // int = numeros enteros
    [SerializeField] //Aparece en el inspector pero no es publica
    private float numDecimalFalso = 5.5f; // float = numero decimal falso (flotante, porque guarda el numero de decimales)
    private string cadenasTexto = "Cinco"; // string = Cadenas de caracteres
    private char character = 'c'; // char = un unico caracter
    private double numDecimal = 5.5; // double = guarda dons ints, el de antes de la coma i el de despues
    private Vector3 vector3D = new Vector3 (5, 5, 5); // vector de 3 dimensiones (x, y, z)
    private Vector2 vector2D = new Vector2(5, 5); //vector de 2 dimensiones (x, y)
    private Transform trans;
    private MeshRenderer meshRend;

    //accesibilidad, tipo de metodo, Nombre del metodo, parametros ()
    //Awake se ejecuta antes de todo
    private void Awake()
    {
        //Debug.Log("AWAKE");
    }

    // se ejecuta quando se activa el objeto
    private void OnEnable()
    {
        //Debug.Log("ONENABLED");
    }
    // se ejecuta cuando se desactiva el objeto
    private void OnDisable()
    {
        //Debug.Log("OnDisabled");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("START");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("UPDATE");
    }

    // Cada un tiempo fijo (en project setings = time) se ejecuta si o si
    void FixedUpdate()
    {
        //Debug.Log("FIXEDUPDATE");
    }

    // Se ejecuta la final del frame
    void LateUpdate()
    {
        //Debug.Log("LATEUPDATE");
    }

    private void Locura()
    {
        Debug.Log("Hola mundo");
    }
}
