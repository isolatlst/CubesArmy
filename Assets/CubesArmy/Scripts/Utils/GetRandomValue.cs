using UnityEngine;

namespace CubesArmy.Scripts.Utils
{
    public static class GetRandomValue
    {
        public static float GetRandomFloat(float minVal, float maxVal) => Random.Range(0, 2) == 0 ? Random.Range(-maxVal, -minVal) : Random.Range(minVal, maxVal);
    }
}