using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int minDamage, maxDamage;
    public Camera playerCamera;
    public float range = 300f;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private GameObject currentImpactEffect;

    private EnemyManager enemyManager;

    public AudioSource gunSound;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale > 0)
        {
            Fire();
            muzzleFlash.Play();
            gunSound.Play();
        }
  
    }

    void Fire()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            enemyManager = hit.transform.GetComponent<EnemyManager>();

            currentImpactEffect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            

            if (enemyManager != null)
            {
                enemyManager.EnemyTakeDamage(Random.Range(minDamage, maxDamage));
            }

            // Belirli bir süre sonra efekti yok edin
            Destroy(currentImpactEffect, 1f);

        }
    }



}
