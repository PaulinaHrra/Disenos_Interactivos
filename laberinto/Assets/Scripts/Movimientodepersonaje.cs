using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientodepersonaje : MonoBehaviour
{
    public float velocidad = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidad * Time.deltaTime;

        rb.MovePosition(rb.position + transform.TransformDirection(movimiento));
    }
}
