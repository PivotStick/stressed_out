using UnityEngine;

namespace Player
{
    public enum RoleID
    {
        Alien,
        Human,
    }

    public class Spawner : MonoBehaviour
    {
        public GameObject humanPrefab;
        public GameObject alienPrefab;

        void Start()
        {
            var player = Player.Manager.Me;
            var isHuman = Player.Manager.MyRole == RoleID.Human;
            var spawnPointTag = isHuman
                ? "HumanSpawnPoint"
                : "AlienSpawnPoint";

            var prefab = isHuman
                ? humanPrefab
                : alienPrefab;

            var spawnPoints = GameObject.FindGameObjectsWithTag(spawnPointTag);
            var randomIndex = Random.Range(0, spawnPoints.Length);
            spawnPoints[randomIndex].GetComponent<SpawnPoint>().Spawn(prefab, new object[] {
                player.NickName
            });
        }
    }
}