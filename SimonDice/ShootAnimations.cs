using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script lo tienen los cuadrados (C_Azul/C_Amarillo/C_Rojo/C_Verde) de la escena SimonDice. 
/// </summary>
public class ShootAnimations : MonoBehaviour
{
    /// <summary>
    /// Activa la animación al click
    /// </summary>
    private void OnMouseDown()
    {
        gameObject.GetComponent<Animator>().SetBool("go", true);

    }

    /// <summary>
    /// Finaliza la animación en la misma
    /// </summary>
    public void End()
    {
        gameObject.GetComponent<Animator>().SetBool("go", false);
    }
}
