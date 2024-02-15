using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    //Gun stats
    public float timeBetweenShooting, spread, reloadTime;
    public float shootForce;
    public int magazineSize;
    public bool allowButtonHold;
    public int bulletsLeft;

    //bools 
    public bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public GameObject bullet;

    public void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    public void Update()
    {
        MyInput();
    }
    public virtual void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0); 
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
            

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            Shoot();
        }
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }
    }
    public virtual void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = direction.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
        bulletsLeft--;

        Invoke("ResetShot", timeBetweenShooting);
      
    }
    public void ResetShot()
    {
        readyToShoot = true;
    }
    public void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    public void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
