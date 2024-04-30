using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 30.0f;
    private float rotationSpeed = 100.0f;
    private float verticalInput;
    private float horizontalInput;
    public TextMeshProUGUI heightText;
    private float fallSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
        if (transform.position.y <= fallSpeed)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        else
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
        heightText.text = "Height: " + (int)transform.position.y;
    }


}
