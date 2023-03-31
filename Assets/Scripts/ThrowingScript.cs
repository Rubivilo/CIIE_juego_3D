using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowingScript : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;

    bool readyToThrow;
    float  throwUpwardForce;

    private void Start()
    {
        readyToThrow = true;
        throwUpwardForce = (float).05;
    }

    private void Update()
    {
        if(Input.GetKey(throwKey) && readyToThrow && totalThrows > 0 && throwUpwardForce < 8)
        {
            throwUpwardForce+=(float).05;
            
        }
        else if(Input.GetKeyUp(throwKey) && readyToThrow && totalThrows > 0 || throwUpwardForce >= 8)
        {
            Throw();
        }
        print(throwUpwardForce);
    }

    private void Throw()
    {
        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
        throwUpwardForce=(float).05;
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}