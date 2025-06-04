using UnityEngine;

public class Spawner : MonoBehaviour
{
  [SerializeField] private GameObject enemyPrefab;
  [SerializeField] private float duration;
  [SerializeField] private float currentTime;
  [SerializeField] private float[] posX;

  private void Start()
  {
    duration = Random.Range(0.5f, 1.5f);
    currentTime = duration;
  }

  private void Update()
  {
    if (currentTime <= 0)
    {
      Spawn();
      // Spawn süresi her seferinde 0.1 azalır, ancak minimum 0.2 saniye olacak şekilde sınırlandırılır.
      duration = Mathf.Max(0.2f, duration - 0.1f);
      duration = Mathf.Max(0.2f, duration - 0.1f);
      currentTime = duration;
    }
    else
    {
      currentTime -= Time.deltaTime;
    }
  }

  private void Spawn()
  {
    float spawnX = posX[Random.Range(0, posX.Length)];
    GameObject newEnemy = Instantiate(enemyPrefab, new Vector2(spawnX, transform.position.y), Quaternion.identity, transform);
    // Eğer spawn konumu posX dizisinin ikinci elemanına yaklaşık olarak eşitse, düşman 180 derece döndürülür .
    if (Mathf.Approximately(spawnX, posX[1]))
    {
      newEnemy.transform.Rotate(0, 180f, 0);
    }
  }
}