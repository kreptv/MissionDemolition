/*
 * Created by: Haley Kelly
 * Date Created: 2/14/2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: 2/14/2022
 *
 * Description: Creates randomly generated clouds.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

  /*** VARIABLES ***/
  public GameObject cloudSphere;
  public int numberSpheresMinimum = 6;
  public int numberSpheresMaximum = 10;

  public Vector2 sphereScaleRangeX = new Vector2(4, 8);
  public Vector2 sphereScaleRangeY = new Vector2(3, 4);
  public Vector2 sphereScaleRangeZ = new Vector2(2, 4);

  public Vector3 sphereOffsetScale = new Vector3(5, 2, 1);
  public float scaleYMin = 2f;
  private List<GameObject> spheres;



    // Start is called before the first frame update
    void Start()
    {
      spheres = new List<GameObject>();
      int num = Random.Range(numberSpheresMinimum, numberSpheresMaximum);

      for (int i = 0; i < num; i++){ // continue making spheres
        GameObject sp = Instantiate<GameObject>(cloudSphere);
        spheres.Add(sp);

        Transform spTrans = sp.transform;
        spTrans.SetParent(this.transform);

        // randomly assign a position

        Vector3 offset = Random.insideUnitSphere;
        offset.x *= sphereOffsetScale.x;
        offset.y *= sphereOffsetScale.y;
        offset.z *= sphereOffsetScale.z;
        spTrans.localPosition = offset;

        Vector3 scale = Vector3.one;
        scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeX.y);
        scale.y = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
        scale.z = Random.Range(sphereScaleRangeZ.x, sphereScaleRangeZ.y);

        // adjust y scale by x distance from core
        scale.y *= 1 - (Mathf.Abs(offset.x)/ sphereOffsetScale.x);
        scale.y = Mathf.Max(scale.y, scaleYMin);
        spTrans.localScale = scale;

      }

    }

    // Update is called once per frame
    void Restart()
    {
      foreach (GameObject sp in spheres){
        Destroy(sp);
      }

    }
}
