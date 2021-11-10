using ClickerGame.Masters;
using System.Collections.Generic;
using UnityEngine;

partial class Game
{
    [SerializeField]
    private ItemMaster[] _items;

    [SerializeField]
    private EnhancerMaster[] _enhancers;

    /// <summary>
    /// アイテム一覧。
    /// </summary>
    public IEnumerable<ItemMaster> ItemMasters => _items;

    /// <summary>
    /// アイテム強化一覧。
    /// </summary>
    public IEnumerable<EnhancerMaster> EnhancerMasters => _enhancers;
}