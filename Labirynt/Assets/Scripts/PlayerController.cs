using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 12f;
    public float gravity = -10;
    Vector3 velocity;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
    
        Vector3 movement = transform.right * x + transform.forward * z + Vector3.up * gravity;
        controller.Move(
            new Vector3(movement.x * speed * Time.deltaTime,
            movement.y * Time.deltaTime,
            movement.z * speed * Time.deltaTime));



    }
}
