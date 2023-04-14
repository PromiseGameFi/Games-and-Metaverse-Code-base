using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey = KeyCode.E;
    [SerializeField] private GameObject[] attackVFXPrefabs;
    [SerializeField] private AudioClip[] attackSounds;
    [SerializeField] private float timeBetweenAttacks = 3f;

    private AudioSource audioSource;
    private GameObject currentVFX;
    private int vfxIndex = 0;
    private int soundIndex = 0;
    private float lastAttackTime = -Mathf.Infinity;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            float timeSinceLastAttack = Time.time - lastAttackTime;
            if (timeSinceLastAttack >= timeBetweenAttacks)
            {
                PlayAttack();
            }
            else
            {
                soundIndex++;
                vfxIndex++;
                if (soundIndex >= attackSounds.Length)
                {
                    soundIndex = 0;
                }
                if (vfxIndex >= attackVFXPrefabs.Length)
                {
                    vfxIndex = 0;
                }
                PlayAttack();
            }
        }
    }

    private void PlayAttack()
    {
        if (currentVFX != null)
        {
            Destroy(currentVFX);
        }
        lastAttackTime = Time.time;
        audioSource.PlayOneShot(attackSounds[soundIndex], 1f / timeBetweenAttacks);
        currentVFX = Instantiate(attackVFXPrefabs[vfxIndex], transform.position, Quaternion.identity);
        Destroy(currentVFX, timeBetweenAttacks);
    }
}
