using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Human
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] protected float spawnRadius = 5f;

        public GameObject prefab;

        public void Spawn()
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

                data: new object[] {
                    Player.Manager.Me.NickName
                }
            );
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
#endif
    }
}