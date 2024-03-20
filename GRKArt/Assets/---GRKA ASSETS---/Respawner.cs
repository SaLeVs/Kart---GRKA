using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Respawner : MonoBehaviour
{
    public GameObject[] carList;
    public Transform[] spawnPoints;
    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        GameObject carSelected;

        if(KartSelector.currentCar == null)
        {
            carSelected = carList[0];
        }
        else
        {
            carSelected = KartSelector.currentCar;
        }
        
        GameObject car = Instantiate(carSelected, spawnPoints[0].position, spawnPoints[0].rotation);
        virtualCamera.Follow = car.transform;
        virtualCamera.LookAt = car.transform;
    }
}
