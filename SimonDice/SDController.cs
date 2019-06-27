using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Este script lo tiene el objeto SimonDiceController en la escena SimonDice
/// </summary>
public class SDController : MonoBehaviour
{
#region Variables
    /// <summary>
    /// Cuadrados en la escena
    /// </summary>
    [SerializeField]
    GameObject[] squares;

    /// <summary>
    /// Numero aleatorio del que depende qué color va a ser elegido en el switch y el cual va a enlistarse.
    /// </summary>
    int numeroRandom;

    /// <summary>
    /// Lista que recoge los números en orden una vez se van generando los numeros
    /// </summary>
    public List<int> secuencias = new List<int>();

    /// <summary>
    /// Array que recoge la secuencia introducida por el usuario
    /// </summary>
    public int [] secuenciaUsuario;

    /// <summary>
    /// Componente AudioSource.
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// Contador que va a llevar la cuenta para controlar la respuesta del usuario.
    /// </summary>
    private byte contador;

    #endregion Variables

    private void Start()
    {
        StartCoroutine(StartSimon());
        audioSource = GetComponent<AudioSource>();
    }

    #region Usuario
    /// <summary>
    /// Esta función es llamada a través de eventos invocados a través del delegado.
    /// El contador es quien lleva el ritmo de las posiciones que tiene que comprobar de la lista con el número que ha recogido de CuadraditoSimon
    /// Una vez que llegue al mismo número de elementos que tiene la secuencia y que anteriormente haya acertado el jugador, habrá ganado, por lo que se volverá a ejecutar el juego.
    /// Por el contrario, cambiará de escena.
    /// </summary>
    /// <param name="color">Número del color que se ha pulsado</param>
    private void UsuarioResponde(byte color)
    {
        if(secuencias[contador] == color)
        {
            print("Acierto numero " + contador);
            ++contador;
            if(contador == secuencias.Count)
            {
                print("Has ganado");
                //Desuscribo a cada cuadradito para que no se pueda seguir lanzando eventos cuando se pulsen
                for (byte i = 0; squares.Length > i; i++)
                {
                    squares[i].GetComponent<CuadraditoSimon>().DesuscribirseADelegadoCuadradito(UsuarioResponde);
                }
                //Volvemos a empezar la secuencia.
                StartCoroutine(StartSimon());
            }
        }
        else
        {
            print("Has perdido");
            Camera.main.GetComponent<Animator>().SetBool("zoomin", true);
            //Cambio de escena, manejado desde la clase ProjectSceneManager
            ProjectSceneManager.Instance.NextScene();
        }
    }
    #endregion Usuario

    #region Número aleatorio
    /// <summary>
    /// Segunda función que se ejecuta.
    /// Genera un número rándom entre el 0 y el número total de cuadrados. Por último, lo añade a la lista "secuencias".
    /// </summary>
    void GenerarNumeroAleatorio()
    {
        numeroRandom = Random.Range(0, squares.Length);
        secuencias.Add(numeroRandom);
    }
    #endregion Número aleatorio

    #region Simon Habla
    /// <summary>
    /// Esta corrutina es la tercera función invocada.
    /// Se esperan 2 segundos a que termine la animación.
    /// Dependiendo de los números que han salido aleatoriamente se ejecuta una animación u otra.
    /// Espera dos segundos hasta que termine la última animación de cada lucecita.
    /// Ahora se deja que el usuario responda.
    /// </summary>
    /// <returns></returns>
    IEnumerator SimonHabla()
    {
        yield return new WaitForSeconds(2f);
        for(int i = 0; i < secuencias.Count; i++) { 
            switch (secuencias[i])
            {
                case 0:
                    print("Lucecita roja");
                    animacionRojo();
                    break;
                case 1:
                    print("Lucecita verde");
                    animacionVerde();
                    break;
                case 2:
                    print("Lucecita amarilla");
                    animacionAmarillo();
                    break;
                case 3:
                    print("Lucecita azul");
                    animacionAzul();
                    break;
            }
            yield return new WaitForSeconds(2f);
        }
        //Definimos el contador a 0, que usaremos para saber cuantas veces responde el usuario.
        contador = 0;
        //Suscribo cada cuadrado al delegado.
        for (byte i = 0; squares.Length > i; i++)
        {
            squares[i].GetComponent<CuadraditoSimon>().SuscribirseADelegadoCuadradito(UsuarioResponde);
        }
    }
    #endregion Simon Habla

    #region Comenzar programa
    /// <summary>
    /// Esta es la primera corrutina, la cual es llamada para que empiece el juego.
    /// Llama 4 veces la función que genera los números aleatorios: "GenerarNumeroAleatorio()".
    /// Por último, invoca la corrutina "SimonHabla()"
    /// </summary>
    /// <returns></returns>
    IEnumerator StartSimon()
    {
        if (secuencias.Count != 0)
        {
            //En caso de que ya haya números en la lista, los elimina y vuelve a empezar desde cero
            secuencias.Clear();
        }
        for (int i= 0; i < 4; ++i)
        {
            GenerarNumeroAleatorio();
        }           
        StartCoroutine(SimonHabla());
        yield return null;
    }
    #endregion Comenzar programa

    #region Animaciones
    void animacionAmarillo()
    {
        squares[2].GetComponent<Animator>().SetBool("go", true);
        squares[2].GetComponent<AudioSource>().Play();
    }

    void animacionAzul()
    {
        squares[3].GetComponent<Animator>().SetBool("go", true);
        squares[3].GetComponent<AudioSource>().Play();
    }

    void animacionVerde()
    {
        squares[1].GetComponent<Animator>().SetBool("go", true);
        squares[1].GetComponent<AudioSource>().Play();
    }

    void animacionRojo()
    {
        squares[0].GetComponent<Animator>().SetBool("go", true);
        squares[0].GetComponent<AudioSource>().Play();
    }
    #endregion Animaciones
}
