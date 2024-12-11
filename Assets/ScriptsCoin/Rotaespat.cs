using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotarespat : MonoBehaviour
{
    public float rotationSpeed = 90f;  // Velocidad de rotación (grados por segundo)

    // Update is called once per frame
    void Update()
    {
        // Gira el objeto alrededor de su eje Z (de izquierda a derecha)
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
