using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainTrigger : MonoBehaviour
{
    [HideInInspector]public bool isInside = false;
    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        isInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isInside = false;

    }
}
