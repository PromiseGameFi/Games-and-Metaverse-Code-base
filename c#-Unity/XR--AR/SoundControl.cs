using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public float comboInterval = 2.0f; // maximum time between key presses for combo
    public AudioClip[] attackSounds; // array of attack sounds

    private AudioSource audioSource;
    private float lastComboTime;
    private int comboCount;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastComboTime = Time.time - comboInterval; // start with a long time ago
        comboCount = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float timeSinceLastCombo = Time.time - lastComboTime;
            if (timeSinceLastCombo < comboInterval)
            {
                comboCount++;
                if (comboCount >= attackSounds.Length)
                {
                    comboCount = 0;
                }
            }
            else
            {
                comboCount = 0;
            }
            lastComboTime = Time.time;

            // play the appropriate sound for the current combo
            audioSource.clip = attackSounds[comboCount];
            audioSource.Play();
        }
    }
}
