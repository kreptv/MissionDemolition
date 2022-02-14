/*
 * Created by: Haley Kelly
 * Date Created: 2/14/2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: 2/14/2022
 *
 * Description: Camera script.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
  /*** VARIABLES ***/
  static public GameObject POI; // the static point of interest

  [Header("Set In Inspeector")]
  public float easing = 0.05f;
  public Vector2 minXY = Vector2.zero;

  [Header("Set Dynamically")]
  public float camZ; // desired z pos of the camera


  private void Awake(){
    camZ = this.transform.position.z; // sets z value

  }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(POI != null){
        Vector3 destination = POI.transform.position;

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        // interolate from current position to destination
        destination = Vector3.Lerp(transform.position, destination, easing);

        destination.z = camZ;

        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;
      }
    }
}
