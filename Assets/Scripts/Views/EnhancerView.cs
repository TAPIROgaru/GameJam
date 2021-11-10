/// <summary>
/// 強化商品ビュー。
/// </summary>
public class EnhancerView : MerchandiseView<MerchandiseEnhancer>
{
    /// <summary>
    /// 現在の項目を購入できるかどうか。
    /// </summary>
    protected override bool CanPurchase => Merchandise.IsPurchased || !Game.Instance.CanPurchase(Merchandise.Master);
}
