using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KartSelector : MonoBehaviour
{
    public GameObject[] carList;
    public int selectedCar = 0;
    public static GameObject currentCar;
    public GameObject carousel;
    public string sceneName;

    public GameObject[] confirmedCar;
    private int playerSEL;

    public void Update()
    {
        
        carousel.transform.position = Vector3.Lerp(carousel.transform.position, new Vector3 (selectedCar * -5, 0, 0), Time.deltaTime*1);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightButton();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftButton();
        }
    }

    public void RightButton()
    {
        currentCar = carList[selectedCar];
        selectedCar++;

        if (selectedCar > carList.Length - 1)
        {
            selectedCar = 0;
        }

    }

    public void LeftButton()
    {
        currentCar = carList[selectedCar];
        selectedCar--;

        if (selectedCar < 0)
        {
            selectedCar = carList.Length - 1;
        }
        
    }

    
    public void SelectCar()
    {
        
            currentCar = carList[selectedCar];
         SceneManager.LoadSceneAsync(sceneName);
    }

   public void SelectCar2()
    {
      currentCar = carList[selectedCar];
       SceneManager.LoadSceneAsync(sceneName);
   }
}
