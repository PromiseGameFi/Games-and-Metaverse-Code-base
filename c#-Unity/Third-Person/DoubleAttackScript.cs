using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
    public class DoubleAttackScript : MonoBehaviour
    {
        // The first animation that will play in the sequence
        public AnimationClip attackAnimation1;
        // The second animation that will play in the sequence
        public AnimationClip attackAnimation2;
        // The hitbox that will detect collisions with enemies
        //public BoxCollider2D hitbox;
        // A reference to the animator component
        private Animator animator;
        // A flag to track whether the first attack has been triggered
        private bool firstAttackTriggered = false;

        private void Start()
        {
            // Get the animator component
            animator = GetComponent<Animator>();
            // Disable the hitbox at the start
            //hitbox.enabled = false;
        }

        private void Update()
        {
            // Check if the "C" key has been pressed
            if (Input.GetKeyDown(KeyCode.C))
            {
                // If the first attack has not been triggered, trigger it
                if (!firstAttackTriggered)
                {
                    Attack();
                    firstAttackTriggered = true;
                    // Start a coroutine to reset the flag after 3 seconds
                    StartCoroutine(ResetFirstAttackTriggered());
                }
                // If the first attack has been triggered, trigger the second attack
                else
                {
                    DoubleAttack();
                    firstAttackTriggered = false;
                }
            }
        }

        private void Attack()
        {
            // Enable the hitbox
            //hitbox.enabled = true;
            // Play the first attack animation
            animator.Play(attackAnimation1.name);
            // Start a coroutine to disable the hitbox after the first attack animation has finished playing
            StartCoroutine(DisableHitbox());
        }

        /**private void DoubleAttack()
        {
            // Play the second attack animation
            animator.Play(attackAnimation2.name);
            // Start a coroutine to disable the hitbox after the second attack animation has finished playing
            //StartCoroutine(DisableHitbox());
        }*/

        /**private IEnumerator ResetFirstAttackTriggered()
        {
            // Wait for 3 seconds
            yield return new WaitForSeconds(3);
            // Reset the firstAttackTriggered flag
            firstAttackTriggered = false;
        }*/

        private IEnumerator DisableHitbox()
        {
            // Wait for the current animation to finish
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            // Disable the hitbox
            //hitbox.enabled = false;
        }

        /**private void OnTriggerEnter2D(Collider2D other)
        {
            // If the hitbox collides with an enemy, play a sound or perform some other action
            if (other.gameObject.tag == "Enemy")
            {
                // Play a sound
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            }
        }*/
    }
}
