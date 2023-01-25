using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpStaminaBarController : MonoBehaviour
{
    MortyController mc;
    [SerializeField] Image hp;
    [SerializeField] Image stamina;

    float hpValue;
    float staminaValue;

    void Start()
    {

        mc = gameObject.GetComponent<MortyController>();
    }



    // Update is called once per frame
    void Update()
    {
        ConvertValues();
        hp.fillAmount = hpValue;
        stamina.fillAmount = staminaValue;


    }

    void ConvertValues()
    {
        hpValue = mc.mortyHealth / 100f;
        staminaValue = mc.mortyStamina / 10f;
    }
}
