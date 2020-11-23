using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthCount : MonoBehaviour
{
    public static int health = 100;
    public Text healthText;
    private int hpAdd = 0;
    public static bool bonus = false;
    public AudioSource dePower;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health.ToString();
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
            Invoke("SetBonusBack", 15);
        }

        if (col.gameObject.CompareTag("Candy"))
        {
            if (!bonus)
            {
                hpAdd = -10;
                health = health + hpAdd;
                healthText.text = "Health: " + health.ToString();
                if (health <= 0)
                {
                    EndGame();
                }
            } 
        }

        if (col.gameObject.CompareTag("Enemy"))
        {   
            if (!bonus)
            {
                hpAdd = -5;
                health = health + hpAdd;
                if (health < 0) health = 0;
                healthText.text = "Health: " + health.ToString();
                if (health <= 0)
                {
                    EndGame();
                }
            }
        }
    }

    public int GetHealthValue()
    {
        return health;
    }

    void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }

    private void SetBonusBack()
    {
        bonus = false;
        dePower.Play();
    }
}
