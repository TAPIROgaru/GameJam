using System;
using System.Collections.Generic;

namespace ClickerGame.Models
{
    /// <summary>
    /// 通貨インベントリー。
    /// </summary>
    public class CurrencyInventory
    {
        private readonly Dictionary<CurrencyType, Currency> _dictionary = new Dictionary<CurrencyType, Currency>();

        /// <summary>
        /// 通貨の一覧を取得する。
        /// </summary>
        public IReadOnlyCollection<Currency> CachList => _dictionary.Values;

        /// <summary>
        /// 通貨に変更があった。
        /// </summary>
        public Action<Currency> Changed;

        /// <summary>
        /// 通貨を加算する。
        /// </summary>
        /// <param name="type">通貨種類。</param>
        /// <param name="quantity">加算量。</param>
        /// <returns>加算後の通貨量。</returns>
        public Currency Add(CurrencyType type, double quantity)
            => Add(new Currency(type, quantity));

        /// <summary>
        /// 通貨を加算する。
        /// </summary>
        /// <param name="quantity">加算量。</param>
        /// <returns>加算後の通貨量。</returns>
        public Currency Add(Currency currency)
        {
            var result = currency;

            if (_dictionary.TryGetValue(currency.Type, out Currency total))
            {
                result = new Currency(currency.Type, total.Quantity + currency.Quantity);
                _dictionary[currency.Type] = result;
            }
            else
            {
                _dictionary.Add(currency.Type, currency);
            }
            Changed?.Invoke(result);
            return result;
        }

        /// <summary>
        /// 指定種類の通貨量を取得する。
        /// </summary>
        /// <param name="type">種類。</param>
        /// <returns>現在の所有通貨量。</returns>
        public double GetQuantity(CurrencyType type)
        {
            if (_dictionary.TryGetValue(type, out Currency c))
            {
                return c.Quantity;
            }
            return 0;
        }
    }
}
