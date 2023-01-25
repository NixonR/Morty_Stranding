using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckIfOver : MonoBehaviour
{
    public GameObject particleObjectExit;
    

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


       


    }

    private void OnMouseEnter()
    {
        particleObjectExit.SetActive(true);
        
    }

    private void OnMouseExit()
    {
        particleObjectExit.SetActive(false);
        
    }



}
