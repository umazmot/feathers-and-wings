using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 30.0f;
    private float rotationSpeed = 200.0f;
    private float verticalInput;
    private float horizontalInput;
    public TextMeshProUGUI heightText;
    private float fallSpeed = 5.0f;
    private FeatherCollection featherScript;
    private bool onGround = false;
    public TextMeshProUGUI gameoverText;

    // Start is called before the first frame update
    void Start()
    {
        featherScript = GetComponent<FeatherCollection>();
        gameoverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 入力X成分
        horizontalInput = Input.GetAxis("Horizontal");
        // 入力Z成分
        verticalInput = Input.GetAxis("Vertical");

        if (featherScript.isComplete)
        {
            // 上に移動
            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                onGround = false;
            }
            // 下に移動
            else if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.DownArrow))
            {
                if(!onGround)
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                }
            }
            // 横に移動
            else
            {
                // 移動ベクトル
                Vector3 dir = new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
                // 移動
                transform.position += dir;
                // 方向転換
                transform.forward = Vector3.Slerp(transform.forward, dir, speed * Time.deltaTime);
            }
        }
        else
        {
            // 前進
            transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
            // 方向転換
            transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
            // 落下
            if (!onGround)
            {
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            }
        }
        heightText.text = "Height: " + (int)transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ground")
        {
            onGround = true;
            if(!featherScript.isComplete)
            {
                gameoverText.gameObject.SetActive(true);
            }
        }
    }
}
