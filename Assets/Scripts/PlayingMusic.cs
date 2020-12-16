using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace deflagration {
    public class PlayingMusic : MonoBehaviour
    {

        private AudioSource _audioSource;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
        }

    }

}
