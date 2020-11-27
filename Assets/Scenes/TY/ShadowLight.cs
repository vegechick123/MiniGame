using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLight : MonoBehaviour
{
    public float degree;
    private float perDegreee = 1f;
    public MeshFilter meshFilter;
    struct Range
    {
        public float minimum;
        public float maxmum;
        public Range(float a, float b)
        {
            minimum = a;
            maxmum = b;
        }
        public static Range operator +(Range a, float degree)
        {
            return new Range(a.minimum + degree, a.maxmum + degree);
        }
    }
    private void FixedUpdate()
    {

        float current = transform.rotation.eulerAngles.z;
        Range range = new Range(current - degree / 2, current + degree / 2);
        RayCastRange(range);

    }
    void RayCastRange(Range range)
    {
        float curRange = range.minimum;

        List<Vector2> hitpoints = new List<Vector2>();
        List<Vector3> vertex = new List<Vector3>();
        vertex.Add(transform.position);

        do
        {
            //Mathf.Deg2Rad(curRange);
            curRange++;
            float curRad = curRange * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(curRad), Mathf.Sin(curRad));
            RaycastHit2D res = Physics2D.Raycast(transform.position, direction);
            if (res.collider != null)
            {
                vertex.Add(res.point);
                LightEvent target = res.collider.GetComponent<LightEvent>();
                if (target)
                    target.currameHit = true;
            }
            else
                vertex.Add(transform.position + 100 * direction.Vec2ToVec3());
            
            
            //Debug.DrawRay(transform.position, res.point-new Vector2(transform.position.x, transform.position.y),Color.red);
            //for (int i = 0; i < res.Length; i++)
            //{
            //    if (res.Length >= 1)
            //    {
            //        RaycastHit2D hit = res[0];

            //        Vector2 point;
            //        //Raycast code here
            //        if (res.Length == 1)
            //        {
            //            point = hit.point + 10f * direction;

            //        }
            //        else
            //        {
            //            point = res[1].point - 0.1f * direction;
            //        }
            //        RaycastHit2D oppositeRes = Physics2D.Raycast(point, -direction);
            //        //if(oppositeRes!=null)
            //        if (oppositeRes.collider != null)
            //        {

            //            Debug.DrawRay(oppositeRes.point, point - oppositeRes.point);
            //        }
            //        //Debug.DrawRay(oppositeRes.point, direction);
            //        //Debug.DrawRay(point, hit.normal);
            //        //Debug.DrawRay(transform.position, new Vector3(point.x, point.y,0) -transform.position, Color.yellow);
            //    }
            //}
        }
        while (curRange < range.maxmum);
        Mesh mesh = new Mesh();
        if (vertex.Count > 3)
        {
            int[] triangles = new int[3 * (vertex.Count - 2)];
            Vector2[] uv = new Vector2[vertex.Count];
            for (int i = 0; i < uv.Length; i++)
            {
                uv[i] = new Vector2(0, 0);
            }
            for (int i = 0; 3 * i + 2 < triangles.Length; i++)
            {
                triangles[3 * i] = i + 1;
                triangles[3 * i + 1] = 0;
                triangles[3 * i + 2] = i + 2;
            }
            Debug.Log(vertex.Count);
            mesh.vertices = vertex.ToArray();
            mesh.triangles = triangles;
            mesh.uv = uv;
            meshFilter.mesh = mesh;
        }

    }

}
