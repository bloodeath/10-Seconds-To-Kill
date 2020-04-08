using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    Camera cam;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();    
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = player.transform.position + new Vector3(0, 4, -12);
    }
}
