using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public GameObject knifePrefab;
    public Transform weaponTransform;
    public bool canFire = true;

    private float fireTime;
    public float fireTimeCounter;
   


    // Update is called once per frame
    void Update()
    {
        fireTime += Time.deltaTime;

        if (fireTime > fireTimeCounter)
        {
            canFire = true;            
        }
    }

    public void Shoot()
    {
        if (canFire)
        {
            Instantiate(knifePrefab, weaponTransform.position, weaponTransform.rotation);

            fireTime = 0;
            
            canFire = false;
        }
        
    }
}
