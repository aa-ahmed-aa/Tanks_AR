using UnityEngine;
using System.Collections;

public class shoot_script : MonoBehaviour {

    public Rigidbody projectile;
    public float speed = 50;
    public Transform parentObject;
    public GameObject root_parent;

    //Update is called once per frame
    void Start()
    {    
        //turn off collisions between the object and the player 
         InvokeRepeating("LaunchProjectile", 1.0f, 2.0f);
    }

    //Update function
    void Update()
    {
        if(root_parent.GetComponent<MeshRenderer>().enabled == true)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("projectile");
            for( int i = 0; i< objects.Length; i++)
            {
                objects[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }else
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("projectile");
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
    void LaunchProjectile()
    {
        Rigidbody instance_of_projectile = Instantiate(projectile,
                                                            transform.position,
                                                            transform.rotation) as Rigidbody;
        //set the tag to can select later
        instance_of_projectile.tag = "projectile";
        //make the object move
        instance_of_projectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        instance_of_projectile.transform.parent = parentObject;
    }
}
