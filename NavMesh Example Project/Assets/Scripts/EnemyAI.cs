/*
* (Greg Brandt)
* (Assignment 9)
* Moves enemy to player when player is within a specified distance
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyAI : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public GameObject player;
    public float chaseDistance = 8;

    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        agent.updateRotation = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
	{
		MoveEnemy();
	}

	private void MoveEnemy()
	{
		float distanceFromTarget = Vector3.Distance(transform.position, player.transform.position);
		if (distanceFromTarget > agent.stoppingDistance && distanceFromTarget < chaseDistance)
		{
			agent.SetDestination(player.transform.position);
			character.Move(agent.desiredVelocity, false, false);
		}
		else
		{

			agent.SetDestination(transform.position);
			character.Move(Vector3.zero, false, false);
		}
	}
}
