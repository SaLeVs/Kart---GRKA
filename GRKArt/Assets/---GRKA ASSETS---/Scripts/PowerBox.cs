using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    public Transform[] bulletSpawns;
    public int currentBullet = 0;
    public bool readyToFire = false;

    public string fireButtonName = "Fire1";

    void Start()
    {
        KeyboardInput input = GetComponent<KeyboardInput>();
        fireButtonName = input.FireButtonName;
        readyToFire = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            RandomizeBullet();
            Destroy(other.gameObject);
        }
    }

    public void RandomizeBullet()
    {
        currentBullet = Random.Range(0, bulletPrefabs.Length);
        readyToFire = true;
    }



    void Update()
    {

        if (readyToFire)
        {
            if (Input.GetButtonDown(fireButtonName))
            {
                GameObject bullet;

                if (currentBullet == 0 && bulletPrefabs.Length > 0)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[0].position, bulletSpawns[0].rotation);
                }
                else if (currentBullet == 1 && bulletPrefabs.Length > 1)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[0].position, bulletSpawns[0].rotation);
                }
                else if (currentBullet == 2 && bulletPrefabs.Length > 2)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[1].position, bulletSpawns[1].rotation);
                }
                else if (currentBullet == 3 && bulletPrefabs.Length > 3)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[1].position, bulletSpawns[1].rotation);
                }

                readyToFire = false;
            }
        }

    }

}
