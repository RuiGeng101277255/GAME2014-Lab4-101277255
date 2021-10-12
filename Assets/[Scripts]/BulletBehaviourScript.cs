using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourScript : MonoBehaviour
{
    public BulletType BType;

    [Header("Bullet Movement")]
    [Range(0.0f, 0.5f)]
    public float speed;
    public BoundsStruct Bbounds;
    public BulletDirection BDir;

    private BulletManager bulletManager;
    private Vector3 BVel;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = GameObject.FindObjectOfType<BulletManager>();

        switch(BDir)
        {
            case BulletDirection.UP:
                BVel = new Vector3(0.0f, speed, 0.0f);
                break;
            case BulletDirection.RIGHT:
                BVel = new Vector3(speed, 0.0f, 0.0f);
                break;
            case BulletDirection.DOWN:
                BVel = new Vector3(0.0f, -speed, 0.0f);
                break;
            case BulletDirection.LEFT:
                BVel = new Vector3(-speed,  0.0f, 0.0f);
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += BVel;
    }
    
    private void CheckBounds()
    {
        if (transform.position.y < Bbounds.Max)
        {
            //Destroy(this.gameObject);
            bulletManager.ReturnBullet(this.gameObject, BType);
        }

        if (transform.position.y > Bbounds.Min)
        {
            //Destroy(this.gameObject);
            bulletManager.ReturnBullet(this.gameObject, BType);
        }
    }
}
