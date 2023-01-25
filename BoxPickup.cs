using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPickup : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject infoSprite;
    [SerializeField] BoxManager boxManager;
    bool isInTrigger = false;


    void Start()
    {
        boxManager = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInTrigger == true && boxManager.boxNumber < 5)
        {
            boxManager.boxNumber = boxManager.boxNumber + 1;
            Debug.Log("your box here");
            Destroy(gameObject);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            infoSprite.SetActive(true);
            isInTrigger = true;



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            infoSprite.SetActive(false);
            isInTrigger = false;
        }
    }

}
