using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour , IShoot
{
    public GameObject bullet;
    public float shootDelay;
    private float shootTime = 0;
    public void Execute()
    {
        if (Time.time < shootDelay + shootTime) return;
        shootTime = Time.time;
        var t = transform;
        var newBullet = Instantiate(bullet, t.position, t.rotation);
    }
}
