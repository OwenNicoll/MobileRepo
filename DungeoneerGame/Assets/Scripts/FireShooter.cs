using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireBall;
    public Transform weaponTransform;
   

    private float fireTime;
    public float fireTimeCounter;



    // Update is called once per frame
    void Update()
    {
        fireTime += Time.deltaTime;

        if (fireTime > fireTimeCounter)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(fireBall, weaponTransform.position, weaponTransform.rotation);

        fireTime = 0;
    }
}
