using ClickerGame.Masters;
using ClickerGame.Models;
using System;
using System.IO;
using System.Linq;
using UnityEngine;

/// <summary>
/// ゲーム全体の管理クラス。
/// </summary>
public partial class Game : MonoBehaviour
{
    /// <summary>
    /// インスタンスを取得する。
    /// </summary>
    public static Game Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Game>();
            }
            return _instance;
        }
    }
    private static Game _instance;

    /// <summary>
    /// 生産管理。
    /// </summary>
    public Production Production { get; } = new Production(new ItemInventory(), new EnhancerInventory());

    /// <summary>
    /// 通貨用インベントリー。
    /// </summary>
    public CurrencyInventory CashInventory { get; } = new CurrencyInventory();

    /// <summary>
    /// アイテム用インベントリー。
    /// </summary>
    public ItemInventory ItemInventory => Production.ItemInventory;

    /// <summary>
    /// 強化用インベントリー。
    /// </summary>
    public EnhancerInventory EnhancerInventory => Production.EnhancerInventory;

    /// <summary>
    /// アイテム購入を試みる。
    /// </summary>
    /// <param name="item">購入するアイテム。</param>
    /// <returns>購入出来たら true。</returns>
    public bool TryPurchase(ItemMaster item)
    {
        if (!CanPurchase(item)) return false;

        ItemInventory.Add(item);
        CashInventory.Add(item.Price.Type, -item.Price.Quantity);
        return true;
    }

    /// <summary>
    /// 強化購入を試みる。
    /// </summary>
    /// <param name="item">購入するアイテム。</param>
    /// <returns>購入出来たら true。</returns>
    public bool TryPurchase(EnhancerMaster enhancer)
    {
        if (!CanPurchase(enhancer)) return false;

        EnhancerInventory.Add(enhancer);
        CashInventory.Add(enhancer.Price.Type, -enhancer.Price.Quantity);
        return true;
    }

    /// <summary>
    /// アイテムを購入できるかどうか。
    /// </summary>
    /// <param name="item">購入できるかどうか調べるアイテム。</param>
    /// <returns>購入できるなら true。そうでなければ false。</returns>
    public bool CanPurchase(ItemMaster item)
    {
        if (item == null) { throw new ArgumentNullException(nameof(item)); }
        var cash = CashInventory.GetQuantity(item.Price.Type);
        return cash >= ItemInventory.GetPrice(item).Quantity;
    }

    /// <summary>
    /// 強化を購入できるかどうか。
    /// </summary>
    /// <param name="enhancer">購入できるかどうか調べる強化。</param>
    /// <returns>購入できるなら true。そうでなければ false。</returns>
    public bool CanPurchase(EnhancerMaster enhancer)
    {
        if (enhancer == null) { throw new ArgumentNullException(nameof(enhancer)); }
        var cash = CashInventory.GetQuantity(enhancer.Price.Type);
        return cash >= enhancer.Price.Quantity;
    }

    private void Start()
    {
    }

    private void Update()
    {
        foreach (var kv in Production.ProductivitiesPerSec)
        {
            CashInventory.Add(kv.Key, kv.Value * Time.deltaTime);
        }
    }
}
