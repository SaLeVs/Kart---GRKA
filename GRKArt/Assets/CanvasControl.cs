using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    
    public Image[] bullets;
    public Image[] bullets2;

     private void Awake()
     {
         PowerBox powerBox = GetComponent<PowerBox>();   
     }


     private void Update()
     {
        if (PowerBox.readyToFire == false)
        {
            bullets[0].enabled = false;
            bullets[1].enabled = false;
            bullets[2].enabled = false;
            bullets[3].enabled = false;
        }

        if (PowerBox.readyToFire2 == false)
        {
            bullets2[0].enabled = false;
            bullets2[1].enabled = false;
            bullets2[2].enabled = false;
            bullets2[3].enabled = false;
        }



        if (PowerBox.currentBullet == 0 && PowerBox.readyToFire == true)
         {
             bullets[0].enabled = true;
             bullets[1].enabled = false;
             bullets[2].enabled = false;
             bullets[3].enabled = false;
         }
         else if (PowerBox.currentBullet == 1 && PowerBox.readyToFire == true)
         {
             bullets[0].enabled = false;
             bullets[1].enabled = true;
             bullets[2].enabled = false;
             bullets[3].enabled = false;
         }
         else if(PowerBox.currentBullet == 2 && PowerBox.readyToFire == true)
         {
             bullets[0].enabled = false;
             bullets2[1].enabled = false;
             bullets[2].enabled = true;
             bullets2[3].enabled = false;
         }
         else if(PowerBox.currentBullet == 3 && PowerBox.readyToFire == true)
         {
             bullets[0].enabled = false;
             bullets[1].enabled = false;
             bullets[2].enabled = false;
             bullets[3].enabled = true;
         }
       if (PowerBox.currentBullet2 == 0 && PowerBox.readyToFire2 == true)
         {
             bullets2[0].enabled = true;
             bullets2[1].enabled = false;
             bullets2[2].enabled = false;
             bullets2[3].enabled = false;
         }

         else if(PowerBox.currentBullet2 == 1 && PowerBox.readyToFire2 == true)
         {
             bullets2[0].enabled = false;
             bullets2[1].enabled = true;
             bullets2[2].enabled = false;
             bullets2[3].enabled = false;
         }

         else if(PowerBox.currentBullet2 == 2 && PowerBox.readyToFire2 == true)
         {
             bullets2[0].enabled = false;
             bullets2[1].enabled = false;
             bullets2[2].enabled = true;
             bullets2[3].enabled = false;
         }
         else if(PowerBox.currentBullet2 == 3 && PowerBox.readyToFire2 == true)
         {
             bullets2[0].enabled = false;
             bullets2[1].enabled = false;
             bullets2[2].enabled = false;
             bullets2[3].enabled = true;
         } 
     } 
}
