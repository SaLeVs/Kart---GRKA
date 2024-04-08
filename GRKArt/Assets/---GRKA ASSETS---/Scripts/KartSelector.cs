using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KartSelector : MonoBehaviour
{
     public GameObject[] carList;
     public int selectedCar = 0;
     public int selectedCar2= 0;
     public static GameObject currentCar;
     public static GameObject currentCar2;
     public GameObject carousel;
     public GameObject carousel2;
     public string sceneName;

     private bool escolheu = false;
     

    private void Start()
    {
        escolheu = false;
        
        carousel2.SetActive(false);
    }

    public void Update()
     {

        carousel.transform.position = Vector3.Lerp(carousel.transform.position, new Vector3 (selectedCar * -5, 0, 0), Time.deltaTime*1);
        carousel2.transform.position = Vector3.Lerp(carousel2.transform.position, new Vector3(selectedCar2 * -5, 0, 0), Time.deltaTime * 1);

        if (Input.GetKeyDown(KeyCode.RightArrow) && escolheu == false)
         {
             RightButton();
         }

         if (Input.GetKeyDown(KeyCode.LeftArrow) && escolheu == false)
         {
             LeftButton();
         }

        if (Input.GetKeyDown(KeyCode.RightArrow) && escolheu == true)
        {
            RightButton2();
           
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && escolheu == true)
        {
            LeftButton2();
        }
    }

     public void RightButton()
     {
        if(escolheu == false)
        {
            currentCar = carList[selectedCar];

            selectedCar++;


            if (selectedCar > carList.Length - 1)
            {
                selectedCar = 0;
            }
        }
        

    }

    public void RightButton2()
    {
        if (escolheu == true)
        {
            currentCar2 = carList[selectedCar2];

            selectedCar2++;

            if (selectedCar2 > carList.Length - 1)
            {
                selectedCar2 = 0;
            }
        }
    }


    public void LeftButton()
     {
        if (escolheu == false)
        {
            currentCar = carList[selectedCar];

            selectedCar--;



            if (selectedCar < 0)
            {
                selectedCar = carList.Length - 1;
            }
        }
     }
        public void LeftButton2()
    {
        if (escolheu == true)
        {
            currentCar2 = carList[selectedCar2];

            selectedCar2--;



            if (selectedCar2 < 0)
            {
                selectedCar2 = carList.Length - 1;
            }
        }
        
    }
    


public void SelectCar()
     {
         if (!escolheu)
         {
             
             currentCar = carList[selectedCar];
             escolheu = true;
             Debug.Log("Escolheu1");
             carousel.SetActive(false);
             carousel2.SetActive(true);
        }
         else
         {
             currentCar2 = carList[selectedCar2];
             Debug.Log("Escolheu2");
             SceneManager.LoadSceneAsync(sceneName);
         }

     } 
    

}
