using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class karakterkontrol : MonoBehaviour
{
    AudioSource []sesler;
    public Sprite[] kusSprite;
    SpriteRenderer spriteRenderer;
    Rigidbody2D fizik;
    public Text puantext;
    public oyunkontrol oyunKontrol;
    
    bool oyunBitti = true;
    int puan = 0;
    bool ileriGeriKontrol = true;
    int kusSayac = 0;
    float kusKanatZaman = 0;
    int enYuksekPuan=0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<oyunkontrol>();
        sesler = GetComponents<AudioSource>();
        enYuksekPuan=PlayerPrefs.GetInt("enyuksekpuankayit");
    }


    void Update()
    {
        puantext.text = "Puan = " + puan;

        if (Input.GetMouseButtonDown(0) && oyunBitti)
        {
            sesler[0].Play();
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0, 250));

        }
        if (fizik.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 30);
        }
        else if (fizik.velocity.y < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -30);
        }

        Animasyon();
    }
    void Animasyon()
    {
        kusKanatZaman += Time.deltaTime;
        if (kusKanatZaman > 0.11f)
        {
            kusKanatZaman = 0;
            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = kusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == kusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }

            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = kusSprite[kusSayac];

                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKontrol = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
            if (col.gameObject.tag == "puan")
            {
                puan++;
            sesler[1].Play();

        }
            if (col.gameObject.tag == "engel")
            {
            sesler[2].Play();
            oyunBitti = false;
            oyunKontrol.OyunBitti();
            GetComponent<CircleCollider2D>().enabled = false;

            if(puan > enYuksekPuan)
            {
                enYuksekPuan = puan;
                PlayerPrefs.SetInt("enyuksekpuankayit", enYuksekPuan);
            }
            Invoke("OyunSonunaGit",2);
            }
        }  
    void OyunSonunaGit()
    {
        PlayerPrefs.SetInt("puankayit", puan);
        SceneManager.LoadScene("oyunson");
    }
}