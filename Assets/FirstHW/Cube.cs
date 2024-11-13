using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _step = 0.25f;
    
    
    void Update()
    {
        if (transform.position.x is > 3 or < -3)
        {
            _step = -_step;
        }

        transform.position += new Vector3(_step, 0, 0) * Time.unscaledDeltaTime;
    }
}