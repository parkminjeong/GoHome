using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Iden : MonoBehaviour {
    // Use this for initialization
	void Start () {
        Quaternion q = new Quaternion(0, 95f, 90f, 0);
        transform.rotation = q;
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        
        if (collision.gameObject.tag == "attackabledoor")
        {
            Rigidbody colrig = collision.gameObject.GetComponent<Rigidbody>();
            colrig.constraints = RigidbodyConstraints.None;
            //| RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            colrig.AddForce(Vector3.forward * 150f, ForceMode.Impulse);
            colrig.AddForce(Vector3.up * 150f, ForceMode.Impulse);

            Destroy(collision.gameObject,1f);
        }
    }
}
