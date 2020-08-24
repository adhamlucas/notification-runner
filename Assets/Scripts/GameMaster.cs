using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public GameObject restartPanel;

    public Text timerDisplay;

    private bool asLost;

    public float timer;

    private void Update() {

        if (asLost == false) {
            timerDisplay.text = timer.ToString("F0");
        }

        if (timer <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        } else { 
            if(asLost == false) {
                timer -= Time.deltaTime;
            }
        }
    }

    public void GameOver () {
        asLost = true;
        Invoke("Delay", 0.3f);
    }

    public void Delay() {
        restartPanel.SetActive(true);
    }

    public void GoToGameScene() {
        SceneManager.LoadScene("Level1");
    }
    
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
