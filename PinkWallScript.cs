using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkWallScript : MonoBehaviour
{

    [SerializeField] NewPlayer newPlayer;
    [SerializeField] Collectable collectable;
    public Sprite basicSprite;
    public KeyRetryScript keyRetry;
    [SerializeField] string requiredInventoryKey;


    // Start is called before the first frame update
    void Start()
    {
        basicSprite = newPlayer.inventoryItemImage.sprite;
        keyRetry = GameObject.Find("Player").GetComponent<KeyRetryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter2D(Collision2D colPlayer)
    {
        if (colPlayer.gameObject.name == "Player" &&  newPlayer.inventory.ContainsKey(requiredInventoryKey))
        {
            newPlayer.inventoryItemImage.sprite = basicSprite;
            newPlayer.inventory.Remove("Key2");
            newPlayer.KeyType = "basic";
            keyRetry.PinkWall1 = false;
            gameObject.SetActive(false);

        }
    }
}
