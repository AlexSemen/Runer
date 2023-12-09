  using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] float _spamDelay;

    private List<Transform> _transforms;
    private bool _isWork;
    private GameObject _newObject;

    private void Awake()
    {
        Initialize(_prefabs);

        _isWork = true;

        _transforms = GetComponentsInChildren<Transform>().ToList();
    }

    private void Start()
    {
        if(_transforms.Count > 0)
        {
            StartCoroutine(Spam());
        }
    }

    private void SetObject(GameObject newObject, Vector2 position)
    {
        newObject.SetActive(true);
        newObject.transform.position = position;
    }

    private IEnumerator Spam()
    {
        var waitForDelay = new WaitForSeconds(_spamDelay);

        while (_isWork)
        {
            if (TryGetObject(out _newObject))
            {
                SetObject(_newObject, _transforms[Random.Range(0, _transforms.Count)].position);
            }

            yield return waitForDelay;
        }
    }
}
