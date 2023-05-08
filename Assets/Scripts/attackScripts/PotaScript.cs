using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotaScript : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject barfCilinder;

    [Header("Settings")]
    public int vomitLevels;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;

    bool readyToThrow;
    float length;
    private Vector3 scaleChange = new Vector3(0,0.1f,0);
    private Vector3 OGscale = new Vector3(0.2f,0,0.2f);
    float aux=0;
    private Vector3 posFix = new Vector3(0,-0.2f,0);
    
    private void Start()
    {
        barfCilinder.SetActive(false);
        readyToThrow = true;
    }
    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("COLLISION");
        
    }
    // Update is called once per frame
    void Update()
    {
        barfCilinder.transform.SetPositionAndRotation(cam.position,cam.rotation);
        posFix = new Vector3(0, -0.2f, aux);
        barfCilinder.transform.Translate(posFix);
       
        barfCilinder.transform.Rotate(90,0,0);
        if(Input.GetKey(throwKey) && readyToThrow && vomitLevels > 0 )
        {
            barfCilinder.SetActive(true);
            Vomit();
            
        }
        else if(Input.GetKeyUp(throwKey) && readyToThrow && vomitLevels > 0 )
        {
            barfCilinder.SetActive(false);
            barfCilinder.transform.localScale=OGscale;
            aux = 0;
        }
    }


    private void Vomit()
    {
        if (aux < 3)
        {
            barfCilinder.transform.localScale += scaleChange;
            aux += 0.1f;
        }
    }
}
