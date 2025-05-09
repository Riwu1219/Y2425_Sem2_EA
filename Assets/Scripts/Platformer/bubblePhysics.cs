using UnityEngine;
using System.Collections;

public class bubblePhysics : MonoBehaviour
{
    public float GravityOffset = -9.81f;
    public float Intensity = 1f;
    public float Mass = 1f;
    public float stiffness = 1f;
    public float damping = 0.75f;

    public bool isTeleport = false;

    private Mesh OriginalMesh, MeshClone;
    new private MeshRenderer renderer;
    private JellyVertex[] jv;
    private Vector3[] vertexArray;

    // Start is called before the first frame update
    void Start()
    {
        OriginalMesh = GetComponent<MeshFilter>().sharedMesh;
        physcisSetup();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isTeleport)
        {
            vertexArray = OriginalMesh.vertices;
            for (int i = 0; i < jv.Length; i++)
            {
                Vector3 target = transform.TransformPoint(vertexArray[jv[i].ID]);


                float intensity = (1 - (renderer.bounds.max.y - target.y) / renderer.bounds.size.y) * Intensity;
                jv[i].Shake(target, Mass, stiffness, damping);
                target = transform.InverseTransformPoint(jv[i].Position);
                vertexArray[jv[i].ID] = Vector3.Lerp(vertexArray[jv[i].ID], target, intensity);



            }
            MeshClone.vertices = vertexArray;
        }
        else
        {
            
            physcisSetup();
            isTeleport = false;
        }


    }

    public void physcisSetup()
    {
        Physics.gravity = new Vector3(0f, GravityOffset, 0f);
        renderer = GetComponent<MeshRenderer>();
        MeshClone = Instantiate(OriginalMesh);
        GetComponent<MeshFilter>().sharedMesh = MeshClone;
        jv = new JellyVertex[MeshClone.vertices.Length];
        for (int i = 0; i < MeshClone.vertices.Length; i++)
            jv[i] = new JellyVertex(i, transform.TransformPoint(MeshClone.vertices[i]));
    }

    public class JellyVertex
    {
        public int ID;
        public Vector3 Position;
        public Vector3 velocity, Force;

        public JellyVertex(int _id, Vector3 _pos)
        {
            ID = _id;
            Position = _pos;
        }

        public void Shake(Vector3 target, float m, float s, float d)
        {
            Force = (target - Position) * s;
            velocity = (velocity + Force / m) * d;
            Position += velocity;
            if ((velocity + Force + Force / m).magnitude < 0.001f)
                Position = target;
        }
    }
}