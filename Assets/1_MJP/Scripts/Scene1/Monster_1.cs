using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster_1 : MonoBehaviour {
    public AudioClip monster_die;
    private bool isdead;

    private int monster_HP;
    NavMeshAgent m_nav;
    Animator m_animator;
    public GameObject m_Player;
    private float dis;
    AnimationClip ci;
    private BoxCollider m_boxCollider;
    Rigidbody rig;

    bool playerdie = false;
    public Sam sam;
    int width, maxHp, currHp;
    public Slider myHP;
	// Use this for initialization
	void Start () {
        monster_HP = 100;
        maxHp = 100;
        m_nav = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
        m_boxCollider = GetComponent<BoxCollider>();
        rig = GetComponent<Rigidbody>();
        sam = GameObject.Find("Cube").GetComponent<Sam>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 v = m_Player.transform.position - transform.position;
        v.Normalize();
        Quaternion q = Quaternion.LookRotation(v);
        myHP.transform.TransformDirection(v);
        myHP.transform.LookAt(m_Player.transform.position);

        dis = Vector3.Distance(m_Player.transform.position, transform.position);
        playerdie = sam.dead;
        if (!(monster_HP <= 0)&&!playerdie)
        {
            if (!(dis < 3f) && dis < 15f)
            {
                m_nav.SetDestination(m_Player.transform.position);
                m_animator.SetBool("running", true);
                m_animator.SetBool("attack", false);
            }
            else if (dis < 3f)
            {
                m_animator.SetBool("attack", true);
            }
            else if (dis > 15f)
            {
                m_animator.SetBool("running", false);
            }
        }
        else if (monster_HP <= 0)
        {
            m_animator.SetBool("running", false);
            m_animator.SetBool("attack", false);
            m_animator.SetBool("dead", true);
            m_nav.enabled = false;
            Destroy(this.gameObject, 5.0f);
            if (!isdead)
            {
                AudioSource.PlayClipAtPoint(monster_die, this.transform.position);
                isdead = true;
            }
        }
        
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            monster_HP -= (int)sam.damage;
            myHP.value-= (int)sam.damage;
        }
        if (collision.gameObject.tag == "Player"&&!playerdie)
        {
            rig.AddForce(Vector3.back * 2f, ForceMode.Impulse);
        }
        
    }
    
}
