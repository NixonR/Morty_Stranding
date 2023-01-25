using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : MonoBehaviour
{

    Animator anim;
    bool negative = false;
    bool positive = true;

    public bool sign;
    public float hoodieTimer = 30f;

    [SerializeField] RainTrigger rainTrig;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rainTrig = GameObject.FindGameObjectWithTag("rainManager").GetComponent<RainTrigger>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rainTrig.isInside == true && hoodieTimer > 0f)
        {
            anim.SetBool("headset", true);
            sign = positive;
            //Debug.Log("positive");
        }
        if (rainTrig.isInside == false || hoodieTimer <= 0f)
        {
            anim.SetBool("headset", false);
            sign = negative;
            //Debug.Log("negative");
        }

        //if(sign == positive && hoodieTimer > 0f)
        //{
        //    hoodieTimer -= 1 * Time.deltaTime;
        //}
        if(hoodieTimer < 30f)
        {
            hoodieTimer += 1f * Time.deltaTime;
        }


    }
    


}
