using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllsCheatSheet : MonoBehaviour
{
    [SerializeField] GameObject cheatsheetPanel;
    [SerializeField] GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F1) && !pausePanel.activeInHierarchy == true)
        {
            cheatsheetPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyUp(KeyCode.F1) && !pausePanel.activeInHierarchy == true)
        {
            cheatsheetPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
