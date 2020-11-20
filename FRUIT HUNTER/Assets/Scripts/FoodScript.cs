using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class FoodScript : MonoBehaviour
{
    AudioSource pickUp;

    // Start is called before the first frame update
    void Start()
    {
        pickUp = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 1.0f, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer c in allRenderers) c.enabled = false;
            Collider[] allColliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allColliders) c.enabled = false;
           StartCoroutine(PlayAndDestroy(pickUp.clip.length));
        }
    }

    private IEnumerator PlayAndDestroy(float waitTime)
    {
        pickUp.Play();
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
