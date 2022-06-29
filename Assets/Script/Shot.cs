using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private AudioSource au;
    public GameObject dagger;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        au = GetComponent<AudioSource>();
    }

    void Rotation()
    {
        Vector3 worlPos = Input.mousePosition; // worlPos - координаты мира. mousePosition - координаты нашей мыши
        worlPos = Camera.main.ScreenToWorldPoint(worlPos);
        float dx = this.transform.position.x - worlPos.x; // координаты нашей мыши 
        float dy = this.transform.position.y - worlPos.y;
        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg; // угл по которому будут посылаться снаряды или волны .  Rad2Deg - радианы в градусы 
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        this.transform.rotation = rot;
    }

    void ShotDagger()
    {
        float posX = this.transform.position.x + (Mathf.Cos((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -distance);
        float posY = this.transform.position.y + (Mathf.Sin((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -distance);
        Instantiate(dagger, new Vector3(posX, posY, 0), this.transform.rotation);
        au.Play();
    }


    // Update is called once per frame
    void Update()
    {
        Rotation();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShotDagger();
                au.Play();
        }
    }
}
