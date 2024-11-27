using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Deteccion : MonoBehaviour
{
    [SerializeField] private float radioDeteccion;
    [SerializeField] private float velocidad;
    [SerializeField] private LayerMask layerJugador;
    [SerializeField] private Transform posicionJugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var detectado = Physics.CheckSphere(transform.position, radioDeteccion, layerJugador);
        if (!detectado) return;

        transform.LookAt(posicionJugador);

        var vectorPosicionJugador = new Vector3(posicionJugador.position.x,posicionJugador.position.y,
                                                posicionJugador.position.z);

        transform.position = Vector3.MoveTowards(transform.position,vectorPosicionJugador,velocidad * Time.deltaTime);
    }
}
