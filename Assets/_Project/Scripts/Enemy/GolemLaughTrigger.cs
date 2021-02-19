using UnityEngine;

public class GolemLaughTrigger : MonoBehaviour
{
    private Health _health;
    public int laughAfterHits;
    private int _currentHitCount;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.healthChanged += LaughEveryNHit;
    }

    private void LaughEveryNHit()
    {
        _currentHitCount++;
        if (_currentHitCount == laughAfterHits)
        {
            _currentHitCount = 0;
            AudioHolder.Instance.golemLaugh.Play();
        }
    }
}