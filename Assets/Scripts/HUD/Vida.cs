using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public float vidaActual;
    public float vidaMax;
    public Image barraVida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        barraVida.fillAmount = vidaActual / vidaMax;
    }
}
