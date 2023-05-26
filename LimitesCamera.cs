using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesCamera : MonoBehaviour
{

    public FollowPlayer m_FollowCamera;

    public GameObject Player;

    public float LimittesG;

    public float LimittesD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > LimittesG && Player.transform.position.x < LimittesD)
        {
            m_FollowCamera.suis = true;
            print("true");
        }
        else
        {
            m_FollowCamera.suis = false;
            print("false");
        }
    }
}
