using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    public Vector2 fireRate;
    public float fireDelay;
    public float lowestPointFire;

    private float _nextFire;
    private AudioSource _audioSource;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _nextFire = Time.time + fireDelay;
    }

    void Update()
    {
        if (Time.time > _nextFire && shotSpawn.position.z > lowestPointFire)
        {
            _nextFire = Time.time + Random.Range(fireRate.x, fireRate.y);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            _audioSource.Play();
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(0, 0, -speed);
        _rb.rotation = Quaternion.Euler(0, -180, _rb.velocity.x * -tilt);
    }
}