using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] turretBarrels;
    public Collider2D[] tankColliders;
    public float reloadDelay = 0.5f;

    private bool canShoot = true;
    private float currentDelay;

    private void Update()
    {
        if (!canShoot)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0f)
            {
                canShoot = true;
            }
        }

        // Check for mouse button press (left mouse button)
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    private void Start()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
    }
    public void Shoot()
    {
        if (canShoot)
        {
            Debug.Log("can shoot");
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                if (bulletScript != null)
                {
                    Debug.Log("shoot inside");
                    bulletScript.Initialize(barrel.up);
                }

                foreach (var collider in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }
        }
    }
}
