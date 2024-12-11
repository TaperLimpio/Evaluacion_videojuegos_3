using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    [SerializeField] public Text coinText;

    [SerializeField] private int canMonedas = 0;
    private Vida vida;
    
    void Start(){
        vida = GetComponent<Vida>();
    }
    
    public void obteneMoneda(int val){
        this.canMonedas += val;
        coinText.text = "Monedas: " + canMonedas.ToString();
    }
}
