using System;
using UnityEngine;

namespace ClickerGame.Models
{
    /// <summary>
    /// 通貨種類。
    /// </summary>
    public enum CurrencyType
    {
        /// <summary>
        /// なし。
        /// </summary>
        None,

        /// <summary>
        /// 髪の毛。
        /// </summary>
        Hair,
    }

    /// <summary>
    /// 通貨。
    /// </summary>
    [Serializable]
    public struct Currency
    {
        /// <summary>
        /// 種類。
        /// </summary>
        public CurrencyType Type => _type;
        [SerializeField]
        private CurrencyType _type;

        /// <summary>
        /// 量。
        /// </summary>
        public double Quantity => _quantity;
        [SerializeField]
        private double _quantity;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="value">量。</param>
        /// <param name="type">種類。</param>
        public Currency(CurrencyType type, double value)
        {
            _type = type;
            _quantity = value;
        }

        public override string ToString() => $"{Quantity}({Type})";
    }
}
