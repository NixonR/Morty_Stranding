using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{

    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject box5;

    public int boxNumber = 1;
    float holdingRTime = 0f;
    [SerializeField] GameObject boxDroppedRef;
    Vector2 spawnTransform;
    Vector2 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoxNumberManage();
        BoxDropping();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SpawnLocation();
        //Debug.Log(holdingRTime);



    }

    void BoxNumberManage()
    {
        switch (boxNumber)
        {

            case 1:
                box2.SetActive(false);
                box3.SetActive(false);
                box4.SetActive(false);
                box5.SetActive(false);
                break;

            case 2:
                box2.SetActive(true);
                box3.SetActive(false);
                box4.SetActive(false);
                box5.SetActive(false);
                break;

            case 3:
                box2.SetActive(true);
                box3.SetActive(true);
                box4.SetActive(false);
                box5.SetActive(false);
                break;

            case 4:
                box2.SetActive(true);
                box3.SetActive(true);
                box4.SetActive(true);
                box5.SetActive(false);
                break;

            case 5:
                box2.SetActive(true);
                box3.SetActive(true);
                box4.SetActive(true);
                box5.SetActive(true);
                break;
        }
    }

    void BoxDropping()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            holdingRTime += 1f * Time.deltaTime;
        }
        if(holdingRTime >= 2f && boxNumber > 1)
        {
            boxNumber -= 1;
            Instantiate(boxDroppedRef, spawnTransform, boxDroppedRef.transform.rotation);
            holdingRTime = 0f;
        }

        if (!Input.GetKey(KeyCode.Q))
        {
            holdingRTime = 0f;
            
        }
    }

    void SpawnLocation()
    {
        if(mousePos.x < gameObject.transform.position.x)
        {
            spawnTransform = new Vector2(transform.position.x - 1, transform.position.y + 1);
            //Debug.Log("PRAWA STRONA");
        }
        else if(mousePos.x > gameObject.transform.position.x)
        {
            spawnTransform = new Vector2(transform.position.x + 1, transform.position.y + 1);
            //Debug.Log("PRAWA STRONA");
        }

    }

}
