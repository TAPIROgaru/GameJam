using ClickerGame.Masters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClickerGame.Models
{
    /// <summary>
    /// アイテムインベントリー。
    /// </summary>
    public class ItemInventory
    {
        private readonly Dictionary<ItemMaster, int> _items = new Dictionary<ItemMaster, int>();

        /// <summary>
        /// 所有（数が0以上の）しているアイテム一覧。
        /// </summary>
        public IReadOnlyCollection<ItemMaster> Items => _items.Keys;

        /// <summary>
        /// アイテムに変更があった。
        /// </summary>
        public Action<ItemMaster, int> Changed;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public ItemInventory()
        {
        }

        /// <summary>
        /// アイテムを追加する。
        /// </summary>
        /// <param name="item">追加するアイテム。</param>
        /// <param name="count">追加する個数。</param>
        public void Add(ItemMaster item, int count = 1)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }

            if (_items.TryGetValue(item, out var current))
            {
                var newCount = current + count;
                _items[item] = newCount;
                Changed?.Invoke(item, newCount);
            }
            else
            {
                _items.Add(item, count);
                Changed?.Invoke(item, count);
            }
        }

        /// <summary>
        /// アイテムの所有数を取得する。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int GetCount(ItemMaster item)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }

            if (_items.TryGetValue(item, out int count))
            {
                return count;
            }
            return 0;
        }

        /// <summary>
        /// 保有している全アイテムの総数を取得する。
        /// </summary>
        /// <returns>保有している全アイテムの総数</returns>
        public int GetCountAll()
        {
            var sum = 0;
            foreach(var key in _items.Keys)
            {
                sum += _items[key];
            }
            return sum;
        }

        /// <summary>
        /// 価格を取得する。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Currency GetPrice(ItemMaster item)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }

            var c = GetCount(item);
            return new Currency(item.Price.Type, item.Price.Quantity);
        }

        /// <summary>
        /// 指定アイテムの1秒間の総生産量を取得する。
        /// </summary>
        /// <param name="item">アイテムマスター。</param>
        /// <returns>1秒間の総生産量。</returns>
        public IEnumerable<Currency> GetTotalProductivities(ItemMaster item)
        {
            if (_items.TryGetValue(item, out var count))
            {
                return item.Productivities.Select(x => new Currency(x.Type, x.Quantity * count));
            }
            return Array.Empty<Currency>();
        }
    }
}
