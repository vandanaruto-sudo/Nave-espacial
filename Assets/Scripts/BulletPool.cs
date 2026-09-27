using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    private int poolSize = 10;

    private List<GameObject> bulletList = new List<GameObject>();

    private static BulletPool instance;
    public static BulletPool Instance {get {return instance;} }

    private void Awake()
    {
        if (instance == null){
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        AddBulletToPool(poolSize);
    }

    private void AddBulletToPool (int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletList.Add(bullet);
            bullet.transform.parent = transform;
        }
        
    }

    public GameObject RequestBullet()
    {
        for(int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeSelf)
            {
                bulletList[i].SetActive(true);
                return bulletList[i];
            }
        }
        AddBulletToPool(1);
        bulletList[bulletList.Count - 1].SetActive(true);
        return bulletList[bulletList.Count - 1];
    }

}
