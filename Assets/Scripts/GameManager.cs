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

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InactiveImage", 1.0f);

        panel.SetActive(false);

        oldGameState = PlayerController.gameState;
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

        }
        else if (PlayerController.gameState == "gameOver")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            Button btNext = nextButton.GetComponent<Button>();
            btNext.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOver;
            PlayerController.gameState = "gameend";
        }
        else if (PlayerController.gameState == "playing")
        {

        }

    }
}
