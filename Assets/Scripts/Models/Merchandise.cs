using System;
using UnityEngine;

namespace ClickerGame.Models
{
    /// <summary>
    /// 商品。
    /// </summary>
    public abstract class Merchandise
    {
        /// <summary>
        /// 商品名。
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 商品画像。
        /// </summary>
        public Sprite Sprite { get; }

        /// <summary>
        /// 購入価格。
        /// </summary>
        public Currency Price { get => _currency; set { _currency = value; PriceChanged?.Invoke(this); } }

        private Currency _currency;

        /// <summary>
        /// <see cref="Price" /> が変更されたときに発生するイベント。
        /// </summary>
        public event Action<Merchandise> PriceChanged;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="name">商品名。</param>
        /// <param name="price">購入価格。</param>
        public Merchandise(string name, Currency price) : this(name, default, price) { }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="name">商品名。</param>
        /// <param name="sprite">商品画像。</param>
        /// <param name="price">購入価格。</param>
        public Merchandise(string name, Sprite sprite, Currency price)
        {
            Name = name;
            Sprite = sprite;
            Price = price;
        }

        /// <summary>
        /// このアイテムの購入を要求する。
        /// </summary>
        public abstract void Purchase();
    }
}