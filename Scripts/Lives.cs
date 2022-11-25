using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            AudioController.obj.playLive();
            PlayerController.obj.addLive();
            UIManager.obj.updateLives();
            Destroy(gameObject);
        }
    }
}
