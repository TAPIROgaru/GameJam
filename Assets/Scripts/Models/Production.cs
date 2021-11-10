using System;
using System.Collections.Generic;
using ClickerGame.Masters;

namespace ClickerGame.Models
{
    /// <summary>
    /// 生産管理。
    /// </summary>
    public class Production : IDisposable
    {
        /// <summary>
        /// アイテム用インベントリー。
        /// </summary>
        public ItemInventory ItemInventory { get; }

        /// <summary>
        /// 強化用インベントリー。
        /// </summary>
        public EnhancerInventory EnhancerInventory { get; }

        /// <summary>
        /// 1秒間の生産量。
        /// </summary>
        public IDictionary<CurrencyType, double> ProductivitiesPerSec => _productivitiesPerSec;
        private Dictionary<CurrencyType, double> _productivitiesPerSec = new Dictionary<CurrencyType, double>();

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="itemInventory">アイテム用インベントリー。</param>
        /// <param name="enhancerInventory">強化用インベントリー。</param>
        public Production(ItemInventory itemInventory, EnhancerInventory enhancerInventory)
        {
            ItemInventory = itemInventory ?? throw new ArgumentNullException(nameof(itemInventory));
            EnhancerInventory = enhancerInventory ?? throw new ArgumentNullException(nameof(enhancerInventory));

            ItemInventory.Changed += ItemInventory_Changed;
            EnhancerInventory.Added += EnhancerInventory_Added;

            // 辞書の初期化
            var dic = _productivitiesPerSec;
            foreach (var key in Enum.GetValues(typeof(CurrencyType)))
            {
                dic.Add((CurrencyType)key, 0);
            }
            UpdateProductivities();
        }

        private void ItemInventory_Changed(ItemMaster item, int count)
        {
            UpdateProductivities();
        }

        private void EnhancerInventory_Added(EnhancerMaster enhancer)
        {
            UpdateProductivities();
        }

        private void UpdateProductivities()
        {
            foreach (var item in ItemInventory.Items)
            {
                foreach (var p in ItemInventory.GetTotalProductivities(item))
                {
                    var f = EnhancerInventory.GetTotalFactor(item);
                    _productivitiesPerSec[p.Type] += p.Quantity * (1 + f);
                }
            }
        }

        public void Dispose()
        {
            ItemInventory.Changed -= ItemInventory_Changed;
            EnhancerInventory.Added -= EnhancerInventory_Added;
        }
    }
}
