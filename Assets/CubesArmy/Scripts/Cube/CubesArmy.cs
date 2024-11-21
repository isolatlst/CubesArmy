using System.Collections;
using CubesArmy.Scripts.Cube.Source;
using UnityEngine;

namespace CubesArmy.Scripts.Cube
{
    public class CubesArmy : MonoBehaviour
    {
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private int _countOfEnemies;
        [SerializeField] private SpawnController _spawnController;
        private bool _isOffensiveAreComing;


        private void Start()
        {
            _isOffensiveAreComing = true;

            for (int i = 0; i < _countOfEnemies; i++)
            {
                var cube = _spawnController.SpawnCube();
                cube.MoveTo(_targetPosition.position);
            }

            StartCoroutine(StartOffensive());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isOffensiveAreComing = !_isOffensiveAreComing;
                Time.timeScale = _isOffensiveAreComing ? 1 : 0;
            }
        }

        private IEnumerator StartOffensive()
        {
            while (_isOffensiveAreComing)
            {
                yield return new WaitForSeconds(2f);
                var cube = _spawnController.SpawnCube();
                cube.MoveTo(_targetPosition.position);
                yield return null;
            }
        }
    }
}