using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

public class HighLight : MonoBehaviour
{

    Image image;
    bool over = false;
    MortyController mc;
    float mortyHealth;
    bool damage;
    Animator anim;


    // Start is called before the first frame update
    void Awake()
    {
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MortyController>();
        image = gameObject.GetComponent<Image>();
        mortyHealth = mc.mortyHealth;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        DamageHighlight();
       

    }

    public async void DamageHighlight()
    {

        if(mortyHealth > mc.mortyHealth)
        {
            anim.SetBool("Damage", true);

            await Task.Delay(1000);

            anim.SetBool("Damage", false);
            mortyHealth = mc.mortyHealth;
        }


    }


}
