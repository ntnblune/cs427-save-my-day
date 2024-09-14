using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCam : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float smoothSpeed = 4f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Quaternion camTurnAngleX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion camTurnAngleY = Quaternion.AngleAxis(mouseX, Vector3.up);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, camTurnAngleX * camTurnAngleY, smoothSpeed);
    }
}
