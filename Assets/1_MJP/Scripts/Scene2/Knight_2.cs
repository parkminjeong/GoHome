using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Knight_2 : MonoBehaviour {
    public GameObject m_player;
        private NavMeshAgent nav;
	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();	
	}
	
	// Update is called once per frame
	void Update () {
        float dis = Vector3.Distance(m_player.transform.position, transform.position);
        if (dis > 4f)
        {
            nav.SetDestination(m_player.transform.position);
        }
	}
}
