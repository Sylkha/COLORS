using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script lo tiene el objeto Simon_dice_movil en la escena TocaElColor
/// </summary>
public class Finish : MonoBehaviour
{
    /// <summary>
    /// Componente AudioSource
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// Referencia al objeto C_Blanco.
    /// </summary>
    [SerializeField]
    private GameObject gameo;

    private void Start()
    {
        audioSource = (AudioSource)GetComponent<AudioSource>();
    }

    public void Empieza()
    {
        print("gola");

        StartCoroutine(hola());
    }

    /// <summary>
    /// Tras haber tocado la pantalla, suena un sonido y se activa el objeto gameo (C_Blanco)
    /// </summary>
    /// <returns></returns>
    private IEnumerator hola()
    {
        yield return new WaitUntil(() => is_mouse_pressed());
        audioSource.Play();
        gameo.SetActive(true);

    }
    private bool is_mouse_pressed()
    {
        return Input.GetMouseButtonDown(0);
    }
}
