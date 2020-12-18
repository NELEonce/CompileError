using UnityEngine;

namespace DontStop.MeshCombine
{
    public class MeshCombine : MonoBehaviour
    {
        private void Awake()
        {
            var meshFilters = transform.GetComponentsInChildren<MeshFilter>();
            var combine = new CombineInstance[meshFilters.Length];

            for (int i = 0; i < meshFilters.Length; ++i)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            }

            var combineObj = new GameObject();
            combineObj.name = "combine" + transform.name;

            var myMeshFilter = combineObj.AddComponent<MeshFilter>();
            myMeshFilter.mesh.CombineMeshes(combine);

            var collider = combineObj.AddComponent<MeshCollider>();
            collider.convex = true;
            collider.sharedMesh = myMeshFilter.mesh;
        }
    }
}
