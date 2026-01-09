using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Difficultybutton : MonoBehaviour
{
    public int difficulty;
    private Button button;
    private GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        Debug.Log("Difficulty Set");
        gameManager.BeginGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
