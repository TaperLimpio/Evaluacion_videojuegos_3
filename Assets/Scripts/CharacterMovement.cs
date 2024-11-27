using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtener la entrada del jugador para el movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular la velocidad de movimiento (magnitude es la longitud del vector, que es la "intensidad" del movimiento)
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;
        float speed = movement.magnitude * moveSpeed;

        // Actualizar el parámetro Speed en el Animator
        animator.SetFloat("Speed", speed);

        // Control de animación de correr (cuando el jugador presiona la tecla W)
        bool isRunning = Input.GetKey(KeyCode.W) && vertical > 0f;  // El jugador está presionando W y moviéndose hacia adelante
        animator.SetBool("IsRunning", isRunning);

        // Si speed es mayor que 0.1f, mover al personaje
        if (speed > 0.1f)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
