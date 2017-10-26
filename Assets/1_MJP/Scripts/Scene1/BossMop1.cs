using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossMop1 : MonoBehaviour {
    public AudioClip die;

    public GameObject m_player, m_item, m_ClearGate, m_gate2;
    NavMeshAgent nav;
    Animator m_animator;
    Rigidbody rig;
    BoxCollider m_col;
    public Sam sam;
    public int hp = 150;
    bool isdead = false;
    bool plyerdie = false;
    bool getKey = false;
    public Slider myHP;
    public GameObject ma;
    bool chat = true;
    // Use this for initialization
    void Start () {
        nav = GetComponentInChildren<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        m_col= GetComponentInChildren<BoxCollider>();
        sam = GameObject.Find("Cube").GetComponent<Sam>();
    }

    // Update is called once per frame
    void Update () {
        Vector3 v = m_player.transform.position - transform.position;
        v.Normalize();
        Quaternion q = Quaternion.LookRotation(v);
        myHP.transform.TransformDirection(v);
        myHP.transform.LookAt(m_player.transform.position);

        plyerdie = sam.dead;
        getKey = sam.getkey;

        float dis = Vector3.Distance(transform.position, m_player.transform.position);
        if (dis < 4.0f)
        {
            m_animator.SetBool("attack", true);
        }
        else if (4f < dis && dis < 15f)
        {
            if (!plyerdie&&m_gate2==null&&hp>0)
            {
                nav.SetDestination(m_player.transform.position);
                m_animator.SetBool("running", true);
                if (chat)
                {
                    ma.SendMessage("SetTextLine",1);
                    chat= false;
                }
            }
        }
        else
        {
            m_animator.SetBool("running", false);
        }
        if (hp <= 0)
        {
            m_animator.SetBool("attack", false);
            m_animator.SetBool("running", false);
            m_animator.SetBool("die", true);
            nav.enabled = false;
            if(!isdead)
            Instantiate(m_item, transform.position, Quaternion.identity);
            isdead = true;
            Destroy(this.gameObject, 1.5f);
            m_ClearGate.SetActive(true);
            if (!chat)
            {
                AudioSource.PlayClipAtPoint(die, this.transform.position);
                ma.SendMessage("SetTextLine", 1);
                chat = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -=(int)sam.damage;
        }
    }
}
