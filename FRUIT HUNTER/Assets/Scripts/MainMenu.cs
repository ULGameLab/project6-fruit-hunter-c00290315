using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGameButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void FirstStartGameButton()
    {
        SceneManager.LoadScene("FirstPerson");
    }

    public void ThirdStartGameButton()
    {
        SceneManager.LoadScene("ThirdPerson");
    }

    public void RestartGameButton()
    {
        HealthCount.health = 100;
        HealthCount.bonus = false;
        SceneManager.LoadScene("StartScreen");
    }
}
