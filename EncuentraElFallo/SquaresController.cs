using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Este script lo tiene el objeto SquareController de la escena EncuentraElFallo.
/// </summary>
public class SquaresController : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Array de cuadrados
    /// </summary>
    [SerializeField]
    GameObject[] squares;

    /// <summary>
    /// SpriteRenderer del cuadrado diferente 
    /// </summary>
    SpriteRenderer srU;

    /// <summary>
    /// SpriteRenderer de los cuadrados.
    /// </summary>
    SpriteRenderer sr;

    /// <summary>
    /// Número aleatorio que elige el cuadrado que será distinto
    /// </summary>
    int randomSquare;

    /// <summary>
    /// Número aleatorio que elige el color de los cuadrados
    /// </summary>
    int randomColor;

    /// <summary>
    /// Número aleatorio que elige el color del cuadrado único
    /// </summary>
    int randomColorUnico;

    /// <summary>
    /// Referenciamos un objeto que suena nada más activarse (Play on Awake)
    /// </summary>
    [SerializeField]
    GameObject sonido;

    /// <summary>
    /// Referenciamos un canvas
    /// </summary>
    [SerializeField]
    private GameObject canvas;

    #endregion Variables

    /// <summary>
    /// Paramos el tiempo antes de iniciar el programa.
    /// </summary>
    private void Awake()
    {
        Time.timeScale = 0.0f;   
    }


    void Start()
    {
        generarColor();
        generarCuadrado();
        srU = (SpriteRenderer)squares[randomSquare].GetComponent<SpriteRenderer>();
        colorear();
        //Nos aseguramos de que está desactivado
        sonido.SetActive(false);
    }

    #region Update
    private void Update()
    {
        //Si hacemos click, y el tiempo está parado (Recordamos que está así en Awake): Se desactiva el canvas y vuelve el tiempo a su normalidad (1f);
        if (Input.GetMouseButton(0) && Time.timeScale == 0.0f)
        {
            canvas.SetActive(false);
            Time.timeScale = 1.0f;
            //Le añadimos un box collider solo al cuadrado único. Se lo agregamos aquí porque si no el usuario puede darle sin querer al cuadrado antes de que empiece la partida.
            squares[randomSquare].AddComponent<BoxCollider2D>();
        }

        //Condición de victoria, una vez que el color único es igual al resto, habrá ganado
        if (randomColorUnico == randomColor)
        {
            StartCoroutine(Sonido());
        }
    }
    #endregion Update

    #region generadores
    /// <summary>
    /// Genera un número aleatorio, el cual será la posición del cuadrado que tendrá un color distinto
    /// </summary>
    void generarCuadrado()
    {
        randomSquare = Random.Range(0, squares.Length);
    }

    /// <summary>
    /// Genera un número que determinará el color de casi todos los cuadrados y otro número que determinará el color del cuadrado único
    /// Nos aseguramos de que ambos números sean distintos (colores distintos)
    /// </summary>
    void generarColor()
    {
        randomColor = Random.Range(1, 5);
        randomColorUnico = Random.Range(1, 5);
        while(randomColor == randomColorUnico)
        {
            randomColor = Random.Range(1, 5);
        }
    }
    #endregion generadores

    #region colorear
    /// <summary>
    /// Función que, según el número que se le pase coloreará los cuadrados.
    /// Luego coloreará el cuadrado distinto.
    /// </summary>
    void colorear()
    {
        #region colorearTodos
        switch (randomColor)
        {
            case 1:
                print("blue");
                for (byte i = 0; i < squares.Length; i++)
                {
                    sr = (SpriteRenderer)squares[i].GetComponent<SpriteRenderer>();
                    sr.color = new Color(124f/255f, 194f/255f, 244f / 255f);
                }
                break;
            case 2:
                print("green");
                for (byte i = 0; i < squares.Length; i++)
                {
                    sr = (SpriteRenderer)squares[i].GetComponent<SpriteRenderer>();
                    sr.color = new Color(162f / 255f, 254f / 255f, 128f / 255f);
                }
                break;
            case 3:
                print("yellow");
                for (byte i = 0; i < squares.Length; i++)
                {
                    sr = (SpriteRenderer)squares[i].GetComponent<SpriteRenderer>();
                    sr.color = new Color(255f / 255f, 245f / 255f, 143f / 255f);
                }
                break;
            case 4:
                print("red");
                for (byte i = 0; i < squares.Length; i++)
                {
                    sr = (SpriteRenderer)squares[i].GetComponent<SpriteRenderer>();
                    sr.color = new Color(250f / 255f, 123f / 255f, 138f / 255f);
                }
                break;
        }
        #endregion colorearTodos

        #region colorearUnico
        //Dependiendo del número aleatorio que salga, se le cabiará el color al cuadrado aleatorio;
        switch (randomColorUnico)
        {
            case 1:
                print("blueU");
                srU.color = new Color(124f/255f, 194f / 255f, 244f / 255f);
                break;
            case 2:
                print("greenU");
                srU.color = new Color(162f / 255f, 254f / 255f, 128f / 255f);
                break;
            case 3:
                print("yellowU");
                srU.color = new Color(255f / 255f, 245f / 255f, 143f / 255f);
                break;
            case 4:
                print("redU");
                srU.color = new Color(250f / 255f, 123f / 255f, 138f / 255f);
                break;
        }
        #endregion colorearUnico
    }
    #endregion colorear

    #region Cambio de color + Condición de victoria 
    /// <summary>
    /// Esta función será llamada desde el script Square, que lleva cada cuadrado.
    /// </summary>
    public void WhenClicking()
    {
        if (randomColorUnico != randomColor)
        {
            switch (randomColorUnico)
            {
                case 1:
                    randomColorUnico++;
                    break;
                case 2:
                    randomColorUnico++;
                    break;
                case 3:
                    randomColorUnico++;
                    break;
                case 4:
                    randomColorUnico = 1;
                    break;
            }
            colorear();
        }
    }
    #endregion Cambio de color + Condición de victoria 

    #region Victoria
    /// <summary>
    /// Corrutina con las últimas acciones de este minijuego.
    /// Cambia de escena accediendo al ProjectSceneManager
    /// </summary>
    /// <returns></returns>
    IEnumerator Sonido()
    {
        sonido.SetActive(true);
        yield return new WaitForSeconds(2f);
        //Activa la animación zoomin
        RipplePostProcessor.anim.SetBool("zoomin", true);
        //Accedemos con la función estática del ProjectSceneManager al script para cambiar de escena.
        ProjectSceneManager.Instance.NextScene();
    }
    #endregion Victoria

}
