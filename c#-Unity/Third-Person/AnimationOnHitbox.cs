using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOnHitbox : MonoBehaviour
{
    // The animation that will play when the enemy is hit
    public AnimationClip hitAnimation;
    // The hitbox that will detect collisions with the player's weapon
    public BoxCollider hitbox;
    // A reference to the animator component
    private Animator animator;

    private void Start()
    {
        // Get the animator component
        animator = GetComponent<Animator>();
        hitbox= GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collider other)
    {
        // If the hitbox collides with the player's weapon, play the hit animation
        if (other.gameObject.CompareTag("Weapon"))
        {
            animator.Play(hitAnimation.name);
            Debug.Log("Its Inside");
        }
    }
}
