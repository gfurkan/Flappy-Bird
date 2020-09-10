using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anamenu : MonoBehaviour
{

    void Start()
    {
       
    }

    void Update()
    {
        
    }
   public void OyunaGir()
    {
        SceneManager.LoadScene("level");
    }
   public void OyundanCik()
    {
        Application.Quit();
    }
}
