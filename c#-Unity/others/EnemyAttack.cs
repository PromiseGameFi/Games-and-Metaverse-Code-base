using UnityEngine;
//This script uses the PlayerattackAnim script
public class EnemyAttack : MonoBehaviour
{
    public PlayerAttackAnim playerAttack;
    [SerializeField] private string[] animationTriggers;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            int animationIndex = playerAttack.vfxIndex % animationTriggers.Length;
            other.GetComponent<Animator>().SetTrigger(animationTriggers[animationIndex]);
        }
    }
}

