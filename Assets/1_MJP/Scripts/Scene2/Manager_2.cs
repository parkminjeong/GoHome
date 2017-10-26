using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_2 : MonoBehaviour {
    public GameObject m_knight;
    public GameObject m_Player;
    public GameObject m_Ladder;
    public Text m_text;
    public bool isbossdead;
    private GameObject[] P_guns;


    Sam sam = new Sam();
	// Use this for initialization
	void Start () {
        isbossdead = false;

        m_Ladder.SetActive(false);

    }
   
    // Update is called once per frame
    void Update()
    {
        if (isbossdead)
        {
            m_Ladder.SetActive(true);
            
        }
        //getNames=getName();
        
    }
    private void FixedUpdate()
    {
        
    }
    public string[] getNames;
    
    public string[] getName(string[] names)
    {
        getNames= names;
        return names;
    }
}
