using ClickerGame.Masters;
using ClickerGame.Models;
using System;

/// <summary>
/// 強化商品情報。
/// </summary>
/// <remarks>
/// アイテムと異なり同じ強化を複数購入することはできない。
/// 一度購入すると効果が有効になる。
/// </remarks>
public class MerchandiseEnhancer : Merchandise
{
    /// <summary>
    /// 強化マスター。
    /// </summary>
    public EnhancerMaster Master { get; }

    /// <summary>
    /// 購入済みかどうか。
    /// </summary>
    public bool IsPurchased { get; private set; }
    
    /// <summary>
    /// この強化が購入された。
    /// </summary>
    public event Action<MerchandiseEnhancer> Purchased;

    /// <summary>
    /// コンストラクター。
    /// </summary>
    /// <param name="master">強化マスター。</param>
    /// <param name="price">購入価格。</param>
    public MerchandiseEnhancer(EnhancerMaster master, Currency price) : base(master.Name, master.Sprite, price)
    {
        Master = master;
        IsPurchased = Game.Instance.EnhancerInventory.HasEnhancer(Master);
    }

    /// <summary>
    /// この強化の購入を要求する。
    /// </summary>
    public override void Purchase()
    {
        if (IsPurchased) { return; } // すでに購入済み。

        var game = Game.Instance;
        if (game.TryPurchase(Master))
        {
            IsPurchased = true;
            Purchased?.Invoke(this);
        }
    }
}
