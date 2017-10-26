using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracon : MonoBehaviour {
    public GameObject m_Player;
    Vector3 vec;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.up * Time.deltaTime * 150.0f * Input.GetAxis("Mouse X"));
        float rotY = Input.GetAxis("Mouse X");
        float rotX = Input.GetAxis("Mouse Y");

        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0f);

        transform.position = Vector3.Lerp(transform.position, m_Player.transform.position,Time.deltaTime*20f);
        if ((300f < transform.eulerAngles.x && transform.eulerAngles.x <= 360) ||
                (0f <= transform.eulerAngles.x && transform.eulerAngles.x < 40f))
        {

            transform.localRotation *= Quaternion.Euler(-rotX, 0, 0f);

           // transform.Rotate(-Vector3.right * Time.deltaTime * 150f * Input.GetAxis("Mouse Y"));
            // m__gun1.transform.Rotate(-Time.deltaTime * 150f * Input.GetAxis("Mouse Y"), 0, 0);
            // m__gun1.transform.Rotate(0, 0, Time.deltaTime * 150.0f * Input.GetAxis("Mouse Y"));
            /*if (m__gun2.name.Equals("M4arm"))
            {
                m__gun2.transform.Rotate(-Time.deltaTime * 120f * Input.GetAxis("Mouse Y"), 0, 0);
            }
            else
            {
                m__gun2.transform.Rotate(Time.deltaTime * 150.0f * Input.GetAxis("Mouse Y"), 0, 0);
            }*/

        }
        else if (280f < transform.eulerAngles.x && transform.eulerAngles.x < 300f)
        {
            Vector3 v = new Vector3(-Input.GetAxis("Mouse Y") + 1.5f, transform.rotation.y, transform.rotation.z);
            transform.Rotate(v);
        }
        else if (40f < transform.eulerAngles.x && transform.eulerAngles.x < 50f)
        {
            Vector3 v = new Vector3(-Input.GetAxis("Mouse Y") - 1.5f, transform.rotation.y, transform.rotation.z);
            transform.Rotate(v);
        }
        else if (50f < transform.eulerAngles.x && transform.eulerAngles.x < 80f)
        {
            Vector3 v = new Vector3(-Input.GetAxis("Mouse Y") - 20f, transform.rotation.y, transform.rotation.z);
            transform.Rotate(v);
        }
        else if (250f < transform.eulerAngles.x && transform.eulerAngles.x <= 280f)
        {
            Vector3 v = new Vector3(-Input.GetAxis("Mouse Y") + 20f, transform.rotation.y, transform.rotation.z);
            transform.Rotate(v);
        }
        else if (transform.eulerAngles.x < 0f)
        {
            Vector3 v = new Vector3(-Input.GetAxis("Mouse Y") + 0.5f, transform.rotation.y, transform.rotation.z);
            transform.Rotate(v);
        }
    }
}
