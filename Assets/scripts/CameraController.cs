using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float bounds_X_Max;
    public float bounds_X_Min;
    public float bounds_Y_Max;
    public float bouds_Y_Min;

    private Vector3 offset;

    void Start () 
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate () 
    {
        transform.position = player.transform.position + offset;
        transform.position = new Vector3 (Mathf.Clamp (transform.position.x, bounds_X_Min, bounds_X_Max), Mathf.Clamp (transform.position.y, bounds_X_Min, bounds_Y_Max), transform.position.z);
    }
}

