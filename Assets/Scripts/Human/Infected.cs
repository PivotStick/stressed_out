using UnityEngine;
using UnityEditor;

namespace Human
{
    public class Infected : MonoBehaviour
    {
        private GameObject prefab;
        private Animator animator;

        void Awake()
        {
            name = "Infected";
            prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Alien.prefab");
            animator = GetComponent<Animator>();

            animator.SetBool("dead", true);
            animator.SetBool("infected", true);
        }

        public void Transform()
        {
            animator.SetTrigger("transform");
        }

        public void SpawnAlien()
        {
            var babyAlien = GetComponentInChildren<BabyAlien>();
            Cam.Follower.target = Instantiate(
                prefab,
                babyAlien.transform.position,
                Quaternion.identity
            );
            Destroy(this);
            Destroy(babyAlien.gameObject);
        }
    }
}