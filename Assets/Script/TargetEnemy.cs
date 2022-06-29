using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = player.transform.position - this.transform.position;
        delta.Normalize();
        float move = speed * Time.deltaTime;
        this.transform.position = this.transform.position + (delta * move);

        if (Input.GetKeyDown(KeyCode.R)){
            Application.LoadLevel (Application.loadedLevel);
        }
    }
}
