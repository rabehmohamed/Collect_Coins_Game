using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText;
    public GameObject player;
    public int sum = 0;
    public Button restartB;
    // Start is called before the first frame update
    void Start()
    {
        updateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z < -127) {
            win();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartB.gameObject.SetActive(true);
    }
    public void win()
    {
        winText.gameObject.SetActive(true);
        restartB.gameObject.SetActive(true);
    }
    public void updateScore(int scoreAdd)
    {
        sum += scoreAdd;
        scoreText.text = "Score: " + sum;
    }
    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
