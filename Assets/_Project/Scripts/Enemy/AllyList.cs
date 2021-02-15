using System.Collections.Generic;
using UnityEngine;

public class AllyList : MonoBehaviour
{
    public static AllyList Instance;
    public List<AttackHitDetector> allies;

    public int currentIndex;

    private void Awake()
    {
        Instance = this;
    }
}