using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MortyBreathing : MonoBehaviour
{

    public float breathLimit = 100f;
    public float breathTaking = 5f;
    public float breathRecovery = 5f;
    public bool mortyHoldBreath = false;
    [SerializeField] GameObject mouthClosed;
    [SerializeField] GameObject breathBar;
    float barLenght;
    Vector3 scaleChange;
    float breathBarUnit;
    [SerializeField] SpriteRenderer breathBarSprite;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //breathBarUnit = breathBar.transform.localScale.x / breathLimit;
        //barLenght = breathLimit * breathBarUnit;
        //scaleChange = new Vector3(barLenght, 0.6f, 0.5f);
        breathBar.transform.localScale = new Vector3(breathLimit * 0.005f, 0.6f, 0.5f);
        ShowBBar();
        if (Input.GetKey(KeyCode.C))
        {
            breathLimit -= breathTaking * Time.deltaTime;
            mortyHoldBreath = true;
            mouthClosed.SetActive(true);
            //breathBar.SetActive(true);
        }
        else
        {
            breathLimit += breathRecovery * Time.deltaTime;
            mortyHoldBreath = false;
            mouthClosed.SetActive(false);
            //breathBar.SetActive(false);
        }
        if(breathLimit > 100f)
        {
            breathLimit = 100f;
        }
        if(breathLimit <= 0f)
        {
            breathLimit = 0f;
            mortyHoldBreath = false;
            mouthClosed.SetActive(false);
        }
        breathLimit = breathLimit;
        if (breathLimit < 20f)
        {
            breathBarSprite.color = new Color(191, 0f, 0f, 1f); 
            //Debug.Log("RED");
        }
        else
        {
            //Debug.Log("yellow");
            breathBarSprite.color = new Color(255f, 19f, 0f, 1f);

        }

    }

    async void ShowBBar()
    {
        if (Input.GetKey(KeyCode.C))
        {
            
            breathBar.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.C))
        {
            await Task.Delay(2000);
            breathBar.SetActive(false);
        }
    }
}
