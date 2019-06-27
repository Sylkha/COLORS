using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script lo tiene cada cuadrado de la escena EncuentraElFallo.
/// </summary>
public class Square : MonoBehaviour
{
    /// <summary>
    /// Cogemos el componente AudioSource
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// Hacemos referencia a la clase SquaresController. Le pasamos un objeto que contenga ese script
    /// </summary>
    public SquaresController sq;

    private void Start()
    {
        audioSource = (AudioSource)GetComponent<AudioSource>();
    }

    /// <summary>
    /// Esta función es llamada si el ratón está sobre el GUI o el collider. 
    /// </summary>
    private void OnMouseDown()
    {       
        StartCoroutine(delay());
        sq.WhenClicking();        
    }

    /// <summary>
    /// Hace el sonido del cuadrado al ser pulsado y espera.
    /// </summary>
    /// <returns></returns>
    IEnumerator delay()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.2f);
    }
}
