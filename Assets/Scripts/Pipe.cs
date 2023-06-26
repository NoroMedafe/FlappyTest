using UnityEngine;

public class Pipe : MonoBehaviour
{
    private Spawner _spawner;
    public Transform top;
    public Transform bottom;

    public float speed;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge) {
            _spawner.DestroyPipe(this);
        }
    }

    public void GetSpawner(Spawner spawner)
    {
        _spawner = spawner;
    }

}
