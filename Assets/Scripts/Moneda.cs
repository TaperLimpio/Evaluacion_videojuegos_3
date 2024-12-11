using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int valor = 1;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Comprobar si es una moneda
        {
            collision.gameObject.GetComponent<Inventario>().obteneMoneda(valor);
            Destroy(gameObject); // Destruir la moneda cuando es recogida
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Comprobar si es una moneda
        {
            collision.gameObject.GetComponent<Inventario>().obteneMoneda(valor);
            Destroy(gameObject); // Destruir la moneda cuando es recogida
        }
    }
}