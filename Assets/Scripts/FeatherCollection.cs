using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeatherCollection : MonoBehaviour
{
    private int featherCount = 0;

    public TextMeshProUGUI featherText;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
