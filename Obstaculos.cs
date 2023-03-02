using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class obstaculos : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 0, rapidez.speed * Time.deltaTime) ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "limite")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "limite")
        {
            Destroy(gameObject);
        }
    }
}