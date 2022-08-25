using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour  
{
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman, can, durum;
    private Rigidbody rg;
    public float Hiz=1.5f;
    float zamanSayaci = 30;
    int canSayaci = 3;
    bool oyunDevam = true;
    bool bölümTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !bölümTamam)
        {
            zamanSayaci -= Time.deltaTime; //zamansayaci = zamansayaci-time.deltatime
            zaman.text = (int)zamanSayaci + "";

        }
        else if (!bölümTamam)
        {
            durum.text = "Bölüm Tamamlanamadı";
            btn.gameObject.SetActive(true);
        }
            if (zamanSayaci < 0)
                oyunDevam = false;
        
    }
    void FixedUpdate() //Bunlar w,a,s,d tuşlarımızı kontrol edecek
    {
        if (oyunDevam && !bölümTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rg.AddForce(kuvvet * Hiz);
        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }
    void OnCollisionEnter(Collision cls)
    {
        string objIsmi = cls.gameObject.name;
        if(objIsmi.Equals("Bitis"))
        {
            //print("Bölüm Tamamlandı");
            bölümTamam = true;
            durum.text = "Bölüm tamamlandı.Tebrikler!";
            btn.gameObject.SetActive(true);
        }
        else if(!objIsmi.Equals("ZEMIN"))
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci == 0)
                oyunDevam = false;
        }
    }
    
        
}
