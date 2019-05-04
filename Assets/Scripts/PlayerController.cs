using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float _nextFire;
    private AudioSource _audioSource;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            _nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            _audioSource.Play();
        }
    }

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        _rb.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        _rb.position = new Vector3(
            Mathf.Clamp(_rb.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(_rb.position.z, boundary.zMin, boundary.zMax));

        _rb.rotation = Quaternion.Euler(0, 0, _rb.velocity.x * -tilt);
    }
}