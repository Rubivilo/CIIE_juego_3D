using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAenemy : MonoBehaviour
{
    public LayerMask capaDelJugador;
    public Transform jugador;
    bool estarAlerta;
    public NavMeshAgent NavMeshAgent;
    public Transform[] destinos;
    private int i = 0;
    public float rangoDeAlerta;
    public float finalDistance = 2;

    // Start is called before the first frame update
    void Start()
    {
        
        NavMeshAgent.destination = destinos[i].transform.position;
        //jugador = FindObjectOfType<StarterAssets>().GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta == true){
            FollowPlayer();
        }
        else{
            EnemyPath();
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }

    public void EnemyPath(){
        NavMeshAgent.destination = destinos[i].transform.position;
        if(Vector3.Distance(transform.position, destinos[i].position) <= finalDistance){
            if(destinos[i] != destinos[destinos.Length - 1]){
                i++;
            }
            else{
                i = 0;
            }
        }
        
    }

    public void FollowPlayer(){
        Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
        transform.LookAt(posJugador);
        NavMeshAgent.destination = posJugador;
    }
}
