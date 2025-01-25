using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private AudioSource audioSource;
        
        [Header("Bubble Pop")]
        [SerializeField] private AudioClip popUpBubble;
        
        [Header("Rhythms")]
        [SerializeField] private AudioClip[] rhythms;

        private void OnEnable()
        {
            gameManager.OnInputSuccession += PlayPopBubbleAudio;
            gameManager.OnRhythmSectionWin += PlayRhythmAudio;
            gameManager.OnNoteSuccession += PlayNoteAudio;
        }

        private void OnDisable()
        {
            gameManager.OnInputSuccession -= PlayPopBubbleAudio;
            gameManager.OnRhythmSectionWin -= PlayRhythmAudio;
            gameManager.OnNoteSuccession -= PlayNoteAudio;
        }

        public void PlayPopBubbleAudio()
        {
            if (popUpBubble)
            {
                audioSource.volume = 0.6f;
                audioSource.PlayOneShot(popUpBubble);
                audioSource.volume = 1f;
            }
        }

        public void PlayRhythmAudio(int index)
        {
            if (index >= rhythms.Length) return;
            
            audioSource.PlayOneShot(rhythms[index]);
        }

        public void PlayNoteAudio(AudioClip noteClip)
        {
            audioSource.PlayOneShot(noteClip);
        }
    }
}
