using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUpdate : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] MortyController mc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = mc.mortyHealth.ToString() + " HP";
    }
}
