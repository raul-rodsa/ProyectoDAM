using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField] private Transform player;
    public GameObject player;
    public bool gameRunning;
    [SerializeField] AudioSource sonidoPausa;
    [SerializeField] AudioSource musicaFondo;

    // Update is called once per frame
    private void Start()
    {
        player = FindObjectOfType<InicioJugador>().prefabJugador;
    }
    void Update()
    {
        //Nota: PLAYER, PLAYER, TRANSFORM porque player.z = 0 y transform.z = -10
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        // Calcula la posición a la que la cámara debe moverse
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = targetPosition;
        // Mueve la cámara suavemente a la nueva posición
        //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 2);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cambiarGameRunning();
        }


    }
    public void cambiarGameRunning()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {
            //Corre

            Debug.Log("COrre");
            Time.timeScale = 1f;
            sonidoPausa.Play();
            musicaFondo.Play();
        }else
        {
            //Pausa
            Debug.Log("Pausa");
            Time.timeScale = 0f;
            sonidoPausa.Play();
            musicaFondo.Pause();
        }
    }

}
