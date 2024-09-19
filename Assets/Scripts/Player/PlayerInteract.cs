using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    [SerializeField]
    private float distance = 1000f;
    [SerializeField] private LayerMask layerMask;
    //[SerializeField] private PlayerGun Gun; 
    [SerializeField] private ParticleSystem muzzleFlash;
    void Start()
    {
        // get camera in MainCamera object
        // the came in object name MainCamera
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        muzzleFlash = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        muzzleFlash.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // if get mouse click
        if (Input.GetMouseButtonDown(0))
        {
            OnShoot();
        }
        
    }

    private void OnShoot(){
        muzzleFlash.Play();
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, layerMask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                hitInfo.collider.GetComponent<Interactable>().Interact();

            }
        }
    }
}
