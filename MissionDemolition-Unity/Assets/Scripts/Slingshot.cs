/*
 * Created by: Haley Kelly
 * Date Created: 2/9/2022
 *
 * Last Edited by: N/A
 * Last Edited: 2/9/2022
 *
 * Description:
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    /** VARIABLES **/

    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMultiplier = 8f;


    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public Rigidbody projectileRB;


    private void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");

        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }


    private void OnMouseEnter()
    {
        print("Slingshot: OnMouseEnter");
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        print("Slingshot: OnMouseExit");
        launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
        aimingMode = true; // while player is pushing down
            projectile = Instantiate(prefabProjectile) as GameObject;
            projectile.transform.position = launchPos;
            projectileRB = projectile.GetComponent<Rigidbody>();
            projectileRB.isKinematic = true;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!aimingMode)
        {
            return;
        }
        // get current mouse position
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos; // amount of change between current mouse + launch

        // limit mouseDelta to slingshot collider radius
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize(); // sets the vector to the same direction, but length is 1.0
            mouseDelta *= maxMagnitude;
        }

        // move projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRB.isKinematic = false;
            projectileRB.velocity = -mouseDelta * velocityMultiplier;
            projectile = null;  // forget the last instance
        }
    }
}
