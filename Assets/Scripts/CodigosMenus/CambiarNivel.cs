using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarNivel : MonoBehaviour
{
    // Start is called before the first frame update
    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    //Si el jugador colisiona con el objeto, cambiar escena
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            CambiarEscena("Nivel 2");
        }

    }
}
