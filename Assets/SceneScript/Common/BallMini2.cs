﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMini2 : MonoBehaviour {
    private float speed = 1500.0f;

    public static Rigidbody Egg;

    public float moveForceMultiplier;

    private Vector3 firstVelocity;
    public AudioClip sound1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start () {

        int value = Random.Range (3, 6 + 1);

        firstVelocity = new Vector3 (value, 0, value);

        this.GetComponent<Rigidbody> ().AddForce (firstVelocity * speed);
        audioSource = GetComponent<AudioSource> ();
        Egg = this.GetComponent<Rigidbody> ();
    }

    void OnCollisionEnter (Collision collisionInfo) {
        audioSource.PlayOneShot (sound1);
        this.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody> ().velocity.normalized * 25;

        if (this.GetComponent<Rigidbody> ().position.x >= 4.6 && collisionInfo.gameObject.CompareTag ("Block")) {
            this.GetComponent<Rigidbody> ().velocity = new Vector3 (-5f, 0f, -5f);

        }
        if (this.GetComponent<Rigidbody> ().position.x <= -4.6 && collisionInfo.gameObject.CompareTag ("Block")) {
            this.GetComponent<Rigidbody> ().velocity = new Vector3 (5f, 0f, 5f);

        }

        if (collisionInfo.gameObject.CompareTag ("GameClearBar")) {
            Common.BallFlag = true;
        }

        if (collisionInfo.gameObject.CompareTag ("GameOverBar")) {
            Common.BallFlag = true;
        }

    }

    // Update is called once per frame
    void Update () {
        if (Common.BallFlag == true) {
            this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
        }

    }
}