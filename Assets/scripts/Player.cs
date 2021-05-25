using Assets.scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;     // the prefab of our bullet
    public GameObject EnemyPrefab;     // the prefab of our bullet

    private bool _clicking;
    private float _bulletSpeed = 20f;
    private float playerSpeed=1.5f;

    // Start is called before the first frame update
     void Start()
    {
    }

    // Update is called once per frame
     void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    gameObject.transform.position = gameObject.transform.position + new Vector3(0, -1);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    gameObject.transform.position = gameObject.transform.position + new Vector3(0, 1);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    gameObject.transform.position = gameObject.transform.position + new Vector3(-1, 0);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    gameObject.transform.position = gameObject.transform.position + new Vector3(1, 0);
        //}

        //if (Input.anyKeyDown
        //    //Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
        //    )
        {
            var t = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);

            transform.position += t * playerSpeed * Time.deltaTime;
        }

        if (GameStateManager.ShouldSpawnEnemy())
        {
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            GameObject go = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            GameStateManager.AddEnemy(go);
        }

        if (Input.GetMouseButton(0))
        {
            if (!_clicking)
            {
                _clicking = true;

                
                //Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //pz.z = 0;
                
                //GameStateManager.AddEnemy(go);
            }
        }
        else if (_clicking)
        {
            _clicking = false;
        }
        // if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!GameStateManager.ShouldFire())
                return;

            var targetVector = GameStateManager.GetNext();
            if (targetVector == Vector3.zero) return;

            // if the player pressed space (exclude holding key down)
            GameObject go = Instantiate(BulletPrefab, gameObject.transform);
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.TargetVector = targetVector;
            bullet.Speed = _bulletSpeed;
        }

        GameStateManager.CurrentPlayerPosition = gameObject.transform.position;
    }
}