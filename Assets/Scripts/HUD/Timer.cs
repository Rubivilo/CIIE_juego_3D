using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    float currentTime;
    //public float startingTime;

    [SerializeField] int min, seg;
    [SerializeField] TMP_Text tiempo;
    public string siguienteEscena;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = (min * 60) + seg;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            currentTime = 0;
            if (!string.IsNullOrEmpty(siguienteEscena))
                // Cambiar escena
                SceneManager.LoadScene(siguienteEscena);
        }
        int tempMin = Mathf.FloorToInt(currentTime / 60);
        int tempSeg = Mathf.FloorToInt(currentTime % 60);
        tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
    }
}
