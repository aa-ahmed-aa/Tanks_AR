using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class player_controller : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 pos;
    public Text panel_text;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = transform.position;
        panel_text.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        //transform.position += new Vector3(0,0,y/10);
        //transform.position += new Vector3(x/10,0,0);

        Vector3 movement = new Vector3(x, 0.0f, y);

        //enter trumps speed here!!!
        rb.velocity = movement * 4f;

        if (x != 0 && y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

       
    }

    public void reset_tank_position()
    {
        transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile" || collision.gameObject.tag == "enemy")
        {
            panel_text.GetComponent<Text>().text = "You Lost";
            System.Threading.Thread.Sleep(1500);
            Application.LoadLevel(Application.loadedLevelName);
        }

        else if (collision.gameObject.tag == "Finish")
        {
            panel_text.GetComponent<Text>().text = "You Win";
            System.Threading.Thread.Sleep(5000);
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}