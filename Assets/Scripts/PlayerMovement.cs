using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
<<<<<<< HEAD
{   
    private Animator animador;
    [SerializeField] float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
=======
{
    private Animator animator;
    [SerializeField] float velocidad;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

>>>>>>> d021421aec7355024030f23fe8eea980d701e64c
    void Update()
    {
        float ejeX = Input.GetAxis("Horizontal");
        float ejeY = Input.GetAxis("Vertical");
<<<<<<< HEAD
        var vectorMovimiento = new Vector3(ejeX,0,ejeY).normalized * Time.deltaTime;
        transform.Translate(vectorMovimiento * velocidad);

=======
        // Al crear un Vector3() con .normalized lo que logramos es que el personaje no se mueva
        // más rápido al usar los ejes diagonales.
        var vectorMovimiento = new Vector3(ejeX, 0, ejeY).normalized * Time.deltaTime;
        transform.Translate(vectorMovimiento * velocidad);

        animator.SetFloat("x", ejeX);
        animator.SetFloat("y", ejeY);

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("saltar");
        }
>>>>>>> d021421aec7355024030f23fe8eea980d701e64c
    }
}
