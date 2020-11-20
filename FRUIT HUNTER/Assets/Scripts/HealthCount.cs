using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCount : MonoBehaviour
{
    private int health = 100;
    public Text healthText;
    private int hpAdd = 0;
    public bool bonus = false;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Apple"))
        {
            hpAdd = 5;
            health = health + hpAdd;
            healthText.text = "Health: " + health.ToString();
        }

        if (col.gameObject.CompareTag("Banana"))
        {
            hpAdd = 10;
            health = health + hpAdd;
            healthText.text = "Health: " + health.ToString();
        }

        if (col.gameObject.CompareTag("Orange"))
        {
            hpAdd = 20;
            health = health + hpAdd;
            healthText.text = "Health: " + health.ToString();
            bonus = true; // figure out how to make this only be on for 30s
        }

        if (col.gameObject.CompareTag("Candy"))
        {
            if (!bonus)
            {
                hpAdd = -10;
                health = health + hpAdd;
                healthText.text = "Health: " + health.ToString();
            } 
        }
    }
}
