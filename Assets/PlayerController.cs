using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



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

        // Calcular la posición objetivo
        Vector3 targetPosition = transform.position + direction * speed * Time.deltaTime;

        // Verificar si la posición objetivo está dentro de los límites
        if (IsPositionWithinBounds(targetPosition))
        {
            // Mover al jugador a la posición objetivo
            transform.position = targetPosition;
        }
        else
        {
            // Reiniciar el juego si el jugador toca un obstáculo o sale de los límites
            RestartGame();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Reiniciar el juego si el jugador colisiona con un obstáculo
            RestartGame();
        }
    }

    bool IsPositionWithinBounds(Vector3 position)
    {
        // Obtener los límites de la escena
        Bounds bounds = new Bounds(Vector3.zero, new Vector3(10f, 10f, 10f)); // Establece los límites como desees

        // Verificar si la posición está dentro de los límites
        if (bounds.Contains(position))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void RestartGame()
    {
        // Reiniciar el juego cargando la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



