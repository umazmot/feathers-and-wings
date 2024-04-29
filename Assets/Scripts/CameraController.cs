using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float sensitivity = 50.0f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void  LateUpdate()
    {
        transform.Translate(Vector3.up * Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime);

        transform.LookAt(player.transform);
    }
}
