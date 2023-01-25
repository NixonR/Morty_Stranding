using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteWallScript : MonoBehaviour
{
    //=================================================================================================================================================================

    [SerializeField] NewPlayer newPlayer;
    [SerializeField] Collectable collectable;
    public Sprite basicSprite;

    //=================================================================================================================================================================
    // Start is called before the first frame update
    void Start()
    {
        basicSprite = newPlayer.inventoryItemImage.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D colPlayer)
    {
        if (colPlayer.gameObject.name == "Player" && newPlayer.KeyType == "Key2")
        {
            newPlayer.inventoryItemImage.sprite = basicSprite;
            newPlayer.inventory.Remove("Key2");
            newPlayer.KeyType = "basic";
            gameObject.SetActive(false);
        }
        
    }

    
    //=================================================================================================================================================================
}
