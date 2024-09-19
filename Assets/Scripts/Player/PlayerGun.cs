using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerGun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool AddBulletSpread = true;
    [SerializeField] private Vector3 BulletSpread = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private ParticleSystem ShootingSystem;
    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private ParticleSystem ImpactParticle;

    [SerializeField] private TrailRenderer BulletTrail;

    [SerializeField] private float shootDelay = 0.4f;
    [SerializeField] private LayerMask layerMask;
    private Animator animator;
    private float lastShootTime = 0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Shoot(){
        if (lastShootTime + shootDelay < Time.time){
            animator.SetBool("IsShooting", true);
            ShootingSystem.Play();
            Vector3 direction = GetDirection();

            if (Physics.Raycast(BulletSpawn.position, direction, out RaycastHit hitInfo, float.MaxValue, layerMask)){
                TrailRenderer trail = Instantiate(BulletTrail, BulletSpawn.position, Quaternion.identity);

                StartCoroutine(SpawnTrail(trail, hitInfo));
                lastShootTime = Time.time;
            }
        }
    }

    private Vector3 GetDirection(){
        Vector3 direction = transform.forward;
        if (AddBulletSpread){
            direction.x += Random.Range(-BulletSpread.x, BulletSpread.x);
            direction.y += Random.Range(-BulletSpread.y, BulletSpread.y);
            direction.z += Random.Range(-BulletSpread.z, BulletSpread.z);
            direction.Normalize();
        }

        return direction;
    }

    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hitInfo){
        float time = 0f;
        Vector3 startPos = trail.transform.position;
        while (time < 1f){
            trail.transform.position = Vector3.Lerp(startPos, hitInfo.point, time);
            time += Time.deltaTime;
            yield return null;
        }
        animator.SetBool("IsShooting", false);
        trail.transform.position = hitInfo.point;
        Instantiate(ImpactParticle, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(trail.gameObject, trail.time);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
