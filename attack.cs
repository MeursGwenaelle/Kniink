using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{

    private GameObject attackArea = default;

    private bool attacking = false;
    private float timeToAttack = 0.1f;
    public PlayerMoveAndJump playerMoveAndJump;
    private Animator animator;

    private float Timer = 0f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        attacking = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isAttacking", attacking);
        if (playerMoveAndJump.isFacingRight == true)
        {
            attackArea.transform.localScale = new Vector3(1, 1, 1);

        }

        if (playerMoveAndJump.isFacingRight == false)
        {
            attackArea.transform.localScale = new Vector3(-1, 1, 1);

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();

        }

        if(attacking)
        {
            Timer += Time.deltaTime;

            if(Timer >= timeToAttack)
            {
                Timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }
    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);

    }
}
