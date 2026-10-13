using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private GameObject playerRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        TrackPlayer();
    }


    private void TrackPlayer()
    {
        if(playerRef != null)
        {
            this.gameObject.transform.position = playerRef.transform.position;
        }
    }
}
