using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    public float velocidad;
    private int contador;
    private AudioSource pop;
    public TextMeshProUGUI textoContador, textoGanar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pop = GetComponent<AudioSource>();
        contador = 0;
        textoGanar.text = "";
        setTextoContador();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

        rb.AddForce(movimiento * velocidad);
        
        
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            setTextoContador();
            pop.Play();
        }
    }
    void setTextoContador()
    {
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            textoGanar.text = "¡Ganaste!";
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
     
        //Wait for 5 seconds
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");



    }


}
