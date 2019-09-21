using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUi : MonoBehaviour
{
    public GameObject GameOverObject;
    public Text gameScore;
    bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Movement2D>().OnPlayerDeath += ShowGameOver;
    }

    public void ShowGameOver()
    {
        isGameOver = true;
        GameOverObject.SetActive(true);
        gameScore.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyUp("space"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
