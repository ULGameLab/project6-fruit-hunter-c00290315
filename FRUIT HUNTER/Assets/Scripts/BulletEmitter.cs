using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BulletEmitter : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletForce = 100.0f;
    public float destroyTime = 3.0f;
    AudioSource shootAudio;

    // Start is called before the first frame update
    void Start()
    {
        shootAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentBullet = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
            currentBullet.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce);
            shootAudio.Play();
            Destroy(currentBullet, destroyTime);
        }
    }
}
