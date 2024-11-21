using UnityEngine;
using UnityEngine.Rendering;

namespace CubesArmy.Scripts.Effects
{
    public class DangerEffectController : MonoBehaviour
    {
        [SerializeField] private Volume _volume;


        private void Awake()
        {
            // _volume = GetComponent<Volume>();
            _volume.enabled = false;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent<Cube.Cube>(out var cube))
            {
                _volume.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<Cube.Cube>(out var cube))
            {
                _volume.enabled = false;
            }
        }
    }
}