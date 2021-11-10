using ClickerGame.Masters;
using System;

namespace ClickerGame.Models
{
    /// <summary>
    /// アイテムの情報。
    /// </summary>
    /// <remarks>
    /// 同系統の項目を複数購入可能で、所持数に応じて効果が加算されていく想定。
    /// </remarks>
    public class MerchandiseItem : Merchandise
    {
        /// <summary>
        /// アイテムマスター。
        /// </summary>
        public ItemMaster Master { get; }

        /// <summary>
        /// 現在の所有数。
        /// </summary>
        public int Count { get => _count; set { _count = value; CountChanged?.Invoke(this); } }
        private int _count;

        /// <summary>
        /// <see cref="Count" /> が変更されたときに発生するイベント。
        /// </summary>
        public event Action<MerchandiseItem> CountChanged;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="master">商品のマスターデータ。</param>
        /// <param name="price">購入価格。</param>
        public MerchandiseItem(ItemMaster master, Currency price, int count) : base(master.Name, master.Sprite, price)
        {
            Master = master;
            Count = count;
        }

        /// <summary>
        /// このアイテムの購入を要求する。
        /// </summary>
        public override void Purchase()
        {
            var game = Game.Instance;
            if (game.TryPurchase(Master))
            {
                var inventory = game.ItemInventory;
                Price = inventory.GetPrice(Master);
                Count = inventory.GetCount(Master);
            }
        }
    }
}