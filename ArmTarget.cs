using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTarget : MonoBehaviour
{
    public Transform arm;
    public Camera cam;
    Vector2 mousePos;
    
    
    void Start()
    {
        //weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        arm.transform.position = mousePos;

        
        
        
    }
}
