using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {
    
    public List<GameObject> inPan = new List<GameObject>();
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name!="salt(Clone)" && other.name!= "bottleOfWater(Clone)")
        inPan.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        inPan.Remove(other.gameObject);
    }
}
