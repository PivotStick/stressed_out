using System.Collections.Generic;
using UnityEngine;

namespace Alien
{
  public class Spawner : MonoBehaviour
  {
    [SerializeField] private float spawnRadius = 5f;

    public Human.Infected infectedPrefab;
    public Alien.Egg eggPrefab;
    public int numberOfLife = 2;

    [HideInInspector] public List<Human.Infected> infectedHumans = new List<Human.Infected>();
    [HideInInspector] public List<Alien.Egg> eggs = new List<Alien.Egg>();

    public int lifeCount { get => infectedHumans.Count; }

    void Start()
    {
      for (int i = 0; i < 5; i++)
        SpawnFaceHugger();

      for (int i = 0; i < numberOfLife; i++)
        SpawnInfected();
      
      SelectNewAlien();
    }

    Vector3 GetRandomPosAround(Vector2 position, float radius) => new Vector3
    {
      x = position.x + Random.Range(-radius, radius),
      y = position.y + Random.Range(-radius, radius),
    };

    public void SpawnFaceHugger()
    {
      var egg = GameObject.Instantiate(
        eggPrefab,
        GetRandomPosAround(transform.position, spawnRadius),
        Quaternion.identity
      );
      egg.spawner = this;
      eggs.Add(egg);
    }

    public void SpawnInfected()
    {
      int selected = Random.Range(0, eggs.Count);
      var egg = eggs[selected];

      var infected = GameObject.Instantiate(
        infectedPrefab,
        GetRandomPosAround(egg.transform.position, spawnRadius / 4),
        Quaternion.identity
      );

      egg.Infect(infected);
    }

    public void SelectNewAlien()
    {
      if (infectedHumans.Count <= 0) return;

      int selected = Random.Range(0, infectedHumans.Count);
      var infected = infectedHumans[selected];

      Cam.Follower.target = infected.gameObject;
      infected.Transform();
      infectedHumans.Remove(infected);
    }

    private void OnDrawGizmos()
    {
      Gizmos.color = gameObject.tag == "AlienSpawnPoint" ? Color.green : Color.red;
      Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
  }
}