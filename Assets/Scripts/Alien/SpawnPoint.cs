using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Alien
{
    public class SpawnPoint : MonoBehaviour
    {
        public static SpawnPoint instance = null;

        [SerializeField] private float spawnRadius = 5f;

        [HideInInspector] public List<Human.Infected> infectedHumans = new List<Human.Infected>();
        [HideInInspector] public List<Alien.Egg> eggs = new List<Alien.Egg>();

        public Human.Infected infectedPrefab;
        public Alien.Egg eggPrefab;
        public int lifeCount { get => infectedHumans.Count; }

        void Start()
        {
            if (instance == null)
            {
                instance = this;
                SpawnEgg();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        Vector3 GetRandomPosAround(Vector2 position, float radius) => new Vector3
        {
            x = position.x + Random.Range(-radius, radius),
            y = position.y + Random.Range(-radius, radius),
        };

        public void SpawnEgg()
        {
            PhotonNetwork.Instantiate(
                eggPrefab.name,
                GetRandomPosAround(transform.position, spawnRadius),
                Quaternion.identity
            );
        }

        public void SpawnInfected()
        {
            int selected = Random.Range(0, eggs.Count);
            var egg = eggs[selected];

            PhotonNetwork.Instantiate(
                infectedPrefab.name,
                GetRandomPosAround(egg.transform.position, spawnRadius / 4),
                Quaternion.identity
            );
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

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
#endif
    }
}