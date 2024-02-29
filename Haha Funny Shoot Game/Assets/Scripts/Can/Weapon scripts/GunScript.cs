using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("Gun stats")]
    public float timeBetweenShooting;
    public float spread;
    public float zoomedSpread;
    public float reloadTime;
    public float shootForce;
    public int magazineSize;
    public bool allowButtonHold;
    public int bulletsLeft;

    [Header("Camera")]
    public float zoomedFOV;
    public float normalFOV;

    [Header("Bools")]
    public bool shooting;
    public bool readyToShoot;
    public bool reloading;
    public bool zoomed;

    [Header("References")]
    public Camera fpsCam;
    public Transform attackPoint;
    public GameObject bullet;
    public Transform zoomedPos;
    public Transform gunContainer;
    public Transform sprintPos;
    public BasicMovement sprinting;

    [Header("Other settings")]
    public float interpolationSpeed;
    private Coroutine reloadCoroutine;

    public void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    public void Update()
    {
        MyInput();
        Interpolation();
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

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading && !sprinting.sprinting && !zoomed)
        {
            Reload();
        }

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0 && !sprinting.sprinting)
        {
            Shoot();
        }
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0 && !sprinting.sprinting && !zoomed)
        {
            Reload();
        }
        if (zoomed || sprinting.sprinting)
        {

        }
    }
    public virtual void Shoot()
    {
        readyToShoot = false;
        float currentspread = zoomed ? zoomedSpread : spread;
        //Spread
        float x = Random.Range(-currentspread, currentspread);
        float y = Random.Range(-currentspread, currentspread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = direction.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);

        bulletsLeft--;

        GetComponent<GunRecoil>().Shoot();
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
    private void Interpolation()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            zoomed = true;
            sprinting.sprinting = false;
        }
        else
        {
            zoomed = false;
        }

        Transform targetPoint = Input.GetKey(KeyCode.Mouse1) ? zoomedPos : sprinting.sprinting ? sprintPos : gunContainer;

        transform.position = Vector3.Lerp(transform.position, targetPoint.position, interpolationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetPoint.rotation, interpolationSpeed * Time.deltaTime);

        float targetFOV = zoomed ? zoomedFOV : normalFOV;
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetFOV, interpolationSpeed * Time.deltaTime);
    }
}
