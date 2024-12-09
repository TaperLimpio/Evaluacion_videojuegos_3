using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    [SerializeField]
    private float sensibilidadX = 10f;
    [SerializeField]
    private float sensibilidadY = 10f;
    [SerializeField]
    private Transform playerBody; // El cuerpo del jugador

    private float rotacionX = 0f;

    void Start()
    {
        // Oculta el cursor y lo bloquea dentro de la ventana del juego
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Verifica si playerBody está asignado
        if (playerBody == null)
        {
            Debug.LogError("El campo playerBody no está asignado en el Inspector.");
            return;
        }

        // Obtén la entrada del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadX;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadY;

        // Calcula la rotación en Y
        playerBody.Rotate(Vector3.up * mouseX);

        // Calcula la rotación en X
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f); // Limita la rotación vertical
        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
    }

    void OnApplicationFocus(bool focus)
    {
        // Oculta y bloquea el cursor cuando el juego gana foco
        if (focus)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void OnApplicationPause(bool pause)
    {
        // Asegura que el cursor se muestre si la aplicación se pausa
        if (pause)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
