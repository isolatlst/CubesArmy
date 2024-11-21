using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CubesArmy.Scripts.Cube
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Cube : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        private Tweener _tweener;
        public event Action<Cube> OnDeath;


        private void Awake()
        {
            _meshRenderer = gameObject.GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
            ChangeColor();
        }

        private void OnMouseEnter()
        {
            ChangeColor();
        }
        
        private void OnMouseDown()
        {
            StartCoroutine(DestroyCube());
        }

        public void MoveTo(Vector3 position)
        {
            _tweener = transform.DOMove(position, 10f);
        }

        private void ChangeColor()
        {
            _meshRenderer.material.DOColor(Random.ColorHSV(0, 1), 0.5f);
        }

        private IEnumerator DestroyCube()
        {
            yield return transform.DOPunchScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f).WaitForCompletion();
            _tweener.Kill(true);
            OnDeath?.Invoke(this);
        }
    }
}