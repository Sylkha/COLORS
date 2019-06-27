using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Este script lo tiene el objeto C_Blanco de la escena Menu.
/// </summary>
public class ChangeScene : MonoBehaviour
{
    private AudioSource audioBueno;

    private void Start()
    {
        audioBueno = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        audioBueno.Play();
        Camera.main.GetComponent<Animator>().SetBool("zoomin", true);
        
    }

    
}
