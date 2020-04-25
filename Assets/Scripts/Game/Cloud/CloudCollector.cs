using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Cloud"|| other.gameObject.tag == "Deadly")
        {
            print("xdd");
            other.gameObject.SetActive(false);
        }
    }
}
