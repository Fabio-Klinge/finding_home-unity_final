using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototyp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // START POSITION 
        transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
         PlayerMovement();
    }


    void PlayerMovement()
    {
        // MOVEMENT
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);

        // JUMPING
        if (Input.GetKeyDown("space") && _nextJumpTime < Time.time)
        {
            RB.velocity += new Vector3(0f, _jumpingSpeed, 0f);
            _nextJumpTime = Time.time + _coolDownTime;
        }

        // TELEPORT - if player is falling teleport him back to a certain position
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0f, 2f, 0f);
        }

    }
}
