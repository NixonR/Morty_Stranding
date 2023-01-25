using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTransparentScript : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    float m_Red, m_Blue, m_Green;




    [SerializeField] Transform playerObj;
    // Start is called before the first frame update
    public Color color = Color.white;
        SpriteRenderer spr;

    public float yDis;

    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        
    }

    
    private void Update()
    {
        /*Debug.Log(Mathf.Abs(playerObj.position.y - transform.position.y));

        if(Mathf.Abs(playerObj.position.x - transform.position.x) <= 3f && Mathf.Abs(playerObj.position.y - transform.position.y) >= yDis)
        {
            m_SpriteRenderer.color = new Color(255f, 255f, 255f, 0.55f);
        }
        else
        {
            m_SpriteRenderer.color = new Color(255f, 255f, 255f, 255f);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            m_SpriteRenderer.color = new Color(255f, 255f, 255f, 0.55f);
        }
        else
            m_SpriteRenderer.color = new Color(255f, 255f, 255f, 255f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            m_SpriteRenderer.color = new Color(255f, 255f, 255f, 255f);
        }
    }

}
