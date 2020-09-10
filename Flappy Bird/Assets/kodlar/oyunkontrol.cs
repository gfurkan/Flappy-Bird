using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunkontrol : MonoBehaviour
{
    public GameObject gokyuzuBir;
    public GameObject gokyuzuIki;
    public GameObject engel;
    public int kacAdetEngel = 5;
    GameObject[] engeller;

    Rigidbody2D fizikBir;
    Rigidbody2D fizikIki;

    float degisimZamani = 0;
    float uzunluk = 0;
    public float arkaPlanHiz = -2.5f;
    int sayac = 0;

    void Start()
    {
        fizikBir = gokyuzuBir.GetComponent<Rigidbody2D>();
        fizikIki = gokyuzuIki.GetComponent<Rigidbody2D>();
        uzunluk = gokyuzuBir.GetComponent<BoxCollider2D>().size.x;
        engeller = new GameObject[kacAdetEngel];

        fizikBir.velocity = new Vector2(arkaPlanHiz, 0);
        fizikIki.velocity = new Vector2(arkaPlanHiz, 0);

        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-20, -20), Quaternion.identity);
            Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(arkaPlanHiz, 0);
        }

    }

    void Update()
    {
        if (gokyuzuBir.transform.position.x <= -uzunluk)
        {
            gokyuzuBir.transform.position += new Vector3(uzunluk * 2, 0);
        }
        if (gokyuzuIki.transform.position.x <= -uzunluk)
        {
            gokyuzuIki.transform.position += new Vector3(uzunluk * 2, 0);
        }
        //---------------------------------
        degisimZamani += Time.deltaTime;
        if (degisimZamani > 1f)
        {
            degisimZamani = 0;
            float eksenY = Random.Range(-0.7f, 1.3f);
            engeller[sayac].transform.position = new Vector3(10f, eksenY);
            sayac++;
            if (sayac >= engeller.Length)
            {
                sayac = 0;
            }
        }
    }
    public void OyunBitti()
    {
        for(int i=0;i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizikBir.velocity = Vector2.zero;
            fizikIki.velocity = Vector2.zero;
        }
        Destroy(this);
    }
}
