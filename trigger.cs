using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject keytrigger;
    public GameObject doortrigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject== keytrigger)
        {
         // Debug.Log("hit detected");
            Destroy(keytrigger.gameObject);
            keytrigger.gameObject.SetActive(false);
            Sphere.Keytaken(true);

        }
        if (other.gameObject == doortrigger)
        {
            if (Sphere.getkeytake() == true)
            {
              //Debug.Log("hit detected");
                Sphere.doorTrigger(true);
            }
        }



    }
}