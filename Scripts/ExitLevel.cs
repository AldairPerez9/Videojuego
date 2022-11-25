using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public int scene;
    public GameObject transition;
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioController.obj.playExit();
            transition.SetActive(true);
            canvas.SetActive(false);
            Invoke("ChangeLevel", 5.0f);
        }

    }



    public void ChangeLevel()
    {
        SceneManager.LoadScene(scene);
    }
}
