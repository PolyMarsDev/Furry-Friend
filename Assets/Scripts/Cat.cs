using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] GameObject jumpscare;
    bool chase;

    [SerializeField] float speed;
    void Update()
    {
        if (chase)
        {
            Vector3 lookPos = player.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = rotation;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Vector3.Distance (player.position, transform.position) < 2)
        {
            jumpscare.SetActive(true);
            Destroy(this.gameObject);
        }

    }
    public void activateChase()
    {
        chase = true;
    }


}
