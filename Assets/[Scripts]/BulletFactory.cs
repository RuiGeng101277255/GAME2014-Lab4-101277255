using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject EnemyBullet;
    public GameObject PlayerBullet;

    public GameObject createBullet(BulletType type)
    {
        GameObject tempBullet = null;
        switch(type)
        {
            case BulletType.ENEMY:
                tempBullet = Instantiate(EnemyBullet);
                break;
            case BulletType.PLAYER:
                tempBullet = Instantiate(PlayerBullet);
                break;
        }

        tempBullet.transform.SetParent(transform);
        tempBullet.SetActive(false);

        return tempBullet;
    }
}
