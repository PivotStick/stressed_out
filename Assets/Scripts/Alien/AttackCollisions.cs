using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Alien
{
    public class AttackCollisions : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player")) return;
            var damage = Random.Range(10f, 30f);

            Network.Event.TriggerEvent(Network.Event.ID.DAMAGE_PLAYER, new object[] {
                col.GetComponent<PhotonView>().ViewID,
                damage,
            });
        }
    }
}