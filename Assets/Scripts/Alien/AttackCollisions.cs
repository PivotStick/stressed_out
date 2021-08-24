using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Alien
{
    public class AttackCollisions : MonoBehaviourPun
    {
        void Awake()
        {
            if (!photonView.IsMine)
                Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.GetComponent<Human.Main>()) return;
            var damage = Random.Range(10f, 30f);

            Network.Event.Trigger(Network.Event.ID.DAMAGE_PLAYER, new object[] {
                col.GetComponent<PhotonView>().ViewID,
                damage,
            });
        }
    }
}