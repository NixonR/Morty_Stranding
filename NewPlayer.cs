using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum CarColour
{
    red,
    green,
    blue,
    yellow,
    whiteTesla,
}

public class NewPlayer : PhysicsObject
{
    //====================================================================================================================================================
    private float HP;
    [Header("Basic Stats----------------------------")]
    [SerializeField] private int maxHealth = 100;
    [Range(0f, 100f)] public int health = 50;
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] float jumpPow = 5;
    public float thrust = 100;

    [Header("Collectables----------------------------")]
    [TextArea] public string description;
    public int coinsCollected;
    public int inventoryItem;
    public int ammo;



    [Header("Text and UI----------------------------")]
    [SerializeField] TextMeshProUGUI textHP;
    public Text coinsText;
    public Image healthBar;
    [Range(-3, 3)]
    public int counter;


    Collectable collectable;



    [HideInInspector] public string KeyType;
    private Vector2 healthBarOrigSize;
    private Vector2 positionChanege;

    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();

    public Sprite keySprite;
    public Sprite keySprite2;
    public Image inventoryItemImage;
    public CarColour carColour;
    WhiteWallScript wall;

    public string actualName = "Key";
    public int inventoryCount;
    Animator anim;
    private static NewPlayer instance;
    public static NewPlayer Instance
    {
        get
        {
            if (instance == null) instance = GameObject.Find("Player").GetComponent<NewPlayer>();
            return instance;
        }
    }

    private RaycastHit2D rightRay;
    private RaycastHit2D leftRay;
    private RaycastHit2D wallRay;
    [SerializeField] private Vector2 rayOffsetValue;
    [SerializeField] private float rayLength = 2;
    [HideInInspector] public float fuel = 1f;
    private float spalanie = 1f;
    public float timer;
    [SerializeField] private GameObject attackBox;
    Vector2 currentVelocity;
    Transform wallCheck;




    //====================================================================================================================================================

    void Start()
    {
        wall = GameObject.Find("WhiteWall").GetComponent<WhiteWallScript>();
        collectable = GameObject.Find("Key1").GetComponent<Collectable>();

        healthBarOrigSize = healthBar.rectTransform.sizeDelta;

        if (carColour == CarColour.whiteTesla)
        {
            Debug.Log("White tesla");
        }
        else
            Debug.Log("other shiet");

        anim = GetComponent<Animator>();
        var currentVelocity = rb2d.velocity;
    }


    void Update()
    {

        //speed
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);

        UpdateUI();

        PlayerMovement();

        Throw();

        DrawRayFromPlayer();

        FlyingButton();

        RotatePlayer();

        //Die();
        
        
        



    }

    //=============================================================================================================================================================


    public void PlayerMovement()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("hit");
        }
        else
        {
            anim.SetBool("hit", false);
        }

        if (grounded == true)
        {
            anim.SetBool("grounded", true);
        }
        else
        {
            anim.SetBool("grounded", false);
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y += jumpPow;
        }

        if (Input.GetButtonDown("Crouch") && counter > -1)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y * 0.5f);
            counter--;
            Debug.Log("smaller");
        }
        if (Input.GetButtonDown("Bigger") && counter < 1)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y * 2f);
            counter++;
            Debug.Log("bigger");
        }
        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("walk", true);
        }
        else 
        { 
            anim.SetBool("walk", false);
        }
        if (Input.GetButton("Fly"))
        {
            anim.SetBool("fly", true);
        }
        else
        {
            anim.SetBool("fly", false);
        }
    }


    public void UpdateUI()
    {
        coinsText.text = coinsCollected.ToString();
        //Set healthBar width to a percentage of original value
        //healthBarOrigSize.x * (health/maxHealth)
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health / (float)maxHealth), healthBar.rectTransform.sizeDelta.y);

        //healthBar.rectTransform.sizeDelta = new Vector2(100, healthBar.rectTransform.sizeDelta.y);
        //textHP.text = ($"Health is equal to:{HP}");
        HP = health;

        if (HP < 70)
        {
            textHP.text = ($"<color=red>Health: {HP}</color>");
        }
        else
        {
            textHP.text = ($"<color=green>health: {HP}</color>");
        }

        if (health > 100)
            health = 100;

    }

    public void Throw()
    {

        if (Input.GetButtonDown("Throw") && inventory.ContainsKey("key1"))
        {

            Debug.Log(KeyType);
            inventory.Remove(collectable.inventoryStringName);
            KeyType = "basic";
            inventoryItemImage.sprite = wall.basicSprite;
            if (inventoryCount > 0)
            {
                inventoryCount--;
            }





        }
    }

    void DrawRayFromPlayer()
    {
        rightRay = Physics2D.Raycast(new Vector2(transform.position.x + rayOffsetValue.x, transform.position.y), Vector2.down, rayLength);
        Debug.DrawRay(new Vector2(transform.position.x + rayOffsetValue.x, transform.position.y + rayOffsetValue.y), Vector2.down * rayLength, Color.green);

        leftRay = Physics2D.Raycast(new Vector2(transform.position.x - rayOffsetValue.x, transform.position.y), Vector2.down, rayLength);
        Debug.DrawRay(new Vector2(transform.position.x - rayOffsetValue.x, transform.position.y + rayOffsetValue.y), Vector2.down * rayLength, Color.red);

       
    }

    void FlyingButton()
    {
        if (Input.GetButton("Fly") && velocity.y <= 10 && fuel >= 0)
        {
            velocity.y += 1f;

            fuel -= spalanie * Time.deltaTime;
            //Debug.Log(fuel);
            if (fuel <= 0)
            {
                velocity.y = 0f;
            }
        }


    }

    void RotatePlayer()
    {
        if (velocity.x > 0.01f)
        {
            transform.localScale = new Vector2(-1f, transform.localScale.y); ;
        }
        else if (velocity.x < -0.01f)
        {
            transform.localScale = new Vector2(1f, transform.localScale.y);

        }

        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(ActivateAttack());

        }



    }

    

    void Die()
    {
        if (HP < 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bounce"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
        
        

    }

    public IEnumerator ActivateAttack()
    {
        attackBox.SetActive(true);
        yield return new WaitForSeconds(0.15f);

        attackBox.SetActive(false);
    }
  
}

    //===================================================================================================================================================



