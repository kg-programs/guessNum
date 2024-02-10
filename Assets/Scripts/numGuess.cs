using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class numGuess : MonoBehaviour
{
    public TMP_Text sendMessageText;
    public TMP_InputField playerGuess;
    public Button guessButton;
    public Button restartButton;
    public Button quitButton;
    int compAnswer;
    int lives;
    bool won;
    int guessInt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void startGame()
    {
        sendMessageText.text = "Guess a number between 1 and 10";
        compAnswer = Random.Range(1, 11);
        lives = 3;
        won = false;
    }

    public void GetGuess()
    {
        if(playerGuess.text == "")
        {
            sendMessageText.text = "input is empty \n please enter a number between 1 and 10";
            
        }
        else
        {
            string guess = playerGuess.text;
            guessInt = System.Convert.ToInt32(guess);
            if(guessInt > compAnswer)
            {
                lives--;
                sendMessageText.text = "Too High \n You have "+ lives+ " guesses left";    
            }
            else if(guessInt<compAnswer){
                lives--;
                sendMessageText.text = "Too Low \n You have "+ lives+ " guesses left";
            }
            else
            {
                gameOver();
                sendMessageText.text = "You guessed correctly";
                won = true;
            }
            if(lives == 0 && !won)
            {
                gameOver();
                sendMessageText.text = "Your out of lives \n The number was " + compAnswer;
            }
        }
    }
    
    void gameOver()
    {
        playerGuess.gameObject.SetActive(false);
        guessButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
