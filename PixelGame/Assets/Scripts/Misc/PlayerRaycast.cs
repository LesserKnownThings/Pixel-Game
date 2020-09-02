using System;
using UnityEngine;

public static class PlayerRaycast 
{
  

    public static RaycastHit2D Ray(Transform obj, LayerMask layer)
    {
        RaycastHit2D hit = Physics2D.Raycast(obj.position, -Vector2.up, 1.55f, layer);

        return hit;
    }


}
