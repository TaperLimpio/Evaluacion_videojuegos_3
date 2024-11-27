using UnityEngine;
using UnityEngine.AI;  // Necesario si quieres usar NavMeshAgent para la navegación.

public class EnemyAI : MonoBehaviour
{
    public float detectionRadius = 10f;   // Radio de detección.
    public Transform player;              // Referencia al jugador.
    public float speed = 3.5f;            // Velocidad de movimiento del enemigo.

    private bool isChasing = false;       // Si el enemigo está persiguiendo.
    private NavMeshAgent agent;           // Agente de navegación del enemigo.

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Si usas NavMeshAgent para el movimiento.
    }

    void Update()
    {
        // Si el enemigo está persiguiendo, mueve hacia el jugador.
        if (isChasing)
        {
            agent.SetDestination(player.position); // Mueve hacia el jugador.
        }
    }

    // Detecta si el jugador entra en el área de detección.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Asegúrate de que el jugador tenga el tag "Player".
        {
            isChasing = true; // Empieza a perseguir al jugador.
            Debug.Log("Jugador detectado. Comienza a perseguir.");
        }
    }

    // Detecta si el jugador sale del área de detección.
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false; // Detiene la persecución.
            Debug.Log("Jugador fuera de alcance.");
        }
    }

    // Alternativamente, puedes usar un enfoque con raycasting si prefieres no usar triggers.
}