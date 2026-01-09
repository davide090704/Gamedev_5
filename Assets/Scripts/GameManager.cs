using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    public GameObject[] targets;
    public float spawnInterval = 1.0f;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
