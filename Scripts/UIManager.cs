using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager obj;

    public Text livesLbl;
    public Text scoreLbl;
    public bool gamePause;
    public Transform uiPanel;
    public Transform UIPanelPreg;
    public Transform UIPanelPreg2;
    public Transform UIPanelPreg3;
     public Transform UIPanelPreg4;
    public int maxHealth = 5;
    public int score = 0;
    public int scoreGive = 0;

    private void Awake()
    {
        obj = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePause = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLives()
    {
        livesLbl.text = "" + PlayerController.obj.health;
    }

    public void updateScore()
    {
        scoreLbl.text = "" + score;
    }

    public void startGame()
    {
        AudioController.obj.playGui();
        gamePause = true;
        uiPanel.gameObject.SetActive(true);
        UIPanelPreg.gameObject.SetActive(false);
        UIPanelPreg2.gameObject.SetActive(false);
        UIPanelPreg3.gameObject.SetActive(false);
        UIPanelPreg4.gameObject.SetActive(false);
    }

    public void hideInitPanel()
    {
        AudioController.obj.playGui();
        gamePause = false;
        uiPanel.gameObject.SetActive(false);
    }

    public void hidePanelPreg()
    {
        UIPanelPreg.gameObject.SetActive(true);
        gamePause = true;
    }

    public void hidePanelPreg2()
    {
        
        UIPanelPreg2.gameObject.SetActive(true);
        gamePause = true;
    }

    public void hidePanelPreg3()
    {
        
        UIPanelPreg3.gameObject.SetActive(true);
        gamePause = true;
    }

    public void hidePanelPreg4()
    {
        
        UIPanelPreg4.gameObject.SetActive(true);
        gamePause = true;
    }

   
    public void RInco()
    {
        AudioController.obj.playErr();
    }

    public void RCorr()
    {
        AudioController.obj.playGood();
        gamePause = false;
        UIPanelPreg.gameObject.SetActive(false);
        UIPanelPreg2.gameObject.SetActive(false);
        UIPanelPreg3.gameObject.SetActive(false);
        UIPanelPreg4.gameObject.SetActive(false);
        PlayerController.obj.addLive();
    }


    public void addScore(int scoreGive)
    {
        score += scoreGive;
    }

    private void OnDestroy()
    {
        obj = null;
    }


}
