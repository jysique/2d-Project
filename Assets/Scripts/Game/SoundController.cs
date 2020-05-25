using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public enum Sounds{
        PLAYER_FIRE,
        PLAYER_EXPLOSION,
        ENEMY_FIRE,
        ENEMY_EXPLOSION,
        POWER_UP
    }

    public static SoundController instance;
    // Start is called before the first frame update
    [SerializeField] private List<AudioClip> sounds;
    private AudioSource audioSource;
    private void Awake() {
        instance = this;
        audioSource =GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(Sounds _sound){
        int index = (int)_sound;
        audioSource.clip = sounds[index];
        audioSource.Play();

    }

}
