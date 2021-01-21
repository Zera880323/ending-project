using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcontroller : MonoBehaviour
{
    public int speed = 20;
    public float turnspeed = 30f;
    public float horizontalInput;
    public float verticalInput;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // transform.Translate(Vector3.right*Time.deltaTime*turnspeed*horizontalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnspeed * horizontalInput);

        //transform.rotation.Set(0f, transform.rotation.y, 0f, 0f);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(projectilePrefab, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
        }
    }
}

