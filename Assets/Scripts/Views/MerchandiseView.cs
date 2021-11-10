using System;
using ClickerGame.Models;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 商品ビュー
/// </summary>
/// <typeparam name="TMerchandise"></typeparam>
public abstract class MerchandiseView<TMerchandise> : MonoBehaviour
    where TMerchandise : Merchandise
{
    [SerializeField]
    private Button _button = null;

    [SerializeField]
    private GameObject _maskObject = null;

    [SerializeField]
    private Image _image = null;

    [SerializeField]
    private Text _nameText = null;

    [SerializeField]
    private Text _priceText = null;

    /// <summary>
    /// 商品データ。
    /// </summary>
    public TMerchandise Merchandise
    {
        get => _item;
        set
        {
            if (_item != null)
            {
                OnRelease(_item);
            }
            if (value != null)
            {
                OnInitialize(value);
            }

            _item = value;
            OnMerchandiseChanged();
        }
    }

    private TMerchandise _item;

    /// <summary>
    /// この商品が選択されたときに発生するイベント。
    /// </summary>
    public event Action<TMerchandise> ItemSelected;

    /// <summary>
    /// 現在の項目を購入できるかどうか。
    /// </summary>
    protected abstract bool CanPurchase { get; } 

    private void Update()
    {
        _maskObject.SetActive(CanPurchase);
    }

    void Start()
    {
        var e = new Button.ButtonClickedEvent();
        e.AddListener(() =>
        {
            ItemSelected?.Invoke(_item);
        });
        _button.onClick = e;
    }

    /// <summary>
    /// 商品を初期化する。
    /// </summary>
    /// <param name="merchandise">初期化対象の商品。</param>
    protected virtual void OnInitialize(TMerchandise merchandise)
    {
        merchandise.PriceChanged += OnPriceChanged;
    }

    /// <summary>
    /// 商品を解除する。
    /// </summary>
    /// <param name="merchandise">解除対象の商品。</param>
    protected virtual void OnRelease(TMerchandise merchandise)
    {
        merchandise.PriceChanged -= OnPriceChanged;
    }

    private void OnPriceChanged(Merchandise merchandise) => OnMerchandiseChanged();

    /// <summary>
    /// <see cref="Merchandise" /> が更新されたので画面を再構築する。
    /// </summary>
    protected virtual void OnMerchandiseChanged()
    {
        if (Merchandise != null)
        {
            _nameText.text = Merchandise.Name;
            _image.sprite = Merchandise.Sprite;

            var price = Merchandise.Price;
            _priceText.text =
                $"{price.Quantity}({price.Type})";
        }
        else
        {
            _nameText.text = "";
            _priceText.text = "";
        }
    }
}
