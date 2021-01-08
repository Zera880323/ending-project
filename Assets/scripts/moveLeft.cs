using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    public float speed = 10;
    public playerController playercs;
    // Start is called before the first frame update
    void Start()
    {
        playercs = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercs.gameover == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (transform.position.x < -10 && gameObject.CompareTag("ob"))
            {
                Destroy(gameObject);
            }
        }
    }
}
