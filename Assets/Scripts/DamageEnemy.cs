using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy")){
            Debug.Log("Juagador dañado por el enemigo");
        }
    }
}
