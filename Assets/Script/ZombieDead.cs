using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieDead : MonoBehaviour {
	public AudioSource au; 
	public Animator anim; 
	private int i = 0; 
	private int j = 0;
	private int k = 0;
	public float tim = 0.6f;  
	public GameObject trup; 
	
	void Update () {
		
		if (j == 1) { 
			 
			if (k == 0)
			{   
				if (tim <= 0)
				{			
					Instantiate(trup, new Vector3(this.transform.position.x, this.transform.position.y, 0), this.transform.rotation);
					k++;
				}
                tim -= Time.deltaTime; 

			}
		}
	}
	void OnCollisionEnter2D(Collision2D collision)
	{ 
		if (collision.gameObject.name.Contains ("Sphere")){ 
				au.Play (); 
				anim.SetTrigger ("Dead"); 
			if (i == 0) { 
					i++; 
				j++; 
			}

            Destroy(this.gameObject, 1.1f); 
		}
	}
}
