using ClickerGame.Models;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スコア表示用ビュー。
/// </summary>
public class ScoreView : MonoBehaviour
{
    /// <summary>
    /// スコア表示テキスト。
    /// </summary>
    [SerializeField]
    private Text _scoreText = null;

    /// <summary>
    /// 表示する通貨型。
    /// </summary>
    public CurrencyType CurrencyType => _currencyType;
    [SerializeField]
    private CurrencyType _currencyType = CurrencyType.None;

    /// <summary>
    /// 表示する通貨インベントリー。
    /// </summary>
    public CurrencyInventory DataSource
    {
        get => _dataSource;
        set
        {
            if (_dataSource != null)
            {
                _dataSource.Changed -= OnDataSourceChanged;
            }
            _dataSource = value;
            if (_dataSource != null)
            {
                _dataSource.Changed += OnDataSourceChanged;
            }
        }
    }
    private CurrencyInventory _dataSource;

    /// <summary>
    /// 表示中の通貨。
    /// </summary>
    public Currency Currency
    {
        get => _currency;
        private set
        {
            _currency = value;
            var q = _dataSource.GetQuantity(CurrencyType);
            _scoreText.text = q.ToString("F") + CurrencyType;
        }
    }
    private Currency _currency;

    private void Start()
    {
        Currency = new Currency(CurrencyType, 0);
    }

    private void OnDataSourceChanged(Currency currency)
    {
        if (currency.Type == CurrencyType)
        {
            Currency = currency;
        }
    }
}
