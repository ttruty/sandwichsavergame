using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField]
    float mainThrust = 1000;
    [SerializeField]
    float rotationThrust = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A))
        {
            applyRotation(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D)) {
            applyRotation(Vector3.back);
        }
    }

    void applyRotation(Vector3 direction)
    {
        rb.freezeRotation = true; // freeze rotation to manually rotate
        transform.Rotate(direction * rotationThrust * Time.deltaTime);
        rb.freezeRotation = false; // unfreeze rotation so phys system takes over
    }
}
