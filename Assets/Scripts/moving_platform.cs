using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class moving_platform : MonoBehaviour
{
    private bool rockTouchedPlatform = false , hitTargetedPosition = false;
    private float ogPosition , targetedPosition, speedStart  = 0.5f, SpeedGoBack = 1f; 
    
    void Start()
    {
        ogPosition = transform.position.x;
        targetedPosition = ogPosition + 4f;
    }

    void Update()
    {
        if (rockTouchedPlatform)
        {    
            if (Mathf.Approximately(transform.position.x , targetedPosition))
            {
                hitTargetedPosition = true;
            }
            if ( !hitTargetedPosition )
            {
                transform.DOMoveX(targetedPosition, speedStart);
            }
            else
            {
                transform.DOMoveX(ogPosition, SpeedGoBack );
                if (Mathf.Approximately(transform.position.x, ogPosition))
                {
                    rockTouchedPlatform = false;
                    hitTargetedPosition = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision )
    {
        rockTouchedPlatform = true;
    }
}
