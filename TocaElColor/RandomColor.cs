using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Este script lo tiene el objeto C_Blanco en la escena TocaElColor
/// </summary>
public class RandomColor : MonoBehaviour
{
    /// <summary>
    /// Array de colores
    /// </summary>
    private Color[] colAr = { new Color(124f / 255f, 194f / 255f, 244f / 255f), new Color(162f / 255f, 254f / 255f, 128f / 255f), new Color(255f / 255f, 245f / 255f, 143f / 255f), new Color(250f / 255f, 123f / 255f, 138f / 255f) };

    /// <summary>
    /// Componente SpriteRenderer
    /// </summary>
    private SpriteRenderer render;

    /// <summary>
    /// Referencia del objeto C_Blanco
    /// </summary>
    [SerializeField]
    private GameObject go;

    /// <summary>
    /// Referencia del objeto MANITO
    /// </summary>
    [SerializeField]
    private GameObject manita;

    /// <summary>
    /// Comprobación para pasar la animación
    /// </summary>
    public bool passTo;

    /// <summary>
    /// Componente Animator
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Array de componentes AudioSource
    /// </summary>
    public AudioSource [] audioSource;

    void Start()
    {

        int i = Random.Range(0, 4);
        gameObject.GetComponent<SpriteRenderer>().color = colAr[i];

        anim = GetComponent<Animator>();

        passTo = false;
        StartCoroutine(TimetoGo());


    }

    /// <summary>
    /// Al pulsar la pantalla, se activa el sonido, la animación, se oculta el objeto manita y se termina con la corrutina Victoria
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {            
            if (passTo == true)
            {
                audioSource[0].Play();
                print(passTo);
                anim.SetBool("go", true);
                manita.SetActive(false);
                StartCoroutine(Victoria());
            }
        }
    }

    /// <summary>
    /// Corrutina que se inicia al comenzar este minijuego. Tras unos segundos, activa el booleano que permite que la condición del Update se pueda cumplir
    /// </summary>
    /// <returns></returns>
    private IEnumerator TimetoGo()
    {
        yield return new WaitForSeconds(7f);
        passTo = true;
        manita.SetActive(true);
        
    }

    /// <summary>
    /// Pasa de escena y activa otro sonido.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Victoria()
    {
        yield return new WaitForSeconds(0.5f);
        audioSource[1].Play();

        ProjectSceneManager.Instance.NextScene();
    }

}
