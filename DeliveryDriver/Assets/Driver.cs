using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f; //u can remove the 'f' if u want
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")*steerSpeed*Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;

        transform.Rotate(0,0,-steerAmount); //type of floats, have to add 'f'
        transform.Translate(0,moveAmount,0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost"){
            moveSpeed = boostSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        moveSpeed = slowSpeed;
    }
}
