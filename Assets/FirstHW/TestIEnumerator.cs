using System.Collections;
using UnityEngine;

namespace IEnum
{
    class MyIEnumerator : IEnumerator
    {
        public object Current => new WaitForSeconds(1);

        public bool MoveNext()
        {
            Debug.Log("Корутины синхронны и могут возвращать значение!");
            return true;
        }

        public void Reset()
        {
            Debug.Log("Ресетаю мою корутину и останавливаю");
        }
    }

    public class TestIEnumerator : MonoBehaviour
    {
        private IEnumerator _myCoroutine;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _myCoroutine = new MyIEnumerator();
                StartCoroutine(_myCoroutine);
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                _myCoroutine.Reset();
                StopAllCoroutines();
            }
        }
    }
}