using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : PhysicsObject
{

    [SerializeField] private Vector2 rayOffsetValue;
    [SerializeField] private Vector2 rayUpOffsetValue;
    [SerializeField] private float rayLength = 2;
    [SerializeField] private float rayUpLength = 0.7f;
    [HideInInspector] public float fuel = 1f;
    private RaycastHit2D rightRay;
    private RaycastHit2D leftRay;
    private RaycastHit2D upRay;
    public int direction = 1;
    public int maxSpeed = 2;
    public int HP;
    private int MaxHP = 100;
    bool isHit;
    



    // Start is called before the first frame update
    void Start()
    {
        
        HP = 100;
       
       
    }

    // Update is called once per frame
    void Update()
    {
        

        EnemyRaycastMovement();
        EnemyRaycast();
        targetVelocity = new Vector2(maxSpeed * direction, 0);
        PutinMario();
        if(HP <= 0)
        {

            gameObject.SetActive(false);
            Debug.Log("puten sruten");
        }
        
    }


    void EnemyRaycast()
    {
        rightRay = Physics2D.Raycast(new Vector2(transform.position.x + rayOffsetValue.x, transform.position.y), Vector2.down, rayLength);
        Debug.DrawRay(new Vector2(transform.position.x + rayOffsetValue.x, transform.position.y + rayOffsetValue.y), Vector2.down * rayLength, Color.green);

        leftRay = Physics2D.Raycast(new Vector2(transform.position.x - rayOffsetValue.x, transform.position.y), Vector2.down, rayLength);
        Debug.DrawRay(new Vector2(transform.position.x - rayOffsetValue.x, transform.position.y + rayOffsetValue.y), Vector2.down * rayLength, Color.red);

        upRay = Physics2D.Raycast(new Vector2(transform.position.x + rayUpOffsetValue.x, transform.position.y + rayUpOffsetValue.y), Vector2.right, rayUpLength);
        Debug.DrawRay(new Vector2(transform.position.x + rayUpOffsetValue.x, transform.position.y + rayUpOffsetValue.y), Vector2.right * rayUpLength, Color.red);
    }

    void PutinMario()
    {
        if (upRay.collider != null) 
        {
            if(gameObject.transform.localScale.y == 0.5)
            {
                
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y * 0.5f);
            }
            PutinDieCoroutine();
            //gameObject.SetActive(false);
            
        }
    }

    void EnemyRaycastMovement()
    {
        if (rightRay.collider == null) direction = -1;
        if (leftRay.collider == null) direction = 1;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            NewPlayer.Instance.health -= 20;
            NewPlayer.Instance.UpdateUI();
        }
    }
    IEnumerator PutinDieCoroutine()
    {
        

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        
    }


}
