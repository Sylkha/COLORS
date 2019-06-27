using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gestiona las escenas del proyecto. Este script lo tiene el objeto ScenesController.
/// </summary>
public class ProjectSceneManager : MonoBehaviour
{
    #region Singleton management
    static ProjectSceneManager instance;

    static public ProjectSceneManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Este gameObject persiste entre escenas
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    #endregion

    /// <summary>
    /// Escenas a gestionar.
    /// El orden el array es el orden de carga
    /// </summary>
    [SerializeField]
    UnityEditor.SceneAsset[] scenes;

    /// <summary>
    /// Escena actual
    /// </summary>
    int currentScene;


    private void Start()
    {
        //Primera escena
        currentScene = 0;
    }

    //private void Update()
    //{
    //    //Ordena el cambio de escena si se pulsa la barra espaciadora
    //    if (Input.GetButtonDown("Jump"))
    //        NextScene();
    //}

    /// <summary>
    /// Gestiona el cambio de escena.
    /// </summary>
    public void NextScene()
    {
        if (++currentScene >= scenes.Length)
            currentScene = 0;

        SceneManager.LoadScene(scenes[currentScene].name);
    }

}
