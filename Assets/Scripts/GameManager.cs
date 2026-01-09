using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameScreen;
    public GameObject[] targets;
    public float spawnInterval = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    private int score = 0;
    private bool isGameActive = false;
    public Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       titleScreen.SetActive(true);
       gameScreen.SetActive(false);

    }

    public void BeginGame(int difficulty)
    {
        spawnInterval /= difficulty;    
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        gameScreen.SetActive(true);    
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds (spawnInterval);
            int index = Random.Range(0, targets.Length);
            Instantiate(targets[index]);
        }
        
    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive (true);   
        restartButton.gameObject.SetActive (true);
        StopAllCoroutines();    
    }
    public void UpdateScore(int scoreToAdd)
    {
       
        {
            isGameActive = true;
            score += scoreToAdd;
            scoreText.text = "score: " + score;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
