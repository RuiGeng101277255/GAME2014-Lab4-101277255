using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> EnemybulletPool;
    public Queue<GameObject> PlayerbulletPool;
    public int EnemyBulletCount;
    public int PlayerBulletCount;

    private BulletFactory BFactory;

    // Start is called before the first frame update
    void Start()
    {
        EnemybulletPool = new Queue<GameObject>(); // empty queue
        PlayerbulletPool = new Queue<GameObject>(); // empty queue
        BFactory = GetComponent<BulletFactory>();
    }

    private void AddBullet(BulletType type)
    {
        var tempBullet = BFactory.createBullet(type);

        switch (type)
        {
            case BulletType.ENEMY:
                EnemybulletPool.Enqueue(tempBullet);
                EnemyBulletCount++;
                break;
            case BulletType.PLAYER:
                PlayerbulletPool.Enqueue(tempBullet);
                PlayerBulletCount++;
                break;
        }
    }

    public GameObject getBullet(Vector2 v, BulletType type)
    {
        GameObject tempBullet = null;

        switch (type)
        {
            case BulletType.ENEMY:
                if (EnemybulletPool.Count < 1)
                {
                    AddBullet(BulletType.ENEMY);
                }

                tempBullet = EnemybulletPool.Dequeue();
                tempBullet.transform.position = v;
                tempBullet.SetActive(true);
                break;
            case BulletType.PLAYER:
                if (PlayerbulletPool.Count < 1)
                {
                    AddBullet(BulletType.PLAYER);
                }

                tempBullet = PlayerbulletPool.Dequeue();
                tempBullet.transform.position = v;
                tempBullet.SetActive(true);
                break;
        }

        return tempBullet;
    }

    public void ReturnBullet(GameObject ReturnedBullet, BulletType type)
    {
        ReturnedBullet.SetActive(false);

        switch (type)
        {
            case BulletType.ENEMY:
                EnemybulletPool.Enqueue(ReturnedBullet);
                break;
            case BulletType.PLAYER:
                PlayerbulletPool.Enqueue(ReturnedBullet);
                break;
        }
    }
}
