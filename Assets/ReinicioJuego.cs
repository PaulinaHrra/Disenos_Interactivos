using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReinicioJuego : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a reiniciar

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión ocurrió con el personaje o el obstáculo
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstaculo"))
        {
            // Reiniciar el juego
            SceneManager.LoadScene(nombreEscena);
        }
    }
}

