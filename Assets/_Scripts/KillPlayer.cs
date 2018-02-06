using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public Vector3 playerRespawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.gameObject.transform.position = playerRespawn; }
    }
    
 
    
}
