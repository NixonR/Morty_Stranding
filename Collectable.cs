using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    //===========================================================================================================================================================================

    //this creates itemtype enum (dropdown)
    public enum ItemType { Coin, Health, Ammo, Toxic, Inventory} 

    //drawing enum in inspector
    public ItemType itemType;

    //reference to newPlayer script
    [SerializeField] MortyController mortyController;

    [SerializeField] public string inventoryStringName;
    [SerializeField] public Sprite inventorySprite;
    [SerializeField] WhiteWallScript wall;
    






    //========================================================================================================================================================================================================

    private void Awake()
    {
        
        
    }
    void Start()
    {
        mortyController = GameObject.Find("morty model 2").GetComponent<MortyController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //===========================================================================================================================================================================

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "morty model 2")
        {

            if (itemType == ItemType.Coin )
            {
                Debug.Log("IM A COIN");
                gameObject.SetActive(false);
            }
            else if (itemType == ItemType.Health)
            {
                
                gameObject.SetActive(false);
            }
            else if (itemType == ItemType.Ammo)
            {
                
                
            }
            else if (itemType == ItemType.Toxic)
            {
                
                gameObject.SetActive(false);
            }
           
           
           
            
 
        }

    }

    public void AddInventoryItem(string inventoryStringName, Sprite inventorySprite)
    {
        this.inventorySprite = inventorySprite;
        this.inventoryStringName = inventoryStringName;
       
        

       
        Debug.Log(inventoryStringName);
    }

    

    
    //===========================================================================================================================================================================
}
