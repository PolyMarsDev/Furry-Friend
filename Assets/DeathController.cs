using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] Animator catAnim;
    [SerializeField] Cat cat;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")    
        {
            catAnim.SetTrigger("Crawl");
            cat.activateChase();
        }
    }
}
