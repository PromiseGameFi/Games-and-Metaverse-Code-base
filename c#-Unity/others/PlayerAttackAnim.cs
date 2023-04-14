using UnityEngine;
//Player attack sequence with player animation sync, soundfx and vfx
public class PlayerAttackAnim : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey = KeyCode.E;
    [SerializeField] private GameObject[] attackVFXPrefabs;
    [SerializeField] private AudioClip[] attackSounds;
    [SerializeField] private string[] attackAnimTriggers;
    [SerializeField] private float timeBetweenAttacks = 3f;
    [SerializeField] private GameObject spawnLocation;

    private AudioSource audioSource;
    private GameObject currentVFX;
    private int vfxIndex = 0;
    private int soundIndex = 0;
    private int animIndex = 0;
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
                animIndex++;
                if (soundIndex >= attackSounds.Length)
                {
                    soundIndex = 0;
                }
                if (vfxIndex >= attackVFXPrefabs.Length)
                {
                    vfxIndex = 0;
                }
                if (animIndex >= attackAnimTriggers.Length)
                {
                    animIndex = 0;
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
        currentVFX = Instantiate(attackVFXPrefabs[vfxIndex], spawnLocation.transform.position, Quaternion.identity);
        Destroy(currentVFX, timeBetweenAttacks);
        GetComponent<Animator>().SetTrigger(attackAnimTriggers[animIndex]);
    }
}
