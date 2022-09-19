using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBelow : MonoBehaviour { 

    void Start() { 
    
        
    }

    
    void Update() { 

       if (transform.position.y < -20) {
            Destroy(gameObject);
        }
    
        
    }
}
