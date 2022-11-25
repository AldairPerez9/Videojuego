using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioController.obj.playPregunta();
            UIManager.obj.hidePanelPreg3();
            Destroy(gameObject);
        }


    }
}
