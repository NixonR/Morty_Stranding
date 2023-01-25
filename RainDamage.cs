using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDamage : MonoBehaviour
{
    public RainScript rainScript;
    public MortyController morty;
    public Helmet helmet;
    [SerializeField] Animator anim;


    [SerializeField] float checkIfInDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        helmet.hoodieTimer -= 0.1f;

        if(other.tag == "rainMain" && helmet.sign == false)
        {
            morty.mortyHealth -= 0.1f;

            
            
        }
        

    }
    


}
