using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    private GameObject mainCam;
    private GameObject subCam;
    public GameObject player;
    private FeatherCollection featherScript;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.Find("Main Camera");
        subCam = GameObject.Find("Sub Camera");
        featherScript = featherScript = player.GetComponent<FeatherCollection>();
        subCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(featherScript.isComplete)
        {
            mainCam.SetActive(false);
            subCam.SetActive(true);
        }
    }
}
