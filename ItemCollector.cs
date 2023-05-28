using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para poder usar TEXT

public class ItemCollector : MonoBehaviour
{
    //No necesitamos ni start ni update, solo triggerear
    [SerializeField] public Text cherriesText; //Se selecciona desde player
    [SerializeField] public AudioSource collectAudioSource;
    private int cherries = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Cherry")) //(collision.gameObject.CompareTag("Cherry"))
        {
            collectAudioSource.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cerezuelas: " + cherries;
            
        }
    }

}

