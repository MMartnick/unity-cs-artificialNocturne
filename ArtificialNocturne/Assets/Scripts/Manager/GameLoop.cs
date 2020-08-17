using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    public GameObject text;
    public int Score;
    public string menu = "MainMenu";
    private float currentHP;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Score = ScoringSystem.score;
    }

    // Update is called once per frame
    void Update()
    {
        currentHP = Player.GetComponent<CharacterData>().CurrentHP;
        Score = ScoringSystem.score;

        if (currentHP == 0)
        {
            StartCoroutine(Loser());
        }

        if (Score == 3)
        {
            StartCoroutine(Winner());
        }
    }

    IEnumerator Winner()
    {
        text.GetComponent<Text>().text = "You Win!";

        yield return new WaitForSecondsRealtime(4);
        SceneManager.LoadScene(menu);
    }

    IEnumerator Loser()
    {
        text.GetComponent<Text>().text = "You Died!";

        yield return new WaitForSecondsRealtime(4);
        SceneManager.LoadScene(menu);
    }
}
