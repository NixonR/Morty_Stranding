using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    [SerializeField] private GameObject loaderScreenCanvas;
    //[SerializeField] private GameObject loaderScreenCanvas2;
    [SerializeField] private Image progressBar;
    [SerializeField] private Animator fadeAnim;
    [SerializeField] private GameObject turnOffGameObj;
    [SerializeField] private GameObject turnOffCanvas;

    [SerializeField] private GameObject turnOffStart;
    [SerializeField] private GameObject turnOffOptions;
    [SerializeField] private GameObject turnOffExit;


    private float target;

    private void Awake()
    {
        //loaderScreenCanvas2 = GameObject.FindGameObjectWithTag("Canvas2");


        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        turnOffGameObj = GameObject.FindGameObjectWithTag("MortyMainMenuTemplate");
        turnOffCanvas = GameObject.FindGameObjectWithTag("Canvas");
        turnOffStart = GameObject.FindGameObjectWithTag("Start");
        turnOffOptions = GameObject.FindGameObjectWithTag("Options");
        turnOffExit = GameObject.FindGameObjectWithTag("Exit");
        target = 0;
        progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        loaderScreenCanvas.SetActive(true);
        

        do
        {
            await Task.Delay(100);

            target = scene.progress;

        } while (scene.progress < 0.9f);
        await Task.Delay(4000);
        fadeAnim.SetTrigger("fade");
        turnOffGameObj.SetActive(false);
        turnOffCanvas.SetActive(false);
        turnOffStart.SetActive(false);
        turnOffOptions.SetActive(false);
        turnOffExit.SetActive(false);



        await Task.Delay(4000);
        Debug.Log("?adowanie");
        loaderScreenCanvas.SetActive(false);
        
        scene.allowSceneActivation = true;
    }

    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, 0.3f *Time.deltaTime);
    }

    // Start is called before the first frame update

}
