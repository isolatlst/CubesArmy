using UnityEngine;

namespace CubesArmy.Scripts.Cube.Source
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private Cube _template;
        private CubesObjectPool _cubesObjectPool;


        private void Awake()
        {
            _cubesObjectPool = new CubesObjectPool(_template);
        }

        public Cube SpawnCube()
        {
            var cube = _cubesObjectPool._SpawnCube(transform);
            cube.OnDeath += DespawnCube;

            return cube;
        }

        private void DespawnCube(Cube cube)
        {
            cube.OnDeath -= DespawnCube;
            _cubesObjectPool._ReturnCubeToPool(cube);
        }
    }
}