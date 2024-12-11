using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valor = 1;  // Valor de la moneda (puedes cambiarlo si quieres que la moneda dé más puntos)

    // Detecta la colisión con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Verifica que el objeto que colisiona tenga la etiqueta "Player"
        {
            // Aumenta el puntaje
            GameManager.instance.AgregarPuntos(valor);

            // Destruye la moneda
            Destroy(gameObject);
        }
    }
}
