using System.Collections; // This is a standard C# imported library.
using System.Collections.Generic; // This is a standard C# imported library.
using UnityEngine; // This is an imported Unity library, which enables us to use all of the different unity methods and classes, such as "GameObjects" or "MonoBehaviour".
using TMPro; // This package enables us to use all the different classes and methods for TextMesh, so that we can interact with them and control our UI.
using UnityEngine.SceneManagement; // The "SceneManagement" library allows us to interact with and manage our scenes in our scene folder.
using UnityEngine.UI; // Enables us to interact with buttons. We wouldn't be able to create a "public button restart" without this library.

// "Using" is a special keyword in C# that enables us to import other libraries and packages into the current script that we're editing.

public class GameManager : MonoBehaviour
{

    // The "GameManager" script is very often used by game devs to change the different settings of a game, which is why it has a different icon unlike the standard C# icon in all the other scripts (unity tries to help us identify it easier by giving it a different icon).

    // A "List" is an extremely similar data structure to an "Array", but they differ a bit in terms of functionality. 
    // In a "List" we need to give it the type of something in "< >".
    // The difference between a "List" and and an "Array" is that, with a "List" itself we need to pass it in the type of thing that we want "GameObject", whereas in an "Array" we have to tell the array what that thing is before we make the array itself. They both have slightly different functionality.
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public Button restart;
    public GameObject titleScreen;
    public bool isGameActive;
    private float score;
    public float spawnTime = 1;


    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    // An "Ienumerator", which uses "StartCoroutine", is used when you need to do any weird-multi-step; whereas an "InvokeRepeating" is easier to learn and use, but can only do things at regular intervals, any weird-multi-step and you would have to use a coroutine.
    // An "if" statement requires a condition to tell it when to stop.
    // A "for-loop" will iterate over something a certain number of times to execute your code.
    // A "while-loop" will execute your code continuously, but instead of giving it a defined number of times to run (like a "for-loop"), we can actually use a condition to tell it when it should actually stop running.

    IEnumerator SpawnTargets()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnTime);
            int targetIndex = Random.Range(0, targets.Count); // ".Length" is used for an "Array []" data structure; whereas a "Count" is used for a "List" data structure.
            Instantiate(targets[targetIndex]);
        }
    }


    public void ScoreUpdate(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score; // "Concatenation"
    }


    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        isGameActive = false;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // "SceneManager.GetActiveScene().name" gets the name of the current scene we are using. We can also write it like this "SceneManager.LoadScene("Prototype 5");"
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true; // Always put variables before you actually use them to avoid breaking the game.
        score = 0;
        spawnTime /= difficulty;

        StartCoroutine(SpawnTargets());
        ScoreUpdate(0);

        titleScreen.gameObject.SetActive(false);
    }
}
