using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject rightArmLimb;
    public bool bol = false;
    public GameObject gunClosed;
    public GameObject gunOpen;
    public GameObject shootParticle3;

    MortyController mr;
    Animator mrAnim;

    public int bullets = 3;
    public int maxBullets = 3;
    public bool reloading = false;



    public bool gunOpenCheck;
    bool canShoot = true;




    private void Awake()
    {
        rightArmLimb = GameObject.FindGameObjectWithTag("RightArmLimb");
    }

    // Start is called before the first frame update
    void Start()
    {

        mr = gameObject.GetComponent<MortyController>();
        mrAnim = gameObject.GetComponent<Animator>();

        
        rightArmLimb.SetActive(false);
        gunOpen.SetActive(false);


    }

    // Update is called once per frame
    async void Update()
    {

        if (Input.GetButtonDown("Weapon1") && reloading == false && bol == false)
        {
            gunClosed.SetActive(false);
            gunOpen.SetActive(true);
            rightArmLimb.SetActive(true);
            bol = true;
            Debug.Log("click");
            mr.fastSpeed = 3f;
            mrAnim.SetBool("gunOpen", true);
            gunOpenCheck = true;
            
            



        }
        else if (Input.GetButtonDown("Fire2") && reloading == false && bol == true)
        {
            gunClosed.SetActive(true);
            gunOpen.SetActive(false);
            rightArmLimb.SetActive(false);
            Debug.Log("turn off");
            mr.fastSpeed = 5f;
            mrAnim.SetBool("gunOpen", false);
            gunOpenCheck = false;
            bol = false;
        }
       



        if (bol == true && Input.GetButton("Shift"))
        {
           
            
                mrAnim.SetBool("shift", false);
                Debug.Log("shifting");
            
        }
        if (Input.GetButtonDown("Fire1") && bol == true && bullets > 0 && reloading == false && canShoot == true)
        {
            canShoot = false;
            Shoot();
            Instantiate(shootParticle3, firePoint.position, firePoint.rotation);
            await Task.Delay(400);
            canShoot = true;

        }

        if(bullets > 0)
        {
            mrAnim.SetBool("bullets", true);
        }
        else
        {
            mrAnim.SetBool("bullets", false);
        }

        
    }

    void Shoot()
    {

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullets -= 1;

    }



    
}
