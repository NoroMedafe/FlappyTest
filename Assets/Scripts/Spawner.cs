using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pipe prefab;
    [SerializeField] private List<Level> _levels;
    [SerializeField] private int _currentLevel;
    [SerializeField] private TMP_Text _levelTExt;
    private List<Pipe> _pipes = new();

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPipe), _levels[_currentLevel].spawnRate, _levels[_currentLevel].spawnRate);

        _levelTExt.text = "Current level: " + (_currentLevel + 1);

    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPipe));
    }

    private void SpawnPipe()
    {
        Pipe pipe = Instantiate(prefab, transform.position, Quaternion.identity);
        pipe.speed = _levels[_currentLevel].speed;
        pipe.transform.position += Vector3.up * Random.Range(_levels[_currentLevel].minHeight, _levels[_currentLevel].maxHeight);
        pipe.GetSpawner(this);
        _pipes.Add(pipe);
    }

    public void DestroyPipe(Pipe pipe)
    {
        _pipes.Remove(pipe);
        Destroy(pipe.gameObject);
    }

    public void ClearAllPipes()
    {
        Debug.Log(_pipes.Count);
        foreach (var item in _pipes)
        {
            Destroy(item.gameObject);
        }
        _pipes.Clear();
    }
    public void GetCurrentLevel(int level)
    {
        _currentLevel = level;
        _levelTExt.text = "Current level: " + (level + 1);
    }
    
}
