using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear_2 : MonoBehaviour {
    private Collider m_col;
    public Text m_text1,m_text2;
    public GameObject m_Player;
    private Rigidbody pl_rig;
    public TextCtrl_1 tex;
    bool up;
    float timer;
    private int l = 1;
    // Use this for initialization
    void Start()
    {
        tex =GameObject.Find("GameManager").GetComponent<TextCtrl_1>();
        m_col = GetComponent<Collider>();
        m_text1.text =" ";
        pl_rig = m_Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(m_text1.text.Equals(" "))&&Input.GetKeyDown(KeyCode.E))
        {
            up = true;

        }
        if (up)
        {
            timer += Time.deltaTime;
            pl_rig.useGravity = false;
            m_Player.transform.position += Vector3.up/18;
            tex.SetTextLine(l);
            l = 0;
            if (timer>1.2f)
            {
                Application.LoadLevel("Page3");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_text2.text = "[E] Click";
        }
    }
}
