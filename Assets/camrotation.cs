using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camrotation : MonoBehaviour
{
    public float mousesencitivity;
    public Transform player;
    float xrotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesencitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesencitivity * Time.deltaTime;
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xrotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }
}
