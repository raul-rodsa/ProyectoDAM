using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; //Para cambiar de niveles

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelComplete = false;
    public GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player && !levelComplete)
        {
            finishSound.Play();
            levelComplete = true;
            Invoke("CompleteLevel", 1.5f); //espera 1.5 segundos antes de pasar de nivel
            
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
