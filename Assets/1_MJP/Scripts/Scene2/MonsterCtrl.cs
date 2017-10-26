using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour {
    Animation anim;
    Collider col;
    NavMeshAgent nav;
    Manager_2 ma;
    TextCtrl_1 tex;
    public GameObject m_Manager;
    int monHp;
    bool getSomething;
    Vector3 fir_posi;
    string state;
    string name;
    public GameObject m_Player;
    float dis;
    bool OnlyUndead;
    bool start;
    float timer;
    private int l = 1;

    public AudioClip monDie;
    // Use this for initialization
    void Start()
    {
        tex = m_Manager.GetComponent<TextCtrl_1>();
        ma = m_Manager.GetComponent<Manager_2>();
        anim = GetComponent<Animation>();
        col = GetComponent<Collider>();
        nav = GetComponent<NavMeshAgent>();
        state = "idle";
        fir_posi = this.transform.position;
        getSomething = false;
        GameObject myob = this.gameObject;
        name = myob.name;
        name = name.Substring(0, 5);
        OnlyUndead = false;
        start = false;
        monHp = 120;
        if (name.Equals("VAMPI"))
        {
            monHp = 180;
        }
    }


    // Update is called once per frame
    void Update () {
        dis = Vector3.Distance(m_Player.transform.position, this.transform.position);
        if (!getSomething)
        {
            nav.enabled = true;
            if (dis < 12f)
            {
                start = true;
                nav.SetDestination(m_Player.transform.position);

                switch (name)
                {
                    case "MUMMY":
                        state = "walkNormal";
                        if (dis < 4f)
                        {
                            state = "attack1";
                        }
                        break;
                    case "GHOUL":
                        state = "run";
                        if (dis < 2f)
                        {
                            state = "weaponAttack3";
                        }
                        break;
                    case "UNDEA":
                        state = "walkArmed";
                        if (dis < 4f)
                        {
                            state = "armedAttack_1";
                        }
                        break;
                    case "VAMPI":
                        state = "run";
                        if (dis < 4f)
                        {
                            state = "jumpAttack";
                        }
                        break;
                }
            }
            else
            {
                nav.SetDestination(fir_posi);
            }
            if (name.Equals("UNDEA") && start)
            {
                if (Vector3.Distance(transform.position, fir_posi) < 3f)
                {
                    state = "idleArmed";
                    OnlyUndead = false;
                }


            }
            else
            {
                if (Vector3.Distance(transform.position, fir_posi) < 1f)
                {
                    state = "idle";
                }
            }
            
        }
        else          //get==true
        {
            timer += Time.deltaTime;
            nav.enabled = false;
            if (timer > 0.3f)
            {
                timer = 0;
                getSomething = false;
            }
        }
       

        if (monHp <= 0)
        {
            if (name.Equals("GHOUL"))
            {
                state = "death2";
            }else if (name.Equals("UNDEA"))
            {
                state = "armedDeadFront";
            }
            else if(name.Equals("VAMPI"))
            {
                ma.isbossdead = true;
                tex.SetTextLine(l);
                l = 0;
                state = "death";
            }else
                state = "death";

            nav.enabled = false;
            col.enabled = false;
            Destroy(this.gameObject, 1.5f);
            getSomething = true;
            if (dieSound != true)
            {
                AudioSource.PlayClipAtPoint(monDie, this.transform.position);
                dieSound = true;
            }
        }

        foreach (AnimationState state in anim)
        {
            if (state.name == this.state)
            {
                anim.Play(state.name);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            state = "getHit";
            if (name.Equals("UNDEA"))
            {
                state = "armedGetHitHeavyFront";
            }else if (name.Equals("VAMPI"))
            {
                state = "getHitLight";
            }
            getSomething = true;

            Sam sam = GameObject.Find("Capsule").GetComponent<Sam>();
            monHp -= (int)sam.damage;
        }
    }
    private bool dieSound;
}
