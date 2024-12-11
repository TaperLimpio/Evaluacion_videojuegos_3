using UnityEngine;

public class RotarMoneda : MonoBehaviour
{
    public float velocidadRotacion = 100f;  // Velocidad de rotación de la moneda

    void Update()
    {
        // Rotar la moneda alrededor de su eje Y
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}
