using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParticleCollider : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public List<ParticleCollisionEvent> collisionEvents;
    public GameObject Enemy;
    public int maxHealth = 3;
    public int currentHealth;

    public void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        currentHealth = maxHealth;
    }

    public void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            // Do something with the collision event data
            ParticleCollisionEvent collisionEvent = collisionEvents[i];
            Debug.Log("Particle collided with " + collisionEvent.colliderComponent.name);
            if(collisionEvent.colliderComponent.name == "Man_02")
            {
                TakeDamage();
            }

            currentHealth -= 1;
            
            if(currentHealth > 0)
            {
                Enemy.GetComponent<Animator>().Play("Change");
            }
        }
    }

   
    public void TakeDamage()
    {
        //currentHealth = 0 ;
        if (currentHealth <= 0)
        {
            Enemy.GetComponent<Animator>().Play("Changer");
            Invoke("DestroyEnemy", 100f);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(Enemy);
    }
}
