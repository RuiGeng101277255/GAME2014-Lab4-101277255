using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public int MaxBulletCount;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>(); // empty queue
        buildPool();
    }

    private void buildPool()
    {
        for (int i = 0; i < MaxBulletCount; i++)
        {
            var tempBullet = Instantiate(bulletPrefab);
            tempBullet.SetActive(false);
            tempBullet.transform.SetParent(transform);
            bulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject getBullet(Vector2 v)
    {
        var tempBullet = bulletPool.Dequeue();
        tempBullet.transform.position = v;
        tempBullet.SetActive(true);

        return tempBullet;
    }

    public void ReturnBullet(GameObject ReturnedBullet)
    {
        ReturnedBullet.SetActive(false);
        bulletPool.Enqueue(ReturnedBullet);
    }
}
