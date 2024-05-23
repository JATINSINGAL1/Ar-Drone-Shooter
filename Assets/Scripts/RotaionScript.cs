using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaionScript : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Adjust the rotation speed as desired

    private void Update()
    {
        // Rotate the object around the pivot point
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
