using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }

        var thisTransform = transform;
        Instantiate(explosion, thisTransform.position, thisTransform.rotation);
        if (other.CompareTag("Player"))
        {
            var playerTransform = other.transform;
            Instantiate(playerExplosion, playerTransform.position, playerTransform.rotation);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}