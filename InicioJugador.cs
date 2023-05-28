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
        //Jugador = Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity); //Quaternion es para que no tenga en cuenta la rotación
        //DontDestroyOnLoad(Jugador);

        int indexJugador = PlayerPrefs.GetInt("JugadorIndex", 0);
        GameObject jugador = Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity); //Quaternion es para que no tenga en cuenta la rotación
                                                                                                                                                   //Jugador = Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity); //Quaternion es para que no tenga en cuenta la rotación

        cameraController.player = jugador;
        stickyPlatform.player = jugador;
        finish.player = jugador;



        //Declaro aquí cada objeto con el que interactua el jugador: cámara, plataformas...
        //Después hay que arrastrarlo al editor

    }


}
