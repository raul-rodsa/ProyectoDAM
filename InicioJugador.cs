using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicioJugador : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabJugador;
    public CameraController cameraController;
    public StickyPlatform stickyPlatform;
    public Finish finish;

    
    void Start()
    {
        //int indexJugador = PlayerPrefs.GetInt("JugadorIndex", 0);
        //Jugador = Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity); //Quaternion es para que no tenga en cuenta la rotaci�n
        //DontDestroyOnLoad(Jugador);

        int indexJugador = PlayerPrefs.GetInt("JugadorIndex", 0);
        GameObject jugador = Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity); //Quaternion es para que no tenga en cuenta la rotaci�n
                                                                                                                                                   //Jugador = Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity); //Quaternion es para que no tenga en cuenta la rotaci�n

        cameraController.player = jugador;
        stickyPlatform.player = jugador;
        finish.player = jugador;



        //Declaro aqu� cada objeto con el que interactua el jugador: c�mara, plataformas...
        //Despu�s hay que arrastrarlo al editor

    }


}
