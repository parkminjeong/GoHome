using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear_1 : MonoBehaviour {
    private Collider m_col;
    public GameObject m_manager;
	// Use this for initialization
	void Start () {
        m_col = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            m_manager.SendMessage("SetTextLine", 1);
            Application.LoadLevel("Page2");
        }
    }
}
