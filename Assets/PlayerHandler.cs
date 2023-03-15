using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameObject player;
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.parent = transform;
        }
    }
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.parent = null;
        }
    }
}
