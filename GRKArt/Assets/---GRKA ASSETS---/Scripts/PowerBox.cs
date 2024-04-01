using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    public Transform[] bulletSpawns;
    public Transform[] pecas;

    public int currentBullet = 0;
    public bool readyToFire = false;
    public string fireButtonName = "Fire1";
    private float pwpLife = 4f;
    public ArcadeKart scriptCarro;
    public Feno fenoScript;

    private bool isOleoActive = false;
    private bool isDinamiteActive = false;
    private bool isFenoActive = false;
    private float rotationSpeed = 720f;
    private bool isRotating = false;
    public float launchVelocity = 10f;



    void Start()
    {
        fenoScript = GetComponent<Feno>();
        scriptCarro = GetComponent<ArcadeKart>();
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

        if (other.CompareTag("Óleo"))
        {
            if (!isOleoActive)
            {
                pwpOleo();
                RodaCarro();
                isOleoActive = true;
                Invoke("ResetPwP", 6f);
                Destroy(other.gameObject, pwpLife);
            }
        }

        if (other.CompareTag("Dinamite"))
        {
            if (!isDinamiteActive)
            {
                pwpDinamite();
                isDinamiteActive = true;
                Invoke("ResetPwP", 4f);
                Destroy(other.gameObject, pwpLife);
            }
        }

        if (other.CompareTag("Feno"))
        {
            
        }

    }

    public void RandomizeBullet()
    {
        currentBullet = Random.Range(0, bulletPrefabs.Length);
        readyToFire = true;
    }


    public void pwpOleo()
    {
        scriptCarro.baseStats.TopSpeed = 7f;

    }

    public void pwpDinamite()
    {
        scriptCarro.baseStats.TopSpeed = 1f;

    }


    private void ResetPwP()
    {
        scriptCarro.baseStats.TopSpeed = 15f;
        isOleoActive = false;
        isDinamiteActive = false;
    }

    public void RodaCarro()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateCarParts());
        }
    }

    private IEnumerator RotateCarParts()
    {
        isRotating = true;

        float elapsedTime = 0f;

        while (elapsedTime < 7f)
        {
            foreach (Transform peca in pecas)
            {
                peca.Rotate(Vector3.down, rotationSpeed * Time.deltaTime); 
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isRotating = false;
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
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[3].position, bulletSpawns[3].rotation);
                    
                }
                else if (currentBullet == 1 && bulletPrefabs.Length > 1)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[3].position, bulletSpawns[3].rotation);
                    
                }
                else if (currentBullet == 2 && bulletPrefabs.Length > 2)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[3].position, bulletSpawns[3].rotation);
                }
                else if (currentBullet == 3 && bulletPrefabs.Length > 3)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[3].position, bulletSpawns[3].rotation);
                }

                readyToFire = false;
            }
        }

    }

}
