using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameLogic : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public int lives = 3;
    public GameObject gameoverScreen;
    public GameObject pauseScene;
    private bool isGamePause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGamePause)
        {
            print("OOORR");
            PauseGame();
         
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isGamePause)
        {
            print("OOORR");
            ResumeGame();
      
        }
    }
    [ContextMenu("Increase score")]
    public void GetDamage()
    {
        lives -= 1;
        textScore.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
    }
    public void GameOver()
    {
        gameoverScreen.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void PauseGame() {
        Time.timeScale = 0;
        pauseScene.SetActive(true);
        isGamePause = true;
    }

    public void ResumeGame()
    {

        Time.timeScale = 1;
        pauseScene.SetActive(false);
        isGamePause = false;
    }
}
