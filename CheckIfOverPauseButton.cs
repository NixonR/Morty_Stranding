using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CheckIfOverPauseButton : MonoBehaviour

     , IPointerEnterHandler
     , IPointerExitHandler
{



    [SerializeField] GameObject assignedTextObj;
    [SerializeField] GameObject basicTextObj;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }




    public void OnPointerEnter(PointerEventData eventData)
    {

        assignedTextObj.SetActive(true);
        basicTextObj.SetActive(false);
        Debug.Log("returnbuttonON");

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        assignedTextObj.SetActive(false);
        basicTextObj.SetActive(true);
        Debug.Log("returnbuttonOFFFFFFF");

    }
}
