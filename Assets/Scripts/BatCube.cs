using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCube : MonoBehaviour
{
    [SerializeField]
    public BatFollower followerCube;


    // Start is called before the first frame update
    void Start()
    {
        if (followerCube != null)
        {
            followerCube.SetFollowTarget(this);
        }
    }

    
}
