using System.Collections.Generic;

namespace ClickerGame.Models
{
    /// <summary>
    /// 販売所。
    /// </summary>
    public class Store<TMerhandise> where TMerhandise : Merchandise
    {
        /// <summary>
        /// 販売している商品一覧。
        /// </summary>
        public IEnumerable<TMerhandise> Merchandises { get; }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="merchandises">商品一覧。</param>
        public Store(IEnumerable<TMerhandise> merchandises) => Merchandises = merchandises;
    }
}
