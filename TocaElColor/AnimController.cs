using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script lo tiene el objeto controlles en la escena TocaElColor
/// </summary>
public class AnimController : MonoBehaviour
{
    /// <summary>
    /// Array de componentes Animator.
    /// </summary>
    [SerializeField]
    private Animator[] anim_arr;

    /// <summary>
    /// Va activando las animaciones del array
    /// </summary>
    private void Update()
    { 
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < anim_arr.Length; ++i)
                anim_arr[i].SetBool("go", true);

        }
        
    }
 
    
}
