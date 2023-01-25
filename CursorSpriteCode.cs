using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSpriteCode : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite cross1;
    [SerializeField] Sprite cross2;
    [SerializeField] Weapon wp;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Cursor.visible = false;
        

    }

    private void Update()
    {
        if (wp.gunOpenCheck == true)
        {
            spriteRenderer.sprite = cross2;
        }

        if(wp.gunOpenCheck == false)
        {
            spriteRenderer.sprite = cross1;
        }
    }


    // Update is called once per frame
    private void FixedUpdate()
    {

        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;
    }
    
}
