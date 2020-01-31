using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    //variables
    public float moveSpeed = 1500;
    public GameObject sphere;
    public float jumpforce = 100f;
    public GameObject keyAppears;
    public GameObject key;
    public GameObject doorAppears;

    SpriteRenderer rend;

    private Rigidbody2D sphereBody;
    private Rigidbody2D keybody;
    private Rigidbody2D keyAppBody;


    private float ScreenWidth;
    private float widthRel;

    private static bool keyTaken = false;
    private static bool doortriggered = false;

    void Start()
    {
        ScreenWidth = Screen.width;
        widthRel = sphere.transform.localScale.x / ScreenWidth;
        sphereBody = sphere.GetComponent<Rigidbody2D>();

        rend = key.GetComponent<SpriteRenderer>();

        keybody = key.GetComponent<Rigidbody2D>();

        keyAppBody = keyAppears.GetComponent<Rigidbody2D>();

        keyAppears.GetComponent<Renderer>().enabled = false;

        doorAppears.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
#if UNITY_EDITOR
        RunCharacter(Input.GetAxis("Horizontal"));
        jumpCharacter(Input.GetKeyDown(KeyCode.Space));
#endif

        Vector3 viewPos = Camera.main.WorldToViewportPoint(sphere.transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, widthRel, 1 - widthRel);
        sphere.transform.position = Camera.main.ViewportToWorldPoint(viewPos);


        if (keyTaken)
        {


            keyAppears.GetComponent<Renderer>().enabled = true;
        }
        if (keyTaken)
        {

            if (doortriggered)
            {
                doorAppears.GetComponent<Renderer>().enabled = false;
                sphereBody.GetComponent<Renderer>().enabled = false;
            }
        }
    }

    private void RunCharacter(float horizontalInput)
    {
        //move ball
        sphereBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));

    }
    private void jumpCharacter(bool verticalInput)
    {
        //jump ball
        if (verticalInput)
        {
            sphereBody.AddForce(new Vector2(0, 50 * jumpforce * Time.deltaTime));
        }

    }
    public static void Keytaken(bool value)
    {
        if (value)
        {
            keyTaken = true;

           // Debug.Log("key");
        }
    }

    public static bool getkeytake() { return keyTaken; }

    public static void doorTrigger(bool value)
    {

        if (value)
        {
            doortriggered = true;

        }

    }

}