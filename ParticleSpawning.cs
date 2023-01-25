using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawning : PhysicsObject
{
    public GameObject waterEffectLanding;
    public GameObject dustEffectLanding;
    bool spawnWater;
    bool spawnDust;
    public RainTrigger rainTrig;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (grounded == true)
        {
            if (rainTrig.isInside == true)
            {
                if (spawnWater == true)
                {
                    Instantiate(waterEffectLanding, new Vector2(transform.position.x, transform.position.y + 0.5f), transform.rotation);
                    spawnWater = false;


                }

            }
            else if(rainTrig.isInside == false)
            {
                if(spawnDust == true)
                {
                    Instantiate(dustEffectLanding, new Vector2(transform.position.x, transform.position.y + 0.5f), transform.rotation);
                    spawnDust = false;
                }
            }
        }
        else
        {
            spawnWater = true;
            spawnDust = true;
        }

        



    }
}
