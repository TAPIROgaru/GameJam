using ClickerGame.Masters;
using System;
using System.Collections.Generic;

namespace ClickerGame.Models
{
    /// <summary>
    /// 強化インベントリー。
    /// </summary>
    public class EnhancerInventory
    {
        /// <summary>
        /// 強化一覧。
        /// </summary>
        public IReadOnlyCollection<EnhancerMaster> Enhancers => _enhancers;
        private readonly HashSet<EnhancerMaster> _enhancers = new HashSet<EnhancerMaster>();

        /// <summary>
        /// 1秒間の生産量。
        /// </summary>
        public IDictionary<ItemMaster, double> ItemFactors => _itemFactors;
        private Dictionary<ItemMaster, double> _itemFactors = new Dictionary<ItemMaster, double>();

        /// <summary>
        /// 強化が追加された。
        /// </summary>
        public event Action<EnhancerMaster> Added;

        public EnhancerInventory()
        {
        }

        /// <summary>
        /// 強化を追加する。
        /// </summary>
        /// <param name="enhancer">追加する強化マスター。</param>
        public void Add(EnhancerMaster enhancer)
        {
            if (enhancer == null) { throw new ArgumentNullException(nameof(enhancer)); }

            if (enhancer.ItemMaster != null)
            {
                if (_itemFactors.TryGetValue(enhancer.ItemMaster, out var factor))
                {
                    _itemFactors[enhancer.ItemMaster] = factor + enhancer.Factor;
                }
                else { _itemFactors.Add(enhancer.ItemMaster, enhancer.Factor); }
            }

            _enhancers.Add(enhancer);
            Added?.Invoke(enhancer);
        }

        /// <summary>
        /// 強化を所有しているかどうか。
        /// </summary>
        /// <param name="enhancer">強化マスター。</param>
        /// <returns>所有していれば true。</returns>
        public bool HasEnhancer(EnhancerMaster enhancer)
        {
            if (enhancer == null) { throw new ArgumentNullException(nameof(enhancer)); }
            return _enhancers.Contains(enhancer);
        }

        /// <summary>
        /// 価格を取得する。
        /// </summary>
        /// <param name="enhancer">強化マスター。</param>
        /// <returns>指定の強化マスターを購入するために必要な価格。</returns>
        public Currency GetPrice(EnhancerMaster enhancer)
        {
            if (enhancer == null) { throw new ArgumentNullException(nameof(enhancer)); }
            return enhancer.Price;
        }

        /// <summary>
        /// 指定のアイテムに対する総強化倍率を取得する。
        /// </summary>
        /// <param name="item">アイテムマスター。</param>
        /// <returns>総強化倍率。</returns>
        public double GetTotalFactor(ItemMaster item)
        {
            if (ItemFactors.TryGetValue(item, out var factor))
            {
                return factor;
            }
            return 0;
        }
    }
}
