using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float spawnRadius = 5f;

    public void Spawn(GameObject prefab, object[] data = null)
    {
        var pos = new Vector3
        {
            x = transform.position.x + Random.Range(-spawnRadius, spawnRadius),
            y = transform.position.y + Random.Range(-spawnRadius, spawnRadius),
            z = 0,
        };

        PhotonNetwork.Instantiate(
            prefab.name,
            pos,
            Quaternion.identity,

            data: data
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gameObject.tag == "AlienSpawnPoint" ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
