using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using TMPro;

public class MortyController : PhysicsObject
{


    [SerializeField] float jumpPow = 2;
    [SerializeField] float slowSpeed;
    [SerializeField] float mediumSpeed;
    public float fastSpeed;
    [SerializeField] float maxSpeed = 1;

    [SerializeField] float turnRight;
    [SerializeField] float turnLeft;

    [SerializeField] float fallValue;
    [SerializeField] float airValue;

    private RaycastHit2D downRay;
    [SerializeField] private Vector2 rayOffsetValue;
    [SerializeField] private float rayLength = 2;
    public bool facingRight = true;

    Animator anim;

    public float mortyHealth = 100f;
    public float mortyStamina = 10f;

    GameObject rightArmLimb;
    Transform armTarget;
    Weapon weapon;

    public int ammo = 20;
    public int maxAmmo = 20;
    public int actualBullets;

    float escape;
    [SerializeField] bool isJumping;
    [SerializeField] float jumpForce = 4f;
    [SerializeField] float jumpTimeCounter;
    [SerializeField] float jumpTime = 2f;
    Rigidbody2D rb;

    [SerializeField] float jumpTakeOffSpeed;

    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI stamina;
    int hpConverted;
    int staminaConverted;

    float timerStamina;









    // Start is called before the first frame update
    void Start()
    {

        //rightArmLimb = GameObject.FindGameObjectWithTag("RightArmLimb");
        anim = GetComponent<Animator>();
        weapon = gameObject.GetComponent<Weapon>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hpConverted = (int)mortyHealth;
        hp.text = hpConverted.ToString();
        staminaConverted = (int)mortyStamina;
        stamina.text = staminaConverted.ToString();


        PlayerMovement();

        targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * maxSpeed, targetVelocity.y);
        RotatePlayer();

        DrawRayFromPlayer();

        ExitApp();

        PlayerJump();



    }

    public async void PlayerJump()
    {
        if (downRay.collider != null)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }

        maxSpeed = mediumSpeed;

        if (Input.GetButtonDown("Jump") && downRay.collider != null || Input.GetKeyDown(KeyCode.W) && downRay.collider != null)
        {
            velocity.y = jumpTakeOffSpeed;
        }

        else if (Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.W))
        {
            if (velocity.y > 0)
            {
                await Task.Delay(100);
                velocity.y = velocity.y * 0.3f;

            }
        }
    }

    public void PlayerMovement()
    {

        if (downRay.collider == null)
        {
            anim.SetBool("air", true);
        }
        else
        {
            anim.SetBool("air", false);
        }

        if (velocity.y < fallValue)
        {
            anim.SetBool("fall", true);
        }
        else
        {
            anim.SetBool("fall", false);
        }



        //Debug.Log(Input.GetKey(KeyCode.A));



        if (Input.GetButton("Ctr") && !Input.GetButton("Shift") || Input.GetKey(KeyCode.S) && !Input.GetButton("Shift"))
        {
            anim.SetBool("ctr", true);
            maxSpeed = slowSpeed;
        }
        else
        {
            anim.SetBool("ctr", false);

        }
        if (Input.GetButton("Shift") && !Input.GetButton("Ctr") && mortyStamina > 0f || Input.GetButton("Shift") && !Input.GetKey(KeyCode.S) && mortyStamina > 0f)
        {
            anim.SetBool("shift", true);
            maxSpeed = fastSpeed;
            mortyStamina -= 0.5f * Time.deltaTime;
            timerStamina = 0f;
        }
        else
        {
            anim.SetBool("shift", false);

            if (mortyStamina > 10f)
            {
                mortyStamina = 10f;
            }

            if (Input.GetButton("Shift") == false)
            {
                timerStamina += Time.deltaTime;
                if (timerStamina > 4f)
                {
                    mortyStamina += 1f * Time.deltaTime;

                }
            }

            if (mortyStamina < 0f)
            {
                mortyStamina = 0f;
            }
            if(Input.GetButton("Ctr") == false && Input.GetKeyDown(KeyCode.S))
            maxSpeed = mediumSpeed;

        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == false)
        {
            anim.SetBool("walk", true);

        }
        else if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == true)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);

        }

        anim.SetFloat("velocityX", Mathf.Abs(velocity.x));
        anim.SetFloat("velocityY", velocity.y);

        if (Input.GetButtonDown("Reload") && weapon.gunOpenCheck == true && weapon.bullets < 3 && ammo > 0/* && ammo > 0 || weapon.bullets == 0 && weapon.gunOpenCheck == true && ammo > 0*/ )
        {
            //rightArmLimb.SetActive(false);

            anim.SetTrigger("reload");


            if (ammo > 0)
            {
                actualBullets = (3 - weapon.bullets);
                weapon.bullets += actualBullets;
                ammo -= actualBullets;

            }
            /*else
            {
                weapon.bullets += ammo;
                ammo -= ammo;
            }*/

        }

        if (ammo < 0)
        {
            ammo = 0;
        }
        if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

    }


    void RotatePlayer()
    {
        if (velocity.x > 0.01f && facingRight == false)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = true;

        }
        else if (velocity.x < -0.01f && facingRight == true)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = false;

        }

    }

    void DrawRayFromPlayer()
    {
        downRay = Physics2D.Raycast(new Vector2(transform.position.x + rayOffsetValue.x, transform.position.y + rayOffsetValue.y), Vector2.down * rayLength, rayLength);
        Debug.DrawRay(new Vector2(transform.position.x + rayOffsetValue.x, transform.position.y + rayOffsetValue.y), Vector2.down * rayLength, Color.green);

    }
    void ExitApp()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            escape += Time.deltaTime;
        }

        if (escape > 2)
        {
            SceneManager.LoadScene(1);
        }
    }

}
