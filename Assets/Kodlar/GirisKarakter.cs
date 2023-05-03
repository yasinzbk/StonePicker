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

    public Vector3 fareKonumu { get; private set; }

    public Weapon silah;

    public Camera mainCamera;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
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
            Vector3 mouse = Mouse.current.position.ReadValue();
            mouse.z = 10f;
            fareKonumu = mainCamera.ScreenToWorldPoint(mouse);
            Debug.Log("fareKonumu: " + fareKonumu);
        }
        else if (context.canceled)
        {
            saldiri = false;
        }
    }

    public void SaldiriGirisiniKullan() => saldiri = false;

    private void OnEnable()
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
