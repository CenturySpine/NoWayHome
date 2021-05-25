using Assets.scripts;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool _isMoving;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = 1.0f * Time.deltaTime;
        _isMoving = true;
        rb.transform.position = Vector2.MoveTowards(rb.transform.position, GameStateManager.CurrentPlayerPosition, step);


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameStateManager.RemoveEnemy(gameObject);
        Destroy(gameObject);
    }
}