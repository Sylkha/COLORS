using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Este script lo contiene el texto Handicap en la escena Handicap.
/// </summary>
public class handicapGenerator : MonoBehaviour {
    /// <summary>
    /// Array que contiene las frases.
    /// </summary>
    [SerializeField]
    private static string[] handicap = { "¿Cuál es tu comida favorita?","¿Qué es lo que mas te gusta en el mundo?",
        "¿Quién te parece el más interesante de la mesa?", "¿Si pudieras ir a cualquier lugar del mundo, a cual irias?",
        "¿Cuál es tu hobby?", "Pide un deseo" };

    /// <summary>
    /// Número aleatorio que elegirá la frase.
    /// </summary>
    private int rnd;

    /// <summary>
    /// Componente Animator.
    /// </summary>
    private Animator anim;

      
	void Start ()
    {
        rnd = Random.Range(0, handicap.Length);
        gameObject.GetComponent<Text>().text = handicap[rnd];

        anim = GetComponent<Animator>();
	}
	
    /// <summary>
    /// Al hacer click, se activa la animación y pasa de escena.
    /// </summary>
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            print("Touch");
            anim.SetBool("out", true);
     
            StartCoroutine(waituwu());
        }
            
	}

    /// <summary>
    /// En esta corrutina cambiamos de escena tras 3 segundos.
    /// </summary>
    /// <returns></returns>
    private IEnumerator waituwu()
    {     
        yield return new WaitForSeconds(3f);
        ProjectSceneManager.Instance.NextScene();
    }


    


    
}
