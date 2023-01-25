using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RainScript : MonoBehaviour
{
    private ParticleSystem ps;
    public bool moduleEnabled;
    GameObject playerObject;
    public Animator anim;
    RainTrigger rTrigger;
    

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
        rTrigger = gameObject.GetComponentInParent<RainTrigger>();
    }

    void Update()
    {
        ChangeWeather();
        var emission = ps.emission;
        

    }

    void OnGUI()
    {
        moduleEnabled = GUI.Toggle(new Rect(25, 45, 100, 30), moduleEnabled, "Enabled");
    }

    void ChangeWeather()
    {
        if (rTrigger.isInside == true && moduleEnabled == false )
        {
            moduleEnabled = true;
            anim.SetBool("moduleEnabled", true);

        }
        else if (rTrigger.isInside == false && moduleEnabled == true)
        {
            moduleEnabled = false;
            anim.SetBool("moduleEnabled", false);
        }
            
    }
    




}
