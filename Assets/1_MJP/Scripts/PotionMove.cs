using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMove : MonoBehaviour {
    Vector3 first;
    Vector3 upVec;
    private bool change;
	// Use this for initialization
	void Start () {
        first = transform.position;
        upVec = first + new Vector3(0, 0.6f, 0);
        change = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (!change) {
            transform.position = Vector3.Lerp(transform.position, upVec, Time.deltaTime / 1.5f);
        }else if (change) { 
            transform.position = Vector3.Lerp(transform.position, first, Time.deltaTime / 1.5f);
         
        }
        float dis = Vector3.Distance(transform.position, upVec);
        float downdis = Vector3.Distance(transform.position, first);
        if (dis<0.2f&&!change)
        {
            change = true;
        }
        else if(downdis<0.2f&&change)
            change = false;
    }
}
