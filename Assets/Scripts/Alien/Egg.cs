using UnityEngine;
using Photon.Pun;

namespace Alien
{
    public class Egg : MonoBehaviourPun, IPunInstantiateMagicCallback
    {
        public Facehugger facehugger;
        public SpawnPoint spawnPoint;

        private Human.Corpse corpse;

        public void OnTriggerEnter2D(Collider2D collider)
        {
            corpse = collider.GetComponent<Human.Corpse>();
            if (!corpse || corpse.infectionStarted) return;
            corpse.StartInfection();
            facehugger.MoveTo(corpse);
        }

        public void Infect()
        {
            var infected = corpse.Infect();
            Infect(infected);
        }

        public void Infect(Human.Infected infected)
        {
            spawnPoint.infectedHumans.Add(infected);
            spawnPoint.eggs.Remove(this);

            Destroy(facehugger.gameObject);
            Destroy(this);
        }

        void IPunInstantiateMagicCallback.OnPhotonInstantiate(PhotonMessageInfo info)
        {
            spawnPoint = SpawnPoint.instance;
            spawnPoint.eggs.Add(this);
        }
    }
}