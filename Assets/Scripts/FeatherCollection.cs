using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeatherCollection : MonoBehaviour
{
    public int featherCount = 0;
    public TextMeshProUGUI featherText;
    private AudioSource audioSource;
    public AudioClip featherSound;
    public AudioClip completeSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Feather")
        {
            Destroy(other.gameObject);
            featherCount++;
            featherText.text = "Feather: " + featherCount + "/10";
            if (featherCount == 10)
            {
                audioSource.PlayOneShot(completeSound);
            }
            else
            {
                audioSource.PlayOneShot(featherSound);
            }
        }
    }
}
