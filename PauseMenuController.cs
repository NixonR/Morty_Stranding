using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuController : MonoBehaviour
{

    [SerializeField] GameObject pausePanel;
    




    void Update()
    {




        



        PauseGame();



    }
    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            
            Time.timeScale = 0f;
            Debug.Log("ON");
            Cursor.visible = true;
        }
    }

    public void ResumeGame()
    {

        Cursor.visible = false;
        pausePanel.SetActive(false);
        
        Time.timeScale = 1f;
        Debug.Log("OFF");

    }

    public void ReturnToMainMenu(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
