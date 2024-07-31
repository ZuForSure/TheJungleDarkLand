using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : ZuMonoBehaviour
{
    protected static AudioManager instance;
    public static AudioManager Instance => instance;

    [SerializeField] protected AudioSource footStepSound;
    [SerializeField] protected AudioSource backGroundSound;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip swingWeapon;
    [SerializeField] protected AudioClip shootSound;
    [SerializeField] protected AudioClip dashSound;
    [SerializeField] protected AudioClip explosionPlayer;
    [SerializeField] protected AudioClip healSound;
    [SerializeField] protected AudioClip enemyExplosion;
    [SerializeField] protected AudioClip enemyShoot;
    [SerializeField] protected AudioClip impactBody;
    public AudioSource FootStepSound => footStepSound;
    public AudioSource AudioSource => audioSource;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.Log("Only 1 AudioManager are allowed to exist");
        AudioManager.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.HideFootSound();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFootstepSound();
        this.LoadBGSound();
    }

    protected virtual void HideFootSound()
    {
        this.footStepSound.transform.gameObject.SetActive(false);
    }

    protected virtual void LoadFootstepSound()
    {
        if (this.footStepSound != null) return;
        this.footStepSound = GameObject.Find("Foot Step Sound").GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadFootstepSound", gameObject);
    }

    protected virtual void LoadBGSound()
    {
        if (this.backGroundSound != null) return;
        this.backGroundSound = GameObject.Find("Background Music").GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadBGSound", gameObject);
    }

    public virtual void PlaySwingWeaponSound()
    {
        this.audioSource.PlayOneShot(this.swingWeapon, 0.25f);
    }

    public virtual void PlayShootSound()
    {
        this.audioSource.PlayOneShot(this.shootSound, 0.5f);
    }

    public virtual void PlayDashSound()
    {
        this.audioSource.PlayOneShot(this.dashSound, 0.5f);
    }

    public virtual void PlayExplosionPlayer()
    {
        this.audioSource.PlayOneShot(this.explosionPlayer, 0.3f);
    }

    public virtual void PlayHealSound()
    {
        this.audioSource.PlayOneShot(this.healSound, 1f);
    }

    public virtual void PlayExplosionEnemySound()
    {
        this.audioSource.PlayOneShot(this.enemyExplosion, 0.3f);
    }

    public virtual void PlayEnemtShootSound()
    {
        this.audioSource.PlayOneShot(this.enemyShoot, 0.5f);
    }

    public virtual void PlayImpactBodySound()
    {
        this.audioSource.PlayOneShot(this.impactBody, 0.5f);
    }
}
