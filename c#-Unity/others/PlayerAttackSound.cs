using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject[] attackVFXPrefabs; // array of attack VFX prefabs
    public AudioClip[] attackSounds; // array of attack sounds to be played
    public float attackDuration = 3f; // duration between attack sound and VFX changes
    public KeyCode attackButton = KeyCode.E; // key code for attack button

    private float lastAttackTime; // time of the last attack
    private int soundIndex = 0; // index of the current attack sound
    private int vfxIndex = 0; // index of the current attack VFX

    private void Update()
    {
        // check if the attack button is pressed
        if (Input.GetKeyDown(attackButton))
        {
            // calculate the duration since the last attack
            float elapsedTime = Time.time - lastAttackTime;

            // play the attack sound based on the duration
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = attackSounds[soundIndex];
            audioSource.PlayOneShot(audioSource.clip, 1f / elapsedTime);

            // spawn the attack VFX
            GameObject attackVFXPrefab = attackVFXPrefabs[vfxIndex];
            Instantiate(attackVFXPrefab, transform.position, Quaternion.identity);

            // update the sound and VFX indices
            if (elapsedTime >= attackDuration)
            {
                soundIndex = (soundIndex + 1) % attackSounds.Length;
                vfxIndex = (vfxIndex + 1) % attackVFXPrefabs.Length;
            }

            // spawn the VFX from the player's hand
            Transform hand = transform.GetChild(vfxIndex);
            Instantiate(hand.GetChild(0).gameObject, hand.position, Quaternion.identity, hand);
        }

        // update the last attack time
        lastAttackTime = Time.time;
    }
}
