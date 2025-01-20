using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
public class LogicManger : MonoBehaviour
{
    public Text gameOverText; // Reference to the game over text UI element
    public Button PlayAgain; // Reference to the play again button UI element
    public Button MainMenu; // Reference to the main menu button UI element

    // Function to restart the game
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Function to go to the main menu
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Function to start the game
    public void ToPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    
    public void PlayAgainButton()
    {
        PlayAgain.gameObject.SetActive(true);
    }
    
    public void MainMenuButton()
    {
        MainMenu.gameObject.SetActive(true);
    }
    
    public void StartTimeDelay(float delayTime, float rateTime, Action func)
    {
        StartCoroutine(TimeDelay(delayTime, rateTime, func));
    }
    
    public IEnumerator TimeDelay(float delayTime, float rateTime, Action func)
    {
        if (rateTime == delayTime)
        {
            func?.Invoke();
            yield break;
        }
        
        while (Mathf.Abs(rateTime - delayTime) > Mathf.Epsilon)
        {
            rateTime = Mathf.MoveTowards(rateTime, delayTime, Time.deltaTime);
            yield return null;
        }
        func?.Invoke();
    }
    
    public IEnumerator SecDelay(float delayTime, Action func)
    {
        yield return new WaitForSeconds(delayTime);
        func?.Invoke();
    }

    // Function to add a value to an integer reference
    public int IntAdd(ref int num, int add)
    {
        return num += add;
    }
}