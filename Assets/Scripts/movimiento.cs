using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    [SerializeField]
    private float velocidad;
    [SerializeField]
    private float FuerzaSalto;
    [SerializeField]
    private int maxSaltos = 2; // Máximo número de saltos permitidos

    private Rigidbody rb;
    private int saltosRestantes;
    private bool enElSuelo;

    private Vida vida;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vida = GetComponent<Vida>();
        saltosRestantes = maxSaltos;
    }

    // Update is called once per frame
    void Update()
    {
        var ejeXcontrol = Input.GetAxis("Horizontal");
        var ejeYcontrol = Input.GetAxis("Vertical");

        var vectorMovimiento = new Vector3(ejeXcontrol, 0, ejeYcontrol);

        transform.Translate(vectorMovimiento * Time.deltaTime * velocidad);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (saltosRestantes > 0)
            {
                var impulso = new Vector3(0, FuerzaSalto, 0);
                rb.AddForce(impulso, ForceMode.Impulse);

                saltosRestantes--; // Disminuye el número de saltos restantes
            }
        }
    }

    public void tomarDaño()
    {
        if (vida.getVida() == 0)
        {
            morir();
        }
    }

    public void morir(){
        SceneManager.LoadScene("1");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Permite saltar en cualquier superficie que esté en contacto
        enElSuelo = true;
        saltosRestantes = maxSaltos; // Restablece los saltos cuando está en el suelo
    }

    private void OnCollisionExit(Collision collision)
    {
        // Si el jugador ya no está en contacto con una superficie
        enElSuelo = false;
    }
}
