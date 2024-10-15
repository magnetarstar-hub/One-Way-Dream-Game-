using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour {

    //public Vector2 cameraChange;
    public Vector2 cameraMinChange;
    public Vector2 cameraMaxChange;
    public Vector3 playerChange;
    private CameraMovement cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main.GetComponent<CameraMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CameraMovement cam = Camera.main.GetComponent<CameraMovement>();
            cam.minPosition += cameraMinChange;
            cam.maxPosition += cameraMaxChange;
            other.transform.position += new Vector3(playerChange.x,
                                                     playerChange.y,
                                                    0);
            
        }
    }
}