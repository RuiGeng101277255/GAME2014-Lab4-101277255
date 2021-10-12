using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    [Header("Player Movement")]
    public float HorizontalForce;
    [Range(0.0f, 1.0f)]
    public float VelDecay;
    public BoundsStruct Pbounds;

    [Header("Player Attack")]
    public Transform BulletSpawn;
    public int FrameDelay;

    private Rigidbody2D playerRB;

    private BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
        PlayerFire();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        playerRB.AddForce(new Vector2(x * HorizontalForce, 0.0f));

        playerRB.velocity *= (1.0f - VelDecay);
    }

    private void CheckBounds()
    {
        //Left
        if (transform.position.x < Pbounds.Min)
        {
            transform.position = new Vector2(Pbounds.Min, transform.position.y);
        }

        //Right
        if (transform.position.x > Pbounds.Max)
        {
            transform.position = new Vector2(Pbounds.Max, transform.position.y);
        }
    }

    private void PlayerFire()
    {
        if ((Time.frameCount % FrameDelay == 0) &&(Input.GetAxisRaw("Jump") > 0))
        {
            bulletManager.getBullet(BulletSpawn.position, BulletType.PLAYER);
        }
    }
}
