using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * speed;
    }
}