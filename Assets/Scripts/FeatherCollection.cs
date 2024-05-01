using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeatherCollection : MonoBehaviour
{
    private int featherCount = 0;
    public TextMeshProUGUI featherText;
    private AudioSource audioSource;
    public AudioClip featherSound;
    public AudioClip completeSound;
    public bool isComplete = false;
    public int feathersToCollect = 10;
    public TextMeshProUGUI uiText1;
    public TextMeshProUGUI uiText2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        featherText.text = "Feather: " + featherCount + "/" + feathersToCollect;
        uiText2.gameObject.SetActive(false);
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
            featherText.text = "Feather: " + featherCount + "/" + feathersToCollect;
            if (featherCount == feathersToCollect)
            {
                audioSource.PlayOneShot(completeSound);
                isComplete = true;
                uiText1.gameObject.SetActive(false);
                uiText2.gameObject.SetActive(true);
            }
            else
            {
                audioSource.PlayOneShot(featherSound);
            }
        }
    }
}
