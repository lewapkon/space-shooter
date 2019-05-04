using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool _gameOver;
    private bool _restart;
    private int _score;

    private void Start()
    {
        _gameOver = false;
        _restart = false;
        restartText.text = "";
        gameOverText.text = "";
        _score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (_restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (var i = 0; i < hazardCount; i++)
            {
                var spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y,
                    spawnValues.z);
                var spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (_gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                _restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        _score += newScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        _gameOver = true;
    }
}