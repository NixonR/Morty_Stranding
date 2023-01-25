using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookOnMouse : MonoBehaviour
{
    [SerializeField] Camera cam;
    private Transform aimTransform;
    public Transform trBone;
    GameObject player;
    [SerializeField] Weapon wp;
    float angle;
    Vector3 mousePosition;
    Vector3 aimDirection;


    public float angleRef;
    // Start is called before the first frame update
    private void Awake()
    {
        aimTransform = GameObject.Find("Aim").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        aimDirection = (mousePosition - transform.position).normalized;
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;


        
        
            LookOnMouse();
        
        
        //float angle = Mathf.Abs(angleRaw);
        angleRef = angle;



        //Debug.Log(angle);
        //Debug.Log(mousePosition);
    }

    void LookOnMouse()
    {
        
        //==============================================================================================================================
        if (angle < 140f && angle > 90f)
        {
            angle = 140f;
            //Debug.Log("1111111111111111111111111111111111111111111");
            trBone.eulerAngles = new Vector3(0, 0, angle - 90f);
        }
        if (angle < 90f && angle > 40f )
        {
            angle = 40f;
           // Debug.Log("22222222222222222222222222222222222222222222222222222222222222222");
            trBone.eulerAngles = new Vector3(0, 0, angle + 90f);
        }
        if (angle == 90f)
        {
            angle = 45f;
            //Debug.Log("3333333333333333333333333333333333333333333333333333333");
        }
        //==============================================================================================================================
        if (angle > -150f && angle < -90f)
        {
            angle = -150f;
            trBone.eulerAngles = new Vector3(0, 0, angle - 90f);
            //Debug.Log("4444444444444444444444444444444444444444444444444");
        }
        if (angle > -90f && angle < -50f)
        {
            angle = -50f;
            trBone.eulerAngles = new Vector3(0, 0, angle + 90f);
            //Debug.Log("5555555555555555555555555555555555555555555555555555");
        }
        if (angle == -90f)
        {
            //Debug.Log("666666666666666666666666666666666666666666666");
            angle = -45f;
            trBone.eulerAngles = new Vector3(0, 0, -45);
        }
        //==============================================================================================================================
        

        if (mousePosition.x < player.transform.position.x && angle > 140f)
        {
            trBone.eulerAngles = new Vector3(0, 0, angle - 90f);
            //trBone.eulerAngles = new Vector3(0, 0, angle );
           // Debug.Log("7777777777777777777777777777777777777777777777777777777777777777");
        }
        if (mousePosition.x < player.transform.position.x && angle < -140f)
        {
            trBone.eulerAngles = new Vector3(0, 0, angle - 90f);
            //trBone.eulerAngles = new Vector3(0, 0, angle );
            //Debug.Log("88888888888888888888888888888888888888888888888888888");
        }

        if (mousePosition.x > player.transform.position.x && angle < 90f)
        {
            trBone.eulerAngles = new Vector3(0, 0, angle + 90f);
            //trBone.eulerAngles = new Vector3(0, 0, angle);
            //Debug.Log("999999999999999999999999999999999999999999999999999999");
        }

        if (mousePosition.x > player.transform.position.x && angle < -90f)
        {
            trBone.eulerAngles = new Vector3(0, 0, angle - 90f);
            //trBone.eulerAngles = new Vector3(0, 0, angle);
            //Debug.Log("999999999999999999999999999999999999999999999999999999");
        }


        if (mousePosition.x == player.transform.position.x)
        {
            //Debug.Log("1333333331111111111111111111111113333333333333333333333");
            trBone.eulerAngles = new Vector3(0, 0, angle + 90f);
        }

        if(trBone.eulerAngles.z < -100f)
        {
            Debug.Log("333333333333333333335555555555555555555555555");
            Debug.Log("jason mendoza");
            trBone.eulerAngles = new Vector3(0, 0, 40f);
        }


    }



}
