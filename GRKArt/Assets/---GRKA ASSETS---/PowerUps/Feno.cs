using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feno : MonoBehaviour
{
    public GameObject fenoEffectPrefab;
    public float duration = 5f;
    private bool isFenoActive = false;

    public void ActivateFenoEffect(Transform cameraTransform)
    {
        if (!isFenoActive)
        {
            isFenoActive = true;
            GameObject fenoEffect = Instantiate(fenoEffectPrefab, cameraTransform.position, Quaternion.identity);
            Debug.Log("Deu Certo");
            fenoEffect.transform.SetParent(cameraTransform);
            Destroy(fenoEffect, duration);
            Invoke("DeactivateFenoEffect", duration);
        }
    }

    void DeactivateFenoEffect()
    {
        isFenoActive = false;
    }
}
