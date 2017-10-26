using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Sam : MonoBehaviour
{
    public AudioClip gunShoot,gunReload,potionDrink,Player_die;
    private bool deadsound;

    float x, z;
    private Rigidbody rig, m_bulrig;
    public GameObject m_Bullet;
    private int bullet_count;
    private Vector3 point_position;
    private GameObject sam_bul;
    public GameObject m__gun1, m__gun2, m__gun3, manager;
    public Transform fire;
    public GameObject[] guns;
    private float PlayerHp;
    public bool getkey = false;
    bool getgun3;
    public bool dead;
    bool gun1;
    string item;
    public float damage;
    public string[] a_name;

    private bool undamaged;
    private float undamagedTime;
    public Text dieText;
    public Slider hpbar;
    // Use this for initialization
    void Start()
    {
        a_name = new string[3];
        PlayerHp = 100f;
        rig = GetComponent<Rigidbody>();
        bullet_count = 10;
        dieText.enabled = false;
        dead = false;
        gun1 = true;
        getgun3 = false;
        damage = 10f;
        numbers[0] = Resources.Load("/1_MJP/Images/Number/number_5_theme4") as Sprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        a_name[0] = m__gun1.gameObject.name;
        a_name[1] = m__gun2.gameObject.name;
        a_name[2] = m__gun3.name;
        ReturnName(a_name);
    }
    private bool quadCheck;
    private float quadTime;
    void Update()
    {
        if (!dead)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && !gun1)
            {
                m__gun2.SetActive(false);
                m__gun1.SetActive(true);
                gun1 = true;
                damage = Damage(1);
                if (getgun3)
                    m__gun3.SetActive(false);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && gun1)
            {
                m__gun1.SetActive(false);
                m__gun2.SetActive(true);
                if (getgun3)
                    m__gun3.SetActive(false);
                gun1 = false;
                damage = Damage(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && getgun3)
            {
                m__gun1.SetActive(false);
                m__gun2.SetActive(false);
                m__gun3.SetActive(true);
                gun1 = false;
                damage = Damage(0.5f);
            }
            if (item != null)
            {
                string itemreplaced = item.Replace("(Clone)", "");


                switch (itemreplaced)
                {
                    case "Revolver":
                        getgun3 = true;
                        break;
                    case "hp+":
                        AudioSource.PlayClipAtPoint(potionDrink, this.transform.position);

                        PlayerHp += 30f;
                        hpbar.value += 30f;

                        if (PlayerHp > 100f)
                            PlayerHp = 100f;
                        break;
                    case "Pistol":

                        m__gun3 = GameObject.Find(item);
                        break;
                    case "Shotgun01":
                        m__gun2 = GameObject.Find(item);
                        break;
                    case "M4":
                        Debug.Log("dd");
                        m__gun1.SetActive(false);
                        m__gun2.SetActive(false);
                        guns[1].SetActive(true);
                        m__gun2 = GameObject.Find("M4arm");
                        m__gun2.SetActive(true);
                        break;
                    case "Home":
                        manager.SendMessage("Home");
                        break;
                    case "NotHome":
                        manager.SendMessage("SetTextLine", 1);

                        break;
                }
                item = null;
            }

            // //Ray ray=m__camera.ScreenPointToRay(new Vector3(200, 200, 0));
            //  Ray rayy = Camera.main;
            //  Camera.S
            if (Input.GetKeyDown(KeyCode.R)||Input.GetMouseButtonDown(1)&&bullet_count!=10)
            {
                bullet_count = 10;
                AudioSource.PlayClipAtPoint(gunReload, this.transform.position);
            }
            if (bullet_count != 0)
            {
                if (Input.GetKeyDown(KeyCode.V)||Input.GetMouseButtonDown(0))
                {
                    AudioSource.PlayClipAtPoint(gunShoot, this.transform.position);
                    sam_bul = (GameObject)Instantiate(m_Bullet, fire.position, fire.rotation);
                    m_bulrig = sam_bul.GetComponent<Rigidbody>();
                    m_bulrig.AddForce(fire.transform.forward * 4000.0f);
                    bullet_count -= 1;
                    m_Quad.SetActive(true);
                    quadCheck = true;
                }
            }
            
            if (sam_bul != null)
            {
                Destroy(sam_bul, 1.0f);
            }
            if (quadCheck)
            {
                quadTime += Time.deltaTime;
                if (quadTime > 0.1f)
                {
                    quadTime = 0f;
                    quadCheck = false;
                    m_Quad.SetActive(false);
                }
            }

        }

        if (PlayerHp <= 0f)
        {
            if (deadsound != true)
            {
                AudioSource.PlayClipAtPoint(Player_die, this.transform.position);
                deadsound = true;
            }
            Quaternion die = new Quaternion(-39f, 82f, -79f, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, die, Time.deltaTime / 30);
            dead = true;
            dieText.enabled = true;
            dieText.text = "GameOver";
        }

        if (undamaged)
        {
            undamagedTime += Time.deltaTime;
            if (undamagedTime > 0.5f)
            {
                undamaged = false;
                undamagedTime = 0;
            }
        }

        ImgBulleIndex = bullet_count;
        if (ImgBulleIndex == 10)
        {
            ImgBulleIndex = 0;
            Img10.enabled = true;
        }
        else
            Img10.enabled = false;

        bulletCou.GetComponent<Image>().sprite = numbers[ImgBulleIndex + 1];
    }
    public Image bulletCou, Img10;
    public Sprite[] numbers;
    private int ImgBulleIndex;
    private void OnCollisionEnter(Collision col)
    {
        if (!undamaged)
        {
            undamaged = true;
            if (col.gameObject.tag == "Mop")
            {
                PlayerHp -= 10;
                rig.AddForce(Vector3.back * 3.0f, ForceMode.Impulse);
                rig.AddForce(Vector3.up * 1f, ForceMode.Impulse);
                hpbar.value -= 10f;
            }
            else if (col.gameObject.tag == "MopHand")
            {
                rig.AddForce(Vector3.back * 4.0f, ForceMode.Impulse);
                rig.AddForce(Vector3.up * 2.0f, ForceMode.Impulse);
                PlayerHp -= 20;
                hpbar.value -= 20f;
            }

            else if (col.gameObject.tag == "BossMop")
            {
                PlayerHp -= 30;
                hpbar.value -= 30f;
                rig.AddForce(Vector3.back * 5.0f, ForceMode.Impulse);
                rig.AddForce(Vector3.up * 2f, ForceMode.Impulse);
            }
            else
            {
                undamaged = false;
            }



        }
        if (col.gameObject.tag == "Key")
        {
            //Manager.SendMessage("GetItem", col.gameObject.tag);
            //Manager_1 manager = new Manager_1();
            //manager.GetItem(col.gameObject.tag);
            Destroy(col.gameObject);
            getkey = true;
            manager.SendMessage("SetTextLine", 1);

        }
        else if (col.gameObject.tag == "trap_door")
        {
            rig.AddForce(Vector3.back * 12.0f, ForceMode.Impulse);
            rig.AddForce(Vector3.up * 12.0f, ForceMode.Impulse);
        }
        else if (col.gameObject.tag == "item")
        {
            item = col.gameObject.name;
            Destroy(col.gameObject);
        }

    }
    public void OnCollisionStay(Collision col)
    {
        if (!undamaged)
        {            undamaged = true;

            if (col.gameObject.tag == "Mop")
            {
                PlayerHp -= 10;
                rig.AddForce(Vector3.back * 3.0f, ForceMode.Impulse);
                rig.AddForce(Vector3.up * 1f, ForceMode.Impulse);
                hpbar.value -= 10f;
            }
            else if (col.gameObject.tag == "MopHand")
            {
                rig.AddForce(Vector3.back * 4.0f, ForceMode.Impulse);
                rig.AddForce(Vector3.up * 2.0f, ForceMode.Impulse);
                PlayerHp -= 20;
                hpbar.value -= 20f;
            }

            else if (col.gameObject.tag == "BossMop")
            {
                PlayerHp -= 30;
                hpbar.value -= 30f;
                rig.AddForce(Vector3.back * 5.0f, ForceMode.Impulse);
                rig.AddForce(Vector3.up * 2f, ForceMode.Impulse);
            }
            else
            {
                undamaged = false;
            }

        }
    }
    public static float Damage(float number)
    {
        float dam = 10 * number;
        return dam;
    }
    public string[] ReturnName(string[] names)
    {
        manager.SendMessage("getName", names);
        return names;
    }


    public void ClickOne()
    {
        if (!dead && !gun1)
        {
            m__gun2.SetActive(false);
            m__gun1.SetActive(true);
            gun1 = true;
            damage = Damage(1);
            if (getgun3)
                m__gun3.SetActive(false);
        }
    }
    public void ClickTwo()
    {
        if (!dead && gun1)
        {
            m__gun1.SetActive(false);
            m__gun2.SetActive(true);
            if (getgun3)
                m__gun3.SetActive(false);
            gun1 = false;
            damage = Damage(2);
        }
    }
    public void ClickThree()
    {

    }
    public void Relode()
    {
        if (bullet_count != 10)
        {
            bullet_count = 10;
            AudioSource.PlayClipAtPoint(gunReload, this.transform.position);
        }
    }
    public void ClickFire()
    {
        if (bullet_count > 0)
        {
            AudioSource.PlayClipAtPoint(gunShoot, this.transform.position);

            sam_bul = (GameObject)Instantiate(m_Bullet, fire.position, fire.rotation);
            m_bulrig = sam_bul.GetComponent<Rigidbody>();
            m_bulrig.AddForce(fire.transform.forward * 4000.0f);
            bullet_count -= 1;
            m_Quad.SetActive(true);

            quadCheck = true;
        }
    }
    public GameObject m_Quad;
}