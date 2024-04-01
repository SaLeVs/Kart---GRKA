using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using KartGame.KartSystems;

public class Respawner : MonoBehaviour
{
    public GameObject[] carList;
    public Transform[] spawnPoints;
    public CinemachineVirtualCamera[] virtualCameras;

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
        GameObject car2 = Instantiate(carSelected, spawnPoints[1].position, spawnPoints[1].rotation);
        car.tag = "Player";
        car2.tag = "Player2";
        virtualCameras[0].Follow = car.transform;
        virtualCameras[0].LookAt = car.transform;
        

        virtualCameras[1].Follow = car2.transform;
        virtualCameras[1].LookAt = car2.transform;
        

        KeyboardInput input = car.GetComponent<KeyboardInput>();
        KeyboardInput input2 = car2.GetComponent<KeyboardInput>();

        input.TurnInputName = "Horizontal";
        input.AccelerateButtonName = "Accelerate";
        input.BrakeButtonName = "Brake";
        input.FireButtonName = "Fire1";

        input2.TurnInputName = "HorizontalP2";
        input2.AccelerateButtonName = "AccelerateP2";
        input2.BrakeButtonName = "BrakeP2";
        input.FireButtonName = "Fire1P2";

    }
}
