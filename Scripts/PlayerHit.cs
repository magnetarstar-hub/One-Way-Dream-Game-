using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider != null)
        {
            if(collider.CompareTag("breakable"))
            {
                try
                {
                    collider.GetComponent<Pot>().Smash();
                }
                catch(Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
    }
}