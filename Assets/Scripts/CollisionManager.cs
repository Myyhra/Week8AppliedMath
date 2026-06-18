using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class CollisionManager : MonoBehaviour
{
    private List<AABB_Box> bounds = new();

    void OnEnable()
    {
        bounds = Object.FindObjectsByType<AABB_Box>(FindObjectsSortMode.None).ToList();
    }

    private void Update()
    {
        for (int i = 0; i < bounds.Count; i++)
        {
            AABB_Box box = bounds[i];
            bool collided = false;

            for (int j = 0; j < bounds.Count; j++)
            {
                if (i == j)
                    continue;

                if (IsColliding(box.Bounds, bounds[j].Bounds))
                {
                    collided = true;
                    break;
                }
            }

            box.isColliding = collided;
        }
    }

    public bool IsColliding(AABB a, AABB b)
    {
        return a.min.x <= b.max.x
            && b.min.x <= a.max.x
            && a.min.y <= b.max.y
            && b.min.y <= a.max.y
            && a.min.z <= b.max.z
            && b.min.z <= a.max.z;
    }
}