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
    private GameObject cannonBallClone;
    private bool readyToShoot = true;

    private void Start()
    {
        cannonAnimator = gameObject.GetComponent<Animator>();
        cannonBallClone = Instantiate(cannonBall, cannonBallSpawnPoint.position, Quaternion.identity);
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
        cannonBallClone.SetActive(true);
        Rigidbody2D rb = cannonBallClone.GetComponent<Rigidbody2D>();
        //using DOTween to move the cannonball
        rb.DOMove(new Vector2(cannonBallSpawnPoint.position.x+ directShoot, cannonBallSpawnPoint.position.y), 1f).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                cannonBallClone.transform.position = cannonBallSpawnPoint.position;
                cannonBallClone.SetActive(false);
            }
            );
        readyToShoot = false;
        yield return new WaitForSeconds(shootDelay);
        readyToShoot = true;
    }
    
}
