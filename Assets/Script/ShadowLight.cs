using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLight : MonoBehaviour
{
    public float degree;
    private float perDegreee = 0.5f;
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
            curRange+=perDegreee;
            float curRad = curRange * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(curRad), Mathf.Sin(curRad));
            RaycastHit2D[] ress = Physics2D.RaycastAll(transform.position, direction);
            for (int i = 0; i < ress.Length; i++)
            {
                RaycastHit2D res = ress[i];
                if (res.collider.tag == "Player")
                {
                    res.collider.GetComponent<LightShadowForm>().currameHit = true;
                    continue;
                }
                if (res.collider != null)
                {
                    vertex.Add(res.point-res.normal*0.2f);

                    LightEvent target = res.collider.GetComponent<LightEvent>();
                    if (target)
                        target.currameHit = true;
                }
                else
                    vertex.Add(transform.position + 100 * direction.Vec2ToVec3());
                break;
            }
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
