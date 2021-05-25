using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class box : MonoBehaviour
{
     public float speedX = .1f;
     public float speedy = .1f;
    private Renderer r;
    private float screenCenterX;
    private float screenCenterY;


    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        screenCenterX = Screen.width * 0.5f;
        screenCenterY = Screen.height * 0.5f;

        // r.material.mainTextureOffset = new Vector2(screenCenterX, screenCenterY);
    }

    // Update is called once per frame
    void Update()
    {
        
        //r.material.mainTextureOffset = new Vector2(Time.time * speedX, Time.time * speedy);
        
        
        // if there are any touches currently
        if(Input.touchCount > 0)
        {
            // get the first one
            Touch firstTouch = Input.GetTouch(0);
            
            // if it began this frame
            if(firstTouch.phase == TouchPhase.Stationary)
            {
                // Vector2 origin = r.material.mainTextureOffset;
                //
                // Vector2 target = new Vector2(firstTouch.position.x - screenCenterX, firstTouch.position.y - screenCenterY);
                //
                // float xo = target.x < 0 ? -1:1;
                // float yo = target.y < 0 ? -1:1;
                //
                // Vector2 offset = new Vector2(xo,yo) * Time.deltaTime * speed;
                // // new Vector2(Time.time * speed, 0);
                // r.material.mainTextureOffset = Vector2.MoveTowards (origin, target, speed * Time.deltaTime);

                


/*                if(firstTouch.position.x > screenCenterX)
                {
                    // if the touch position is to the right of center
                    // move right
                    Vector2 offset = new Vector2(Time.time * speed, 0);
                    r.material.mainTextureOffset = offset;
                }
                else if(firstTouch.position.x < screenCenterX)
                {
                    // if the touch position is to the left of center
                    // move left
                    Vector2 offset = new Vector2(Time.time * speed*-1, 0);
                    r.material.mainTextureOffset = offset;
                }*/
            }
        }
        


    }
}
