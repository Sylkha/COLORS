using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creamos un delegado
/// </summary>
/// <param name="numeroUsuario"></param>
public delegate void DelegadoCuadradito(byte numeroUsuario);

public class CuadraditoSimon : MonoBehaviour
{
    /// <summary>
    /// Componente AudioSource
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// Elemento de la clase Delegado
    /// </summary>
    private DelegadoCuadradito delegadoCuadradito;

    /// <summary>
    /// Número asignado a cada cuadrado según el tag
    /// </summary>
    private byte numeroUsuario;

    /// <summary>
    /// Asignamos desde el principio el número correspondiente a cada cuadrado, según su tag
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (gameObject.tag == "Rojo")
        {
           numeroUsuario = 0;
        }
        else if (gameObject.tag == "Verde")
        {
            numeroUsuario = 1;
        }

        else if (gameObject.tag == "Amarillo")
        {
           numeroUsuario = 2;
        }

        else if (gameObject.tag == "Azul")
        {
            numeroUsuario = 3;
        }
    }

    /// <summary>
    /// Cuando se hace click, reproduce el sonido asociado al cuadrado clickado y hace su animación.
    /// Aquí le mandamos el numeroUsuario al delegado.
    /// </summary>
    private void OnMouseDown()
    {
        gameObject.GetComponent<AudioSource>().Play();
        GetComponent<Animator>().SetBool("go", true);
        //Comprobamos si tiene algún delegado. En caso de no tenerlo, se lo añadimos.
        if (delegadoCuadradito != null)
        {
            delegadoCuadradito(numeroUsuario);
        }
    }

    /// <summary>
    /// Función por la cual se va a suscribir 
    /// </summary>
    /// <param name="d"></param>
    public void SuscribirseADelegadoCuadradito(DelegadoCuadradito d)
    {
        delegadoCuadradito += d;
    }

    /// <summary>
    /// Función por la cual se va a desuscribir
    /// </summary>
    /// <param name="d"></param>
    public void DesuscribirseADelegadoCuadradito(DelegadoCuadradito d)
    {
        delegadoCuadradito -= d;       
    }


}
