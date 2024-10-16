using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cannon : MonoBehaviour
{
    private Animator cannonAnimator;
    [SerializeField]private Animator boarCannonAnimator;
    [SerializeField] private GameObject cannonBall;
    [SerializeField] private Transform cannonBallSpawnPoint;
    [SerializeField] private float cannonBallSpeed;
    //[SerializeField] private float cannonBallDamage;
    [SerializeField] private float cannonBallLifeTime;
    [SerializeField] private int directShoot;
    [SerializeField] private float shootDelay;
    private bool readyToShoot = true;

    private void Start()
    {
        cannonAnimator = gameObject.GetComponent<Animator>();
    }

    public void ShootCannon()
    {
        cannonAnimator.SetBool("IsLightning", false);
        //Shooting();
        if(!readyToShoot) return;
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        
        GameObject cannonBallClone = Instantiate(cannonBall, cannonBallSpawnPoint.position, Quaternion.identity);
        cannonBallClone.SetActive(true);
        Rigidbody2D rb = cannonBallClone.GetComponent<Rigidbody2D>();
        //using DOTween to move the cannonball
        rb.DOMove(new Vector2(cannonBallSpawnPoint.position.x+ directShoot, cannonBallSpawnPoint.position.y), 1f).SetEase(Ease.Linear);
        Destroy(cannonBallClone, cannonBallLifeTime);
        readyToShoot = false;
        yield return new WaitForSeconds(shootDelay);
        readyToShoot = true;
    }
}
