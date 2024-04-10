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
    public ArcadeEngineAudio arcadeEngineAudio;
    public float disableTime = 3f;

    public ParticleSystem bomba;

    void Start()
    {
        GameObject parentObject = GameObject.Find("ArcadeEngineAudio");

        if (parentObject != null)
        {
            arcadeEngineAudio = parentObject.GetComponentInChildren<ArcadeEngineAudio>();
        }
        else
        {
            Debug.LogError("Não foi possível encontrar o objeto pai com o nome especificado.");
        }

        fenoScript = GetComponent<Feno>();
        scriptCarro = GetComponent<ArcadeKart>();
        KeyboardInput input = GetComponent<KeyboardInput>();
        
        fireButtonName = input.FireButtonName;
        
        readyToFire = false;

        canvasControl = FindObjectOfType<CanvasControl>();
        vai();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Item"))
        {
            if (gameObject.CompareTag("Player"))
            {
                
                RandomizeBullet();
            }
            else if (gameObject.CompareTag("Player2"))
            {
                
                RandomizeBullet2();
            }

            StartCoroutine(DisableObject(other.gameObject));
        }

        if (other.CompareTag("Óleo"))
        {
            if (!isOleoActive)
            {
                arcadeEngineAudio.PlayAudio(arcadeEngineAudio.Oleo);
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
                bomba.Play();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("obs"))
        {
            obstacle();
            Invoke("ResetPwP", 3f);
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

    public void obstacle()
    {
        scriptCarro.baseStats.TopSpeed = 5f;
    }

    public void vai()
    {
        scriptCarro.baseStats.TopSpeed = -1f;
        Invoke("Resetstart", 3f);
    }

    public void Resetstart()
    {
        scriptCarro.baseStats.TopSpeed = 15f;

    }
    private void ResetPwP()
    {
        scriptCarro.baseStats.TopSpeed = 15f;
        isOleoActive = false;
        isDinamiteActive = false;
        isBallActive = false;
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

    IEnumerator DisableObject(GameObject objToDisable)
    {
        objToDisable.SetActive(false);
        yield return new WaitForSeconds(disableTime);
        objToDisable.SetActive(true);
    }

    void Update()
    {

        if (readyToFire)
        {
            if (readyToFire && gameObject.CompareTag("Player") && Input.GetButtonDown(fireButtonName))
            {
                GameObject bullet;

                if (currentBullet == 0 && bulletPrefabs.Length > 0)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[0].position, bulletSpawns[0].rotation);
                    
                        arcadeEngineAudio.PlayAudio(arcadeEngineAudio.LaunchCanon);
                    
                    
                }
                else if (currentBullet == 1 && bulletPrefabs.Length > 1)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[2].position, bulletSpawns[2].rotation);
                    
                        arcadeEngineAudio.PlayAudio(arcadeEngineAudio.LaunchDinamite);
                    
                }
                else if (currentBullet == 2 && bulletPrefabs.Length > 2)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[3].position, bulletSpawns[3].rotation);
                    
                        
                    arcadeEngineAudio.PlayAudio(arcadeEngineAudio.LaunchFeno);

                }
                else if (currentBullet == 3 && bulletPrefabs.Length > 3)
                {
                    bullet = Instantiate(bulletPrefabs[currentBullet], bulletSpawns[1].position, bulletSpawns[1].rotation);
                    arcadeEngineAudio.PlayAudio(arcadeEngineAudio.LaunchOleo);


                }

                readyToFire = false;
            }
        }

        if (readyToFire2)
        {
            if (readyToFire2 && gameObject.CompareTag("Player2") && Input.GetButtonDown(fireButtonName))
            {
                GameObject bullet2;

                if (currentBullet2 == 0 && bulletPrefabs.Length > 0)
                {
                    bullet2 = Instantiate(bulletPrefabs[currentBullet2], bulletSpawns[0].position, bulletSpawns[0].rotation);
                    
                        arcadeEngineAudio.PlayAudio(arcadeEngineAudio.LaunchCanon);
                    

                }
                else if (currentBullet2 == 1 && bulletPrefabs.Length > 1)
                {
                    bullet2 = Instantiate(bulletPrefabs[currentBullet2], bulletSpawns[2].position, bulletSpawns[2].rotation);
                    
                    arcadeEngineAudio.PlayAudio(arcadeEngineAudio.LaunchDinamite);
                    
                }
                else if (currentBullet2 == 2 && bulletPrefabs.Length > 2)
                {
                    bullet2 = Instantiate(bulletPrefabs[currentBullet2], bulletSpawns[3].position, bulletSpawns[3].rotation);

                    arcadeEngineAudio.PlayAudio(arcadeEngineAudio.LaunchFeno);

                }
                else if (currentBullet2 == 3 && bulletPrefabs.Length > 3)
                {
                    bullet2 = Instantiate(bulletPrefabs[currentBullet2], bulletSpawns[1].position, bulletSpawns[1].rotation);

                    arcadeEngineAudio.PlayAudio(arcadeEngineAudio.LaunchOleo);


                }

                readyToFire2 = false;
            }
        }

    }

}
