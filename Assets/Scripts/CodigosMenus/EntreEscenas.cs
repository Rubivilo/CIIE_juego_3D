using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreEscenas : MonoBehaviour
{
    public static EntreEscenas instancia;
    private void Awake()
    {
        if (instancia)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
