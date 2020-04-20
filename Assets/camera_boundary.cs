using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_not_boundary : MonoBehaviour
{


    private Vector2 velocity ; 
    public float smoothTimeY ;
    public float smoothTimeX ;

    public Vector3 minCameraPos ; 
    public Vector3 maxCameraPos ; 
    
    float ogZpos  ; 
    // Start is called before the first frame update
    void Start()
    {
        ogZpos = transform.position.z  ; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.z ),
            Mathf.Clamp(transform.position.y , minCameraPos.y,maxCameraPos.y ),
            Mathf.Clamp(transform.position.z , ogZpos ,ogZpos )
        );
    }
}
