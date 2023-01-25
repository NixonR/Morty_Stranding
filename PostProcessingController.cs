using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    Animator anim;
    RainScript rainScript;
    [SerializeField]PostProcessVolume psControl;
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rainScript = GameObject.FindGameObjectWithTag("rainMain").GetComponent<RainScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rainScript.moduleEnabled == true)
        {
            if (psControl.weight <= 1f)
            {
                psControl.weight += 0.2f * Time.deltaTime;
                //Debug.Log(psControl.weight);

            }


        }
        if (rainScript.moduleEnabled == false)
        {
            if (psControl.weight >= 0.1f)
            {
                psControl.weight -= 0.2f * Time.deltaTime;

            }
            //Debug.Log("subtract");

        }
    }
}
