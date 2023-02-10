using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject mainImage;
    public Sprite gameOver;
    public Sprite gameClear;
    public GameObject panel;
    public GameObject restartButton;
    public GameObject nextButton;

    Image titleImage;

    string oldGameState;

    public GameObject timeBar;
    public GameObject timeText;
    TimeController timeCnt;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InactiveImage", 1.0f);

        panel.SetActive(false);

        oldGameState = PlayerController.gameState;

        timeCnt = GetComponent<TimeController>();
        if (timeCnt != null)
        {
            if (timeCnt.gameTime == 0.0f)
            {
                timeBar.SetActive(false);
            }
        }
    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (oldGameState != PlayerController.gameState)
        {
            Debug.Log(PlayerController.gameState);
        }

        if (PlayerController.gameState == "gameClear")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            Button btRestart = restartButton.GetComponent<Button>();
            btRestart.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClear;
            PlayerController.gameState = "gameend";

            if(timeCnt != null)
            {
                timeCnt.isTimeOver = true;
            }
        }
        else if (PlayerController.gameState == "gameOver")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            Button btNext = nextButton.GetComponent<Button>();
            btNext.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOver;
            PlayerController.gameState = "gameend";

            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true;
            }
        }
        else if (PlayerController.gameState == "playing")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();

            if(timeCnt != null)
            {
                if (timeCnt.gameTime > 0.0f)
                {
                    int time = (int)timeCnt.displayTime;
                    timeText.GetComponent<Text>().text = time.ToString();

                    if (time == 0)
                    {
                        playerController.GameStop();
                    }
                }
            }
        }

    }
}
