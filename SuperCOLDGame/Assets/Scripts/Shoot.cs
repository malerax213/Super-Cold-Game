using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;
    public int bulletCount = 0;
    public int n_enemies;
    public Text currentAmmoText;
    public Text carriedAmmoText;
    

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    // Use this for initialization
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        n_enemies = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && bulletCount <= n_enemies * 3)
        {
            bulletCount = bulletCount + 1;

            if ((n_enemies * 3) - bulletCount >= 0)
            {
                updateAmmoUI((n_enemies * 3) - bulletCount, n_enemies * 3);
            }

            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_Bullet_Handler, 10.0f);
        }
       
    }


    void updateAmmoUI (int currentAmmo, int carriedAmmo)
    {
        if(currentAmmoText != null)
        {
            currentAmmoText.text = currentAmmo.ToString();
        }

        if(carriedAmmoText != null)
        {
            carriedAmmoText.text = carriedAmmo.ToString();
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), bulletCount.ToString());
    }
}
