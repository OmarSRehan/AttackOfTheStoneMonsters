﻿using UnityEngine;

public class BulletController : MonoBehaviour {
    // My components
    public Rigidbody _rigidbody;

    // Members
    public float thrust = 4.0f;
    public float lifeTime = 4.0f;

    void Start() {
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate() {
        _rigidbody.AddForce(transform.up * thrust);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Floor") {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            PlayerManager.score += 2;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
