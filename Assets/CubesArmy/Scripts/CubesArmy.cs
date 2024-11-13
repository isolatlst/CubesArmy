using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace CubesArmy.Scripts
{
    public class CubesArmy : MonoBehaviour
    {
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private Material[] _materials;
        [SerializeField] private int _countOfEnemies;
        [SerializeField] private Cube _cubeTemplate;
        private Cube[] _cubes = null!;
        private bool _isOffensiveAreComing;

        private void Awake()
        {
            _isOffensiveAreComing = true;
            Random rand = new Random();
            _cubes = new Cube[_countOfEnemies];

            for (int i = 0; i < _countOfEnemies; i++)
            {
                _cubes[i] = Instantiate(
                    _cubeTemplate,
                    transform.position + new Vector3(i + rand.Next(-5, 5), 0, i + rand.Next(-5, 5)),
                    Quaternion.identity,
                    transform);

                StartCoroutine(SetRandomColorWithDelay(_cubes[i]));
                StartCoroutine(MoveCubeWithDelay(_cubes[i]));
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isOffensiveAreComing = !_isOffensiveAreComing;
                Time.timeScale = _isOffensiveAreComing ? 1 : 0;
            }
        }

        private IEnumerator SetRandomColorWithDelay(Cube cube)
        {
            Random rand = new Random();
            while (true)
            {
                yield return new WaitForSecondsRealtime(rand.Next(3, 5));
                cube.SetMaterial(_materials[rand.Next(0, _materials.Length)]);
            }
        }

        private IEnumerator MoveCubeWithDelay(Cube cube)
        {
            Random rand = new Random();
            while (_isOffensiveAreComing)
            {
                yield return new WaitForSeconds(rand.Next(0, 2));
                cube.MoveTo(_targetPosition.position);
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}