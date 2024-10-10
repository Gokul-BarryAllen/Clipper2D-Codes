using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager1 : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("Audio Clip")]
    public AudioClip BGM;//Done
    public AudioClip Jump;//Done
    public AudioClip Run;//Done
    public AudioClip Hurt;//Done
    public AudioClip Death;//Done
    public AudioClip Coin;//Done
    public AudioClip Gem;//Done
    public AudioClip KeyandArtefact;//Done
    public AudioClip GameCompletion;//Done
    public AudioClip GameOver;//Done
    public AudioClip Cherry;//Done
    public AudioClip Treasure;
    public AudioClip SkillEnabler;
    
    /*private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }*/
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = BGM;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
