using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManagerScript;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(SetDifficulty); // "AddListener()" listens or pays attention to when a certain event has happened, and then executes the method in its parentheses.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty() // This is called a method btw.
    {
        Debug.Log(button.gameObject.name + " has been clicked");
        gameManagerScript.StartGame(difficulty);
    }
}
