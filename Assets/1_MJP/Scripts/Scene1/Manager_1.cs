using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Manager_1 : MonoBehaviour {
    private string item;
    float time;
    public GameObject first_gate;
    private BoxCollider firstgate_col;
    private Rigidbody firstgate_rig;
    public GameObject AllofColl;
    private BoxCollider[] gate_child;
    public GameObject m_player;
    public GameObject m_gate1, m_gate2;
    public GameObject m_knight,m_fistzone;


    public Image[] gunImages;
    public Sprite[] gunSprites;

    bool knight;
    NavMeshAgent Knight_nav;
    private bool getkey;
    // private bool getkey;
    // Use this for initialization
    public Sam sam;
    void Start()
    {
        //getkey = false;
        knight = false;
        firstgate_col = first_gate.GetComponent<BoxCollider>();
        firstgate_rig = first_gate.GetComponent<Rigidbody>();
        firstgate_rig.useGravity = false;
        gate_child = AllofColl.GetComponentsInChildren<BoxCollider>(); getkey = false;
        Knight_nav = m_knight.GetComponent<NavMeshAgent>();
        Knight_nav.enabled = false;
        sam = GameObject.Find("Cube").GetComponent<Sam>();
    }
    // Update is called once per frame
    void Update()
    {
        getkey = sam.getkey;
        time += Time.deltaTime;
        if (time > 3.4f && first_gate != null)
        {
            firstgate_rig.useGravity = true;
        }
        if (time > 4.9f && first_gate != null && time <5.2f)
        {
            firstgate_col.enabled = true;
            firstgate_rig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            for (int i = 0; i < gate_child.Length; i++)
            {
                gate_child[i].enabled = false;
            }
        }
        if (getkey)
            if (first_gate != null)
            {
                Destroy(first_gate, 1f);
            }
            if ((2f > (Vector3.Distance(m_player.transform.position, m_gate1.transform.position))))
            {
                Destroy(m_gate1, 1.0f);
                getkey = false;
                Knight_nav.enabled = true;
                knight = true;
                sam.getkey = false;
            }
        if (Knight_nav.enabled == true)
        {

            float dis = Vector3.Distance(m_knight.transform.position, m_player.transform.position);
            if (dis > 4f)
            {
                Knight_nav.SetDestination(m_player.transform.position);
            }
            if (m_gate2 != null)
                if (1.6f > (Vector3.Distance(m_player.transform.position, m_gate2.transform.position)))
                {
                    Destroy(m_gate2, 1.0f);
                }
        }
    }
    private void FixedUpdate()
    {
   
        if (getNames.Length > 0)
        {
            for (int i = 0; i < getNames.Length; i++)
            {
                getNames[i] = getNames[i].Substring(0, 3);
            }

        }

       // gunImage.GetComponent<Image>().sprite = gunSprites[0];
        switch (getNames[0])
        {
            case "Spa":
                gunImages[0].sprite = gunSprites[0];
                break;
            case "Sho":
                gunImages[0].sprite = gunSprites[3];
                break;
        }
        switch (getNames[1])
        {
            case "M4a":
                Debug.Log("M");
                gunImages[1].sprite = gunSprites[4];
                if (gunImages == null)
                {
                    Debug.Log("null");
                }

                break;
            case "Mas":
                gunImages[1].sprite = gunSprites[1];
                break;
        }
    }

    public string[] getNames;
    public string[] getName(string[] names)
    {
        getNames = names;
        return names;
    }
}
