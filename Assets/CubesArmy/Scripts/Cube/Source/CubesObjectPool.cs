using System.Collections.Generic;
using CubesArmy.Scripts.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CubesArmy.Scripts.Cube.Source
{
    public class CubesObjectPool
    {
        private Queue<Cube> _pool = new();
        private Cube _template;
        private const int MAX_POOL_SIZE = 15;
        private const float MIN_SPAWN_DISTANCE = 15f;
        private const float MAX_SPAWN_DISTANCE = 30f;

        public CubesObjectPool (Cube template)
        {
            _template = template;
        }
        

        public Cube _SpawnCube(Transform parent)
        {
            if (_pool.Count == 0)
            {
                var newCube = GameObject.Instantiate(
                    _template,
                    new Vector3(GetRandomValue.GetRandomFloat(MIN_SPAWN_DISTANCE, MAX_SPAWN_DISTANCE), 
                        0, 
                        GetRandomValue.GetRandomFloat(MIN_SPAWN_DISTANCE, MAX_SPAWN_DISTANCE)),
                    Quaternion.identity,
                    parent);
                
                return newCube;
            }

            if (_pool.Count < MAX_POOL_SIZE)
            {
                var cubeFromPool = _pool.Dequeue();
                cubeFromPool.transform.position 
                    = new Vector3(GetRandomValue.GetRandomFloat(MIN_SPAWN_DISTANCE, MAX_SPAWN_DISTANCE), 
                        cubeFromPool.transform.position.y,
                        GetRandomValue.GetRandomFloat(MIN_SPAWN_DISTANCE, MAX_SPAWN_DISTANCE));
                
                cubeFromPool.gameObject.SetActive(true);
                
                return cubeFromPool;
            }

            return null;
        }

        public void _ReturnCubeToPool(Cube cube)
        {
            _pool.Enqueue(cube);
            cube.gameObject.SetActive(false);
        }
    }
}