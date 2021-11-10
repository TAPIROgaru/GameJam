using ClickerGame.Models;
using UnityEngine;

namespace ClickerGame.Masters
{
    /// <summary>
    /// 強化マスター。
    /// </summary>
    [CreateAssetMenu]
    public class EnhancerMaster : ScriptableObject
    {
        /// <summary>
        /// 強化名。
        /// </summary>
        public string Name => _name;
        [SerializeField]
        private string _name = "";

        /// <summary>
        /// アイコン画像。
        /// </summary>
        public Sprite Sprite => _sprite;
        [SerializeField]
        private Sprite _sprite = default;

        /// <summary>
        /// 価格。
        /// </summary>
        public Currency Price => _price;
        [SerializeField]
        private Currency _price = default;

        /// <summary>
        /// 強化対象アイテム。
        /// </summary>
        public ItemMaster ItemMaster => _item;
        [SerializeField]
        private ItemMaster _item = default;

        /// <summary>
        /// 強化倍率。
        /// </summary>
        public double Factor => _factor;
        [SerializeField]
        private double _factor = default;
    }
}