using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreGive = 60;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioController.obj.playCoin();
            UIManager.obj.addScore(scoreGive);
            UIManager.obj.updateScore();
            Destroy(gameObject);
        }
    }
}
