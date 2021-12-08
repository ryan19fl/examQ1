using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
    public float speed;
    public CharacterController controler;
    public float jumpescale;
    public Vector3 velocity;
    public float gravity;
    public Transform groundcheck;
    public LayerMask groundmask;
    public float sphereradius;
    bool isgrounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundcheck.position, sphereradius, groundmask);
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controler.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpescale * -1f * gravity);

        }
        velocity.y += gravity * Time.deltaTime;
        controler.Move(velocity * Time.deltaTime);
    }
}
