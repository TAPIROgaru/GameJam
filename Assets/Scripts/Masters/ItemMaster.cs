using ClickerGame.Models;
using System.Collections.Generic;
using UnityEngine;

namespace ClickerGame.Masters
{
    /// <summary>
    /// アイテムマスター。
    /// </summary>
    [CreateAssetMenu]
    public class ItemMaster : ScriptableObject
    {
        [SerializeField]
        private string _name = "";

        [SerializeField]
        private Sprite _sprite = default;

        [SerializeField]
        private Currency _price = default;

        [SerializeField]
        private Currency[] _productivities;

        /// <summary>
        /// アイテム名。
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// アイコン画像。
        /// </summary>
        public Sprite Sprite => _sprite;

        /// <summary>
        /// 基準価格。
        /// </summary>
        public Currency Price => _price;

        /// <summary>
        /// 1秒間の生産量。
        /// </summary>
        public IEnumerable<Currency> Productivities => _productivities;
    }
}
