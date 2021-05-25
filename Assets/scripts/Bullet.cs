using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 0.4f;          // The speed our bullet travels
    public Vector3 TargetVector;    // the direction it travels
    public float Lifetime = 10f;     // how long it lives before destroying itself
    public float Damage = 10;       // how much damage this projectile causes
    private Rigidbody2D rb;
    private bool _isMoving;

    void Start()
    {
        // find our RigidBody
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
        // add force
        // rb.AddForce(targetVector.normalized * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isMoving)
        {
            _isMoving = true;
            rb.AddForce(TargetVector * Speed);
        }

        // decrease our life timer
        Lifetime -= Time.deltaTime;
        if (Lifetime <= 0f)
        {
            // we have ran out of life
            Destroy(gameObject);    // kill me
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}