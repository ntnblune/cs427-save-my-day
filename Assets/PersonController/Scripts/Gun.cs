using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public float dame = 10f;
    public float range = 100f;
    public int currentAmmo = 500;
    public int maxAmmo = 500;

    public float fireRate = 120f;
    public float reloadTime = 1f;
    private bool isReloading = false;
    private float timeSinceLastFire = 0f;
    private Transform muzzle;
    private Transform player;
    void Awake()
    {
        // audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }
    void Start()
    {
        PlayerShoot.inputShoot += Shoot; 
        PlayerShoot.inputReload += Reload;
        muzzle = transform.Find("Muzzle");  
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // rotate trans
        Debug.DrawRay(muzzle.position, player.forward , Color.green);
        timeSinceLastFire += Time.deltaTime;
        if (isReloading){
            if (timeSinceLastFire >= reloadTime){
                isReloading = false;
                currentAmmo = maxAmmo;
            }
        }
    }
    private bool canShoot(){
        return !isReloading && timeSinceLastFire >= 1f/(fireRate/30);
    }
    void Shoot()
    {
        if (currentAmmo > 0){
            if (canShoot()){
                // audioMananger.PlayShooting();
                currentAmmo--;
                RaycastHit hit;
            
                if (Physics.Raycast(muzzle.position, player.forward, out hit, range))
                {
                    Debug.Log(hit.transform.name);
                    IDameable dameable = hit.transform.GetComponent<IDameable>();
                    if (dameable != null){
                        dameable.TakeDame(dame);
                    }
                }
                currentAmmo--;
                timeSinceLastFire = 0f;
            }
        }
        else {
        }
        // RaycastHit hit;
        // if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        // {
        //     Debug.Log(hit.transform.name);
        // }
    }

    void Reload()
    {
        if (currentAmmo < maxAmmo){
            Debug.Log("Reload");
            isReloading = true;
        }
    }
}
