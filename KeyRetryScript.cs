using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRetryScript : MonoBehaviour
{

    NewPlayer newPlayer;
    public GameObject Key;
    public GameObject Key2;
    public bool PinkWall1 = true;

    // Start is called before the first frame update
    void Start()
    {
        newPlayer = GameObject.Find("Player").GetComponent<NewPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        RetryKey();
    }


    public void RetryKey()
    {
        if (newPlayer.inventoryCount > 0 && Input.GetButtonDown("Throw"))
        {
            if (PinkWall1 == true)
            {
                Key.SetActive(true);
                Debug.Log("udalo sie");
            }

            
            
            
        }
    }
}
