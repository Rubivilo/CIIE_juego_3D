using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnContact : MonoBehaviour
{
    public GameObject originalObject;
    public GameObject brokenObject;

    private GameObject brknObj;
    // Start is called before the first frame update
   

    void OnCollisionEnter (Collision other){
        Debug.Log("si entra");
        if (originalObject != null ){
            originalObject.SetActive(false);
            if (brokenObject != null){
                brknObj=Instantiate(brokenObject) as GameObject ;
                brknObj.transform.position=originalObject.transform.position;
                brknObj.transform.rotation=originalObject.transform.rotation;
                Destroy(brknObj, 5);

            }
        }
    }
    // Update is called once per frame
    
}
