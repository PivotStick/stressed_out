using UnityEngine;

namespace Alien
{
    public class Egg : MonoBehaviour
    {
        public Facehugger facehugger;
        public Spawner spawner;

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
            spawner.infectedHumans.Add(infected);
            spawner.eggs.Remove(this);

            Destroy(facehugger.gameObject);
            Destroy(this);
        }
    }
}