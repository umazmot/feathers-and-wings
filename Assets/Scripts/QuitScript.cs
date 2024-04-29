using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() //THIS CHUNK IS DESIGNED TO COUNTDOWN TO AUTO QUIT
        {
         StartCoroutine(DelayLittle());
     }
      IEnumerator DelayLittle()
        {
            yield return new WaitForSeconds(300); //wait x Seconds before exe auto closes, by default 5, you can change it here
            Application.Quit();
        }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")) //Hit escape on the keyboard to quit out of exe instead of ALT + F4
        {
            Application.Quit();
        }
    }
}