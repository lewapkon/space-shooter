using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameController _gameController;

    private void Start()
    {
        var gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            _gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (explosion != null)
        {
            var thisTransform = transform;
            Instantiate(explosion, thisTransform.position, thisTransform.rotation);
        }

        if (other.CompareTag("Player"))
        {
            var playerTransform = other.transform;
            Instantiate(playerExplosion, playerTransform.position, playerTransform.rotation);
            _gameController.GameOver();
        }
        else
        {
            _gameController.AddScore(scoreValue);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}