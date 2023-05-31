using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioEscena : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
       {
        //Cambio de escena
        SceneManager.LoadScene("Meta");
       } 
    }
}
