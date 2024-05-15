using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnimation;

    private Rigidbody rb;
    public float speed = 5f;

    private Transform playerTarget;

    public float attackDistance = 1f;
    private float chasePlayerAfterAttack = 1f;

    private float currentAttackTime;
    private float defaultAttackTime;

    private bool followPlayer, attackPlayer;

    void Awake()
    {
        enemyAnimation = GetComponentInChildren<CharacterAnimation>();
        rb = GetComponentInChildren<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (!followPlayer) return;

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {
            transform.LookAt(playerTarget);
            rb.velocity = transform.forward * speed;

            if (rb.velocity.sqrMagnitude != 0)
            {
                enemyAnimation.Walk(true);
            }
        }
        else if(Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            rb.velocity = Vector3.zero;
            enemyAnimation.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }

    void Attack()
    {
        if (!attackPlayer) return;

        currentAttackTime += Time.deltaTime;

        if(currentAttackTime > defaultAttackTime)
        {
            enemyAnimation.EnemyAttack(Random.Range(0, 3));

            currentAttackTime = 0f;
        }
        
        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }

    }
}
