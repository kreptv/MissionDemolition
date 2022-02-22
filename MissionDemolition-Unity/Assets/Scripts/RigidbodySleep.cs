/*
 * Created by: Haley Kelly
 * Date Created: 2/16/2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: 2/16/2022
 *
 * Description: For castle wall.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class RigidbodySleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Rigidbody rb = GetComponent<Rigidbody>();

      rb.Sleep();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
