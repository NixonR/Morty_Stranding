using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class ResLev : MonoBehaviour
{
    [SerializeField] Animator animDie;
    public bool truePanel = false;
    MortyController mc;





    void Update()
    {
        //Debug.Log(truePanel);
    }

    public async void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("MonsterMash") && !Input.GetButton("Ctr") == true)
        {
            truePanel = true;
            //animDie.SetBool("died", true);
            Time.timeScale = 0f;
            await Task.Delay(5000);

            SceneManager.LoadScene(1);
        }
        if (col.gameObject.CompareTag("MonsterMash") && Input.GetButton("Ctr") == true)
        {
            mc.mortyHealth -= 10f;
        }
    }


}
