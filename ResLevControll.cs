using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class ResLevControll : MonoBehaviour
{
    [SerializeField] GameObject youDiePanel;
    ResLev resMorty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(resMorty);
    }


    public void RestartLevelIfDie()
    {
        if (resMorty.truePanel == true)
        {
            youDiePanel.SetActive(true);
            resMorty.truePanel = false;
        
        
        }

    }
}
