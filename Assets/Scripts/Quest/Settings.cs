using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "Quests/New Quest")]
    public class Settings : ScriptableObject
    {
        public Sprite brokenSprite;
        public Sprite repairedSprite;

        public MiniGame miniGame;
    }
}
