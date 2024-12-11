using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounce2 : MonoBehaviour
{
    public float bounceSpeed = 8;
    public float bounceAmplitude = 0.05f;
    public float rotationSpeed = 90;

    public float moveDistance = 1f;  // Distancia a moverse cada vez (en metros)
    public float moveSpeed = 2f;     // Velocidad de movimiento en metros por segundo

    private float startHeight;
    private float timeOffset;
    private Vector3 targetPosition;  // Posición a la que se moverá el objeto
    private Vector3 startPosition;   // Posición inicial
    private bool isMoving = false;   // Para controlar si el objeto está en movimiento
    private bool movingForward = true;  // Para determinar si va hacia adelante o hacia atrás

    // Start is called before the first frame update
    void Start()
    {
        startHeight = transform.localPosition.y;
        timeOffset = Random.value * Mathf.PI * 2;

        // Inicializa la posición de inicio y el objetivo inicial
        startPosition = transform.localPosition;
        targetPosition = startPosition + new Vector3(moveDistance, 0f, 0f); // Se mueve 1 metro en la dirección X
    }

    // Update is called once per frame
    void Update()
    {
        // Si el objeto no está moviéndose, comienza el movimiento hacia el siguiente punto
        if (!isMoving)
        {
            StartCoroutine(MoveToTarget(targetPosition));
        }

        // Animación de rebote
        float finalHeight = startHeight + Mathf.Sin(Time.time * bounceSpeed + timeOffset) * bounceAmplitude;
        Vector3 position = transform.localPosition;
        position.y = finalHeight;
        transform.localPosition = position;

        // Rotación
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }

    // Corutina para mover el objeto de una posición a otra
    private IEnumerator MoveToTarget(Vector3 target)
    {
        isMoving = true; // Marca que el objeto está moviéndose

        Vector3 startPos = transform.localPosition;  // Guarda la posición inicial
        float journeyLength = Vector3.Distance(startPos, target);  // Distancia entre las posiciones
        float startTime = Time.time;  // Tiempo de inicio del movimiento

        while (Vector3.Distance(transform.localPosition, target) > 0.01f)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;  // Distancia recorrida
            float fractionOfJourney = distanceCovered / journeyLength;  // Fracción del recorrido completada

            transform.localPosition = Vector3.Lerp(startPos, target, fractionOfJourney);  // Interpolación del movimiento

            yield return null;  // Espera un frame antes de continuar el loop
        }

        transform.localPosition = target; // Asegura que el objeto llegue exactamente al destino
        isMoving = false;  // Marca que el objeto ha llegado a su destino

        // Después de llegar al destino, cambia la dirección del movimiento
        if (movingForward)
        {
            targetPosition = startPosition;  // Regresa a la posición inicial
        }
        else
        {
            targetPosition = startPosition + new Vector3(moveDistance, 0f, 0f);  // Se mueve un metro más en la dirección positiva
        }

        movingForward = !movingForward;  // Cambia la dirección del movimiento
    }
}
