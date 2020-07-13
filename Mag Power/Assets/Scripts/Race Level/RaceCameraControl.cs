using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCameraControl : MonoBehaviour
{
    public GameObject ship2;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
       offset = transform.position - ship2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ship2.transform.position + offset;
    }
}
