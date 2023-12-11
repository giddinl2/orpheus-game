using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : Charmable
{
    private RandomWander wander;
    private NavMeshAgent agent;
    private Animator anim;
    private Vision vision;
    private SkeletonSwing SkeletonSwing;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        wander = GetComponent<RandomWander>();
        agent = GetComponent<NavMeshAgent>();
        vision = GetComponent<Vision>();
        wander.setAgent(agent);
        SkeletonSwing = GetComponent<SkeletonSwing>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        SkeletonSwing.setup(agent, player, this.gameObject);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        switch (Status)
        {
            case CharmStatus.Hostile:
                if (vision.isPlayerInSight())
                {
                    // approach, then hit
                    SkeletonSwing.goHit();
                }
                else
                {
                    // no player, wander hostile-ly
                    wander.Wander();
                }
                break;

            case CharmStatus.Neutral:
                // wander around
                wander.Wander();
                break;
            case CharmStatus.Charmed:
                // this should never happen
                break;
            case CharmStatus.Asleep:
                // don't move at all
                agent.ResetPath();
                break;
        }
        anim.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }

    protected override void OnHostile()
    {

    }

    protected override void OnNeutral()
    {
        agent.ResetPath();
    }

    protected override void OnCharmed()
    {


    }

    protected override void OnAsleep()
    {
        base.OnAsleep();
    }
}