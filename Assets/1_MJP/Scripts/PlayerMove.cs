using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {
    public bool dead;
    float px, pz;
    public Sam sam;
	// Use this for initialization
	void Start () {
        Scene sc = SceneManager.GetActiveScene();


        if (sc.name.Equals("Page3")|| sc.name.Equals("Page2"))
        {
            sam = GameObject.Find("Capsule").GetComponent<Sam>();
        }else
            sam = GameObject.Find("Cube").GetComponent<Sam>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            px = Input.GetAxis("Horizontal");
            pz = Input.GetAxis("Vertical");

            Vector3 MoveDir = Vector3.forward * pz + Vector3.right * px;
            transform.Translate(MoveDir.normalized * Time.deltaTime * 7f);

           // transform.Rotate(Vector3.up * Time.deltaTime * 5000f * Input.GetAxis("Mouse X"));
          
        }
        dead = sam.dead;

    }
}
