using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Obtener la entrada del teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        // Mover al jugador en la dirección calculada
        transform.Translate(direction * speed * Time.deltaTime);
    }
}

