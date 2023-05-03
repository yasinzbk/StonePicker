using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alet : MonoBehaviour
{
    private void Update()  // kilic gibi silahlarin saldircagimiz alani gostermesi icin hareketi  // tam da olmadi karakter dondugunde alet de donmeli
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction the object should look at
        Vector3 lookDirection = mousePosition - transform.position;
        lookDirection.z = 0f;

        // Rotate the object towards the mouse position
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
