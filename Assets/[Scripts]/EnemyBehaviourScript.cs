using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    [Header("Enemy Movement")]
    public BoundsStruct Ebounds;
    public BoundsStruct StartRange;

    private float startPoint;
    private float randomSpeed;

    [Header("Bullets")]
    public Transform bulletSpawn;
    //public GameObject bulletPrefab;
    public int frameDelay;

    private BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(Ebounds.Min, Ebounds.Max);
        startPoint = Random.Range(StartRange.Min, StartRange.Max);
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed) + startPoint, transform.position.y);
    }

    private void FixedUpdate()
    {
        if (Time.frameCount % frameDelay == 0)
        {
            //var tempBullet = Instantiate(bulletPrefab);
            //tempBullet.transform.position = bulletSpawn.position;

            bulletManager.getBullet(bulletSpawn.position);
        }
    }
}
