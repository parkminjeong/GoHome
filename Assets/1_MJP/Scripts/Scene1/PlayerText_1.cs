using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerText_1 : MonoBehaviour {
    public GameObject m_firstzone,m_secondzone, m_thirdtzone;
    int num;
    Collider col;
    public GameObject m_manager;
    Sam sam;
    //bool getKey;
	// Use this for initialization
	void Start () {
        col = GetComponent<Collider>();

        sam = GetComponent<Sam>();
	}
	
	// Update is called once per frame
	void Update () {
       // getKey = sam.getkey;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == m_firstzone)
        {
            m_manager.SendMessage("SetTextLine", 1);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject == m_secondzone)
        {
            m_manager.SendMessage("SetTextLine", 1);
            collision.gameObject.SetActive(false);
            m_thirdtzone.SetActive(true);
        }
        else if (collision.gameObject == m_thirdtzone)
        {
            m_manager.SendMessage("SetTextLine", 1);
            collision.gameObject.SetActive(false);
        }
    }
}
