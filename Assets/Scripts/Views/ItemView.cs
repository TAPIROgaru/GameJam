using ClickerGame.Models;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテム商品ビュー。
/// </summary>
public class ItemView : MerchandiseView<MerchandiseItem>
{
    [SerializeField]
    private Text _countText = null;

    /// <summary>
    /// 現在の項目を購入できるかどうか。.
    /// </summary>
    protected override bool CanPurchase => !Game.Instance.CanPurchase(Merchandise.Master);

    protected override void OnInitialize(MerchandiseItem merchandise)
    {
        base.OnInitialize(merchandise);
        merchandise.CountChanged += OnCounteChanged;
    }

    protected override void OnRelease(MerchandiseItem merchandise)
    {
        base.OnRelease(merchandise);
        merchandise.CountChanged -= OnCounteChanged;
    }

    /// <summary>
    /// アイテムの所有数が変更された。
    /// </summary>
    /// <param name="merchandise"></param>
    private void OnCounteChanged(MerchandiseItem merchandise) => OnMerchandiseChanged();

    /// <summary>
    /// <see cref="MerchandiseView{MerchandiseItem}.Merchandise" /> が更新されたので画面を再構築する。
    /// </summary>
    protected override void OnMerchandiseChanged()
    {
        base.OnMerchandiseChanged();

        if (Merchandise != null)
        {
            _countText.text = Merchandise.Count.ToString();
        }
        else
        {
            _countText.text = "";
        }
    }
}
