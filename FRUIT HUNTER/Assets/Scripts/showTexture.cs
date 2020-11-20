using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showTexture : MonoBehaviour
{
    public Texture aTex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (!aTex)
        {
            Debug.Log("Error: Assign a Texture in the Inspector");
            return;
        }
        GUI.DrawTexture(new Rect(Screen.width - 130, 10, 120, 120), aTex, ScaleMode.ScaleToFit, true);
    }
}
