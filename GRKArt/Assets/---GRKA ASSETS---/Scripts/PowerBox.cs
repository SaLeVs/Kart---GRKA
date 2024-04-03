using Google.Protobuf.WellKnownTypes;
using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    public Transform[] bulletSpawns;
    public Transform[] pecas;

    static public int currentBullet = 0;
    static public int currentBullet2 = 0;
    static public bool readyToFire = false;
    static public bool readyToFire2 = false;
    public string fireButtonName = "Fire1";
    public string fireButtonName2 = "Fire2";
    private float pwpLife = 4f;
    public ArcadeKart scriptCarro;
    public Feno fenoScript;

    private bool isOleoActive = false;
    private bool isDinamiteActive = false;
    private bool isFenoActive = false;
    private bool isBallActive = false;
    private float rotationSpeed = 720f;
    private bool isRotating = false;
    public float launchVelocity = 10f;

    public static int qualBala;
    public static int qualBala2;

    private CanvasControl canvasControl;
    
   
    void Start()
    {
        fenoScript = GetComponent<Feno>();
        scriptCarro = GetComponent<ArcadeKart>();
        KeyboardInput input = GetComponent<KeyboardInput>();
        
        fireButtonName = input.FireButtonName;
        
        readyToFire = false;

        canvasControl = FindObjectOfType<CanvasControl>();
    }

    private void OnTriggerEnter(Collider other)
    {


        /* if(other.tag == "Player")
        {
            Debug.Log("Funcionou");
            if (other.CompareTag("Item"))
            {
                RandomizeBullet();
                Destroy(other.gameObject);
            }
        }
        if (other.tag == "Player")
        {
            Debug.Log("Funcionou");
            if (other.CompareTag("Item"))
            {
                RandomizeBullet2();
                Destroy(other.gameObject);
            }
        } */
        if (other.CompareTag("Item"))
        {
            // Verifica se o script está anexado ao objeto com a tag "Player"
            if (gameObject.CompareTag("Player"))
            {
                Debug.Log("Player 1 colidiu com o item.");
                RandomizeBullet();
            }
            // Verifica se o script está anexado ao objeto com a tag "Player2"
            else if (gameObject.CompareTag("Player2"))
            {
                Debug.Log("Player 2 colidiu com o item.");
                RandomizeBullet2();
            }

            // Destruir o objeto "Item"
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

        if (other.CompareTag("Ball"))
        {
            if (!isBallActive)
            {
                pwpBall();
                RodaCarro();
                isBallActive = true;
                Invoke("ResetPwP", 3f);
                Destroy(other.gameObject, 3f);
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

    public void RandomizeBullet2()
    {
        
        currentBullet2 = Random.Range(0, bulletPrefabs.Length);
        readyToFire2 = true;
    }

    public void pwpOleo()
    {
        scriptCarro.baseStats.TopSpeed = 7f;

    }

    public void pwpDinamite()
    {
        scriptCarro.baseStats.TopSpeed = 1f;

    }

    public void pwpBall()
    {
        scriptCarro.baseStats.TopSpeed = 0f;
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

        while (elapsedTime < 5f)
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
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[0].position, bulletSpawns[0].rotation);
                    
                }
                else if (currentBullet == 1 && bulletPrefabs.Length > 1)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[2].position, bulletSpawns[2].rotation);
                    
                }
                else if (currentBullet == 2 && bulletPrefabs.Length > 2)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[3].position, bulletSpawns[3].rotation);
                }
                else if (currentBullet == 3 && bulletPrefabs.Length > 3)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[1].position, bulletSpawns[1].rotation);
                }

                readyToFire = false;
            }
        }

        if (readyToFire2)
        {
            if (Input.GetButtonDown(fireButtonName))
            {
                GameObject bullet2;

                if (currentBullet2 == 0 && bulletPrefabs.Length > 0)
                {
                    bullet2 = Instantiate(bulletPrefabs[currentBullet2], bulletSpawns[0].position, bulletSpawns[0].rotation);

                }
                else if (currentBullet2 == 1 && bulletPrefabs.Length > 1)
                {
                    bullet2 = Instantiate(bulletPrefabs[currentBullet2], bulletSpawns[2].position, bulletSpawns[2].rotation);

                }
                else if (currentBullet2 == 2 && bulletPrefabs.Length > 2)
                {
                    bullet2 = Instantiate(bulletPrefabs[currentBullet2], bulletSpawns[3].position, bulletSpawns[3].rotation);
                }
                else if (currentBullet2 == 3 && bulletPrefabs.Length > 3)
                {
                    bullet2 = Instantiate(bulletPrefabs[currentBullet2], bulletSpawns[1].position, bulletSpawns[1].rotation);
                }

                readyToFire2 = false;
            }
        }

    }

}
