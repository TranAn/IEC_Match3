using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item
{
    public enum eNormalType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }

    public eNormalType ItemType;

    public void SetType(eNormalType type)
    {
        ItemType = type;
    }

    public void SetMinimumTypeByNeiboughCell(Cell cell)
    {
        int[] typeArr = new int[Enum.GetNames(typeof(eNormalType)).Length];

        Item itemUp = cell.NeighbourUp != null ? cell.NeighbourUp.Item : null;
        Item itemBottom = cell.NeighbourBottom != null ? cell.NeighbourBottom.Item : null;
        Item itemLeft = cell.NeighbourLeft != null ? cell.NeighbourLeft.Item : null;
        Item itemRight = cell.NeighbourRight != null ? cell.NeighbourRight.Item : null;

        if (itemUp != null && itemUp is NormalItem)
        {
            NormalItem normalItem = (NormalItem)itemUp;
            int itemUpVal = (int)normalItem.ItemType;
            typeArr[itemUpVal] = 1;
        }

        if (itemBottom != null && itemBottom is NormalItem)
        {
            NormalItem normalItem = (NormalItem)itemBottom;
            int itemUpVal = (int)normalItem.ItemType;
            typeArr[itemUpVal] = 1;
        }

        if (itemLeft != null && itemLeft is NormalItem)
        {
            NormalItem normalItem = (NormalItem)itemLeft;
            int itemUpVal = (int)normalItem.ItemType;
            typeArr[itemUpVal] = 1;
        }

        if (itemRight != null && itemRight is NormalItem)
        {
            NormalItem normalItem = (NormalItem)itemRight;
            int itemUpVal = (int)normalItem.ItemType;
            typeArr[itemUpVal] = 1;
        }

        for (int i = 0; i < typeArr.Length; i++)
        {
            if (typeArr[i] != 1)
            {
                int minimumItemVal = i;
                ItemType = (eNormalType)minimumItemVal;
                break;
            }
        }
    }

    public override void SetView()
    {
        base.SetView();
        ReSkinItem();
    }

    private void ReSkinItem()
    {
        NormalItemSkin m_normalItemSkin = Resources.Load<NormalItemSkin>(Constants.NORMAL_ITEM_SKIN);
        var spriteRenderer = View.GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
            return;

        switch (ItemType)
        {
            case eNormalType.TYPE_ONE:
                spriteRenderer.sprite = m_normalItemSkin.SkinOne;
                break;
            case eNormalType.TYPE_TWO:
                spriteRenderer.sprite = m_normalItemSkin.SkinTwo;
                break;
            case eNormalType.TYPE_THREE:
                spriteRenderer.sprite = m_normalItemSkin.SkinThree;
                break;
            case eNormalType.TYPE_FOUR:
                spriteRenderer.sprite = m_normalItemSkin.SkinFour;
                break;
            case eNormalType.TYPE_FIVE:
                spriteRenderer.sprite = m_normalItemSkin.SkinFive;
                break;
            case eNormalType.TYPE_SIX:
                spriteRenderer.sprite = m_normalItemSkin.SkinSix;
                break;
            case eNormalType.TYPE_SEVEN:
                spriteRenderer.sprite = m_normalItemSkin.SkinSeven;
                break;
        }
    }

    protected override string GetPrefabName()
    {
        string prefabname = string.Empty;
        switch (ItemType)
        {
            case eNormalType.TYPE_ONE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_ONE;
                break;
            case eNormalType.TYPE_TWO:
                prefabname = Constants.PREFAB_NORMAL_TYPE_TWO;
                break;
            case eNormalType.TYPE_THREE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_THREE;
                break;
            case eNormalType.TYPE_FOUR:
                prefabname = Constants.PREFAB_NORMAL_TYPE_FOUR;
                break;
            case eNormalType.TYPE_FIVE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_FIVE;
                break;
            case eNormalType.TYPE_SIX:
                prefabname = Constants.PREFAB_NORMAL_TYPE_SIX;
                break;
            case eNormalType.TYPE_SEVEN:
                prefabname = Constants.PREFAB_NORMAL_TYPE_SEVEN;
                break;
        }

        return prefabname;
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
