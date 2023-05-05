using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour
{
    public ControladorOpciones panelOpciones;
    public ControladorInicio panelInicio;

    // Start is called before the first frame update
    void Start()
    {
        panelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControladorOpciones>();
        panelInicio = GameObject.FindGameObjectWithTag("Inicio").GetComponent<ControladorInicio>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().name != "Menu") & (Input.GetKeyDown(KeyCode.Escape)))
        {
            MostrarOpciones();
        }
    }

    public void MostrarOpciones()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (panelInicio==null)
                panelInicio = GameObject.FindGameObjectWithTag("Inicio").GetComponent<ControladorInicio>();
            panelInicio.pantallaInicio.SetActive(!panelInicio.pantallaInicio.activeSelf);
        }
            
        panelOpciones.pantallaOpciones.SetActive(!panelOpciones.pantallaOpciones.activeSelf);
    }
}
