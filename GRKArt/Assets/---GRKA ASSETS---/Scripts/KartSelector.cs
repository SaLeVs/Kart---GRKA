using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KartSelector : MonoBehaviour
{
    public GameObject[] carList;
    public int selectedCar = 0;
    public int selectedCar2= 0;
    public static GameObject currentCar;
    public static GameObject currentCar2;
    public GameObject carousel;
    public string sceneName;

    private bool escolheu = false;

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
        currentCar2 = carList[selectedCar2];
        selectedCar++;
        selectedCar2++;

        if (selectedCar > carList.Length - 1)
        {
            selectedCar = 0;
        }
        if (selectedCar2 > carList.Length - 1)
        {
            selectedCar2 = 0;
        }
    }

    public void LeftButton()
    {
        currentCar = carList[selectedCar];
        currentCar2 = carList[selectedCar2];
        selectedCar--;
        selectedCar2--;

        if (selectedCar < 0)
        {
            selectedCar = carList.Length - 1;
        }

        if (selectedCar2 < 0)
        {
            selectedCar2 = carList.Length - 1;
        }

    }

    
    public void SelectCar()
    {
        if (!escolheu)
        {
            currentCar = carList[selectedCar];
            escolheu = true;
            Debug.Log("Escolheu1");
        }
        else
        {
            currentCar2 = carList[selectedCar2];
            Debug.Log("Escolheu2");
            SceneManager.LoadSceneAsync(sceneName);
        }
         
    }

  
}
