using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Animator animador;
    [SerializeField] float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float ejeX = Input.GetAxis("Horizontal");
        float ejeY = Input.GetAxis("Vertical");
        var vectorMovimiento = new Vector3(ejeX,0,ejeY).normalized * Time.deltaTime;
        transform.Translate(vectorMovimiento * velocidad);

    }
}
