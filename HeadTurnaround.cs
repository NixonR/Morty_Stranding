using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTurnaround : MonoBehaviour
{

    public Camera cam;
    Vector2 mousePos;
    public GameObject playerGO;
    public int hY = 1;
    public int hY2 = -1;
    MortyController mc;

    public float gY = 2.3f;
    public float gY2 = -2.3f;

    public float camX = 2.5f;
    public float camX2 = -2.5f;


    public GameObject gunOpen;
    public CinemachineVirtualCamera vcam;
    public CinemachineFramingTransposer transposer;
    [SerializeField] HeadLookOnMouse lookOnMouse;
    [SerializeField] GameObject bone2;
    [SerializeField] Weapon wp;
    [SerializeField] public Transform trBone;



    private void Awake()
    {
        gunOpen = GameObject.FindGameObjectWithTag("gunOpen");


    }
    // Start is called before the first frame update
    void Start()
    {
        transposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        mc = playerGO.GetComponent<MortyController>();


    }

    // Update is called once per frame


    void Update()
    {

        if (mc.facingRight == false)
        {


            gY = -2.3f;
            gY2 = 2.3f;

            camX = -2.5f;
            camX2 = 2.5f;
        }
        else
        {


            gY = 2.3f;
            gY2 = -2.3f;

            camX = 2.5f;
            camX2 = -2.5f;
            
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > playerGO.transform.position.x)
        {


            gunOpen.transform.localScale = new Vector2(2.3f, gY);
            transposer.m_TrackedObjectOffset = new Vector3(camX, 0);

        }

        if (mousePos.x < playerGO.transform.position.x)
        {


            gunOpen.transform.localScale = new Vector2(2.3f, gY2);
            transposer.m_TrackedObjectOffset = new Vector3(camX2, 0);
        }

        //Debug.Log(camX2);



        HeadTurningWhileAiming();

        





    }
    void TurnHeadWhenGunClosed()
    {
        if (mousePos.x < mc.transform.position.x && mc.facingRight == true)
        {
            bone2.transform.localScale = new Vector2(1f, -1f);

        }
        if (mousePos.x < mc.transform.position.x && mc.facingRight == false)
        {
            bone2.transform.localScale = new Vector2(1f, 1f);

        }

        if (mousePos.x > mc.transform.position.x && mc.facingRight == true)
        {

            bone2.transform.localScale = new Vector2(1f, 1f);
        }

        if (mousePos.x > mc.transform.position.x && mc.facingRight == false)
        {
            bone2.transform.localScale = new Vector2(1f,-1f);
        }
    }
    void HeadTurningWhileAiming()
    {
        if (Mathf.Abs(lookOnMouse.angleRef) < 90f && mc.facingRight == true)
        {
            bone2.transform.localScale = new Vector2(1f, 1f);
            //Debug.Log("1111111111111111111111111111111111111111111111");
        }

        if (Mathf.Abs(lookOnMouse.angleRef) < 90f && mc.facingRight == false)
        {
            bone2.transform.localScale = new Vector2(1f, 1f);
            //Debug.Log("2222222222222222222222222222222222222222222222222222222");
        }

        if (Mathf.Abs(lookOnMouse.angleRef) > 90f && mc.facingRight == true)
        {
            bone2.transform.localScale = new Vector2(1f, -1f);
            
        }

        if (Mathf.Abs(lookOnMouse.angleRef) > 90f && mc.facingRight == false)
        {
            bone2.transform.localScale = new Vector2(1f, -1f);
            //Debug.Log("4444444444444444444444444444444444444444444444444");
        }

        if (Mathf.Abs(lookOnMouse.angleRef) == -90f && mc.facingRight == true)
        {
            Debug.Log("5555555555555555555555555555555555555555555555555");
        }
        if (mousePos.x == mc.transform.position.x && mc.facingRight == true)
        {
            bone2.transform.localScale = new Vector2(1f, 1f);
        }
    }


}
