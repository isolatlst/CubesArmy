using UnityEngine;

namespace CubesArmy.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Cube : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;


        private void Awake()
        {
            _meshRenderer = gameObject.GetComponent<MeshRenderer>();
        }

        public void SetMaterial(Material material)
        {
            if (material != null)
            {
                _meshRenderer.material = material;
            }
        }

        public void MoveTo(Vector3 position)
        {
            transform.Translate(position * Time.deltaTime);
        }
    }
}
