using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnContact : MonoBehaviour
{
    public GameObject originalObject;
    public GameObject brokenObject;
    public int rotation;

    private GameObject brknObj;
    // Start is called before the first frame update
    

    void OnCollisionEnter (Collision other){
        
        if (originalObject ){
            
            originalObject.SetActive(false);
            if (brokenObject){
                brknObj=Instantiate(brokenObject) as GameObject ;
                brknObj.transform.SetPositionAndRotation(originalObject.transform.position,originalObject.transform.rotation);
                
                Destroy(brknObj, 5);
                Destroy(originalObject, 5);
                
            }
        }
        
    }
    // Update is called once per frame
    private void Update(){
        if (originalObject.activeSelf){
            originalObject.transform.Rotate(rotation,0,0);
        }
    }

}
