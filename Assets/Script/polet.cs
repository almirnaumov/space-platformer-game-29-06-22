using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polet : MonoBehaviour
{
    public float lifeTime = 2.0f;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime); // что исчезнет, через какое время исчезнет 

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * speed); //  метод Translate - просто заставляет лететь в каком либо направлении предмет  
    }
}
