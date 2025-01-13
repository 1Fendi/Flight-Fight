using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Threading.Tasks;

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
        SceneManager.LoadScene(0);
    }

    // Function to start the game
    public void ToPlay()
    {
        SceneManager.LoadScene(1);
    }

    
    public void TimeDelay(float delayTime)
    {
       StartCoroutine(DelayAction(delayTime));
    }

    IEnumerator DelayAction(float delayTime)
    {
       //Wait for the specified delay time before continuing.
       yield return new WaitForSeconds(delayTime);

       //Do the action after the delay time has finished.
    }

    // Function to add a value to an integer reference
    public int IntAdd(ref int num, int add)
    {
        return num += add;
    }
}