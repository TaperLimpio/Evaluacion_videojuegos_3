using UnityEngine;
using UnityEngine.AI;  // Necesario para trabajar con NavMesh

public class EnemyAI : MonoBehaviour
{
    public float detectionRadius = 10f;   // Radio de detección.
    public Transform player;              // Referencia al jugador.
    public float stopDistance = 2f;       // Distancia mínima para detenerse cerca del jugador.
    public float maxChaseDistance = 15f;  // Distancia máxima para perseguir (fuera de esta distancia, el enemigo deja de perseguir).

    private bool isChasing = false;       // Si el enemigo está persiguiendo.
    private NavMeshAgent agent;           // Componente NavMeshAgent
    private Animator animator;            // Componente Animator del enemigo

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Obtener el componente NavMeshAgent del enemigo
        animator = GetComponent<Animator>();  // Obtener el componente Animator del enemigo
    }

    void Update()
    {
        // Comprobar la distancia entre el enemigo y el jugador.
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de detección y el enemigo no está persiguiendo, comienza la persecución.
        if (distanceToPlayer <= detectionRadius && !isChasing)
        {
            isChasing = true;
            Debug.Log("Jugador detectado. Comienza a perseguir.");
            animator.SetBool("isRunning", true);  // Activar la animación de correr
        }

        // Si el jugador está fuera del rango de detección y el enemigo lo estaba persiguiendo, deja de perseguir.
        if (distanceToPlayer > detectionRadius && isChasing)
        {
            isChasing = false;
            agent.ResetPath();  // Detenemos al enemigo si sale del rango de persecución.
            animator.SetBool("isRunning", false);  // Detener la animación de correr
            Debug.Log("Jugador fuera de alcance. Deteniendo persecución.");
        }

        // Si el enemigo está persiguiendo al jugador.
        if (isChasing)
        {
            // Si el jugador está dentro del radio de persecución, mover al enemigo hacia el jugador.
            if (distanceToPlayer > stopDistance && distanceToPlayer <= maxChaseDistance)
            {
                agent.SetDestination(player.position); // El NavMeshAgent calcula el camino automáticamente.
            }
            else if (distanceToPlayer <= stopDistance)
            {
                // Detenerse al alcanzar la distancia de parada.
                agent.ResetPath();
                animator.SetBool("isRunning", false);  // Detener la animación de correr
                Debug.Log("Enemigo alcanzó al jugador.");
            }

            // Si el enemigo se aleja demasiado del jugador (fuera del radio máximo de persecución), se detiene.
            if (distanceToPlayer > maxChaseDistance)
            {
                isChasing = false;
                agent.ResetPath();
                animator.SetBool("isRunning", false);  // Detener la animación de correr
                Debug.Log("Jugador demasiado lejos. Persecución detenida.");
            }
        }
    }

    // Detecta si el jugador entra en el área de detección.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Asegúrate de que el jugador tenga el tag "Player".
        {
            isChasing = true; // Empieza a perseguir al jugador.
            animator.SetBool("isRunning", true);  // Activar la animación de correr
            Debug.Log("Jugador detectado. Comienza a perseguir.");
        }
    }

    // Detecta si el jugador sale del área de detección.
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false; // Detiene la persecución.
            agent.ResetPath(); // Detiene el movimiento del agente.
            animator.SetBool("isRunning", false);  // Detener la animación de correr
            Debug.Log("Jugador fuera de alcance.");
        }
    }
}
