using UnityEngine;
using System.Collections;

public class destroy_bullet : MonoBehaviour {

    public float lifetime=0.1f;

    void Awake()
    {
        Destroy(this.gameObject, lifetime);
    }
}
