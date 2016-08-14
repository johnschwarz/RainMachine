using UnityEngine;
using System.Collections;

public class CloudKill : MonoBehaviour {

    

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "cloud")
        {
            
            Destroy(other.transform.parent.gameObject);
        }
    }
}
