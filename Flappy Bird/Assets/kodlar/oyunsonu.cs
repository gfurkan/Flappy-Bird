using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oyunsonu : MonoBehaviour
{
    public Text skortext;
    public Text enyuksekskortext;
    void Start()
    {
        int enYuksekPuan = PlayerPrefs.GetInt("enyuksekpuankayit");
        int puan=PlayerPrefs.GetInt("puankayit");

        enyuksekskortext.text = "EN YÜKSEK PUAN = " + enYuksekPuan;
        skortext.text = "PUAN = " + puan;
    }

    void Update()
    {
        
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("anamenu");
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("level");
    }
    public void OyundanCik()
    {
        Application.Quit();
    }
}
