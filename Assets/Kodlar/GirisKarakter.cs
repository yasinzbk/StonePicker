using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GirisKarakter : MonoBehaviour
{
    public Vector2 hareketGirisi { get; private set; }

    public int girisX { get; private set; }

    public int girisY { get; private set; }


    //Gecici

    public bool saldiri { get; private set; }
    public float fareTekerlegi { get; private set; }

    public Vector2 fareKonumu { get; private set; }

    public Weapon silah;

    public Camera mainCamera;


    public SesYoneticisi sesYonetim;
    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (hareketGirisi == Vector2.zero)
        {
            sesYonetim.Oynat("yurume");
            //sesYonetim.Durdur("yurume");

        }

    }

    public void HareketGirisi(InputAction.CallbackContext context)
    {
        hareketGirisi = context.ReadValue<Vector2>();

        girisX = Mathf.RoundToInt(hareketGirisi.x);

        girisY = Mathf.RoundToInt(hareketGirisi.y);


    }

    public void Saldir(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            saldiri = true;
            FareKonumunuVer();

        }
        else if (context.canceled)
        {
            saldiri = false;
        }
    }

    public void SaldiriGirisiniKullan() => saldiri = false;



    public void FareTekerlegi(InputAction.CallbackContext context)  // fare tekerlegi degeri
    {
        fareTekerlegi = context.ReadValue<float>(); // her harekette 120 ya da -120 degerini donduruyor
    }


    public void FareKonumunuVer()
    {
        Vector3 mouse = Mouse.current.position.ReadValue();  // burda sadce mouse ile tiklandiginda mousun konumunu alýyor
        mouse.z = 10f;
        //mouse.z= -Camera.main.transform.position.z;
        fareKonumu= mainCamera.ScreenToWorldPoint(mouse);
    }


    private void OnEnable()  // fare icin gerekli
    {
        // Mouse girdisi etkinleþtirilir
        InputSystem.EnableDevice(Mouse.current);
    }

    private void OnDisable()
    {
        // Mouse girdisi devre dýþý býrakýlýr
        InputSystem.DisableDevice(Mouse.current);
    }
}
