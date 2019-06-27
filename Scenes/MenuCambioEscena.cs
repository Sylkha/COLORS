using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Este script lo tiene la Main Camera de la escena Menu.
/// </summary>
public class MenuCambioEscena : MonoBehaviour
{
    /// <summary>
    /// Esta función es llamada al final de la animación (CameraTransition) que tiene la MainCamera de la escena Menu.
    /// </summary>
    public void CambioEscena()
    {
        SceneManager.LoadScene(2);
    }
}
