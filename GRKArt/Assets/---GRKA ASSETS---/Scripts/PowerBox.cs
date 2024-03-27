using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    public Transform[] bulletSpawns;
    public int currentBullet = 0;
    public bool readyToFire = true;

    public string fireButtonName = "Fire1";

    void Start()
    {
        KeyboardInput input = GetComponent<KeyboardInput>();
        fireButtonName = input.FireButtonName;
    }

    void Update()
    {
        if (readyToFire)
        {
            Fire(); 
        }
        
    }

    void Fire()
    {
        if (Input.GetButtonDown(fireButtonName))
        {
            GameObject bullet = Instantiate(bulletPrefabs[currentBullet],
                bulletSpawns[0].position, bulletSpawns[0].rotation);
        }
    }

    public void RandomizeBullet()
    {
        currentBullet = Random.Range(0, bulletPrefabs.Length);
        readyToFire = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            RandomizeBullet();
            // colocar o barulho de randomizar aqui
        }
    }
}
