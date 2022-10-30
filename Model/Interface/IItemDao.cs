using Model.Base;
using Model.Enums;

namespace Model.Interface;

public interface IItemDao
{
    public List<ShopItem> GetAllItems();
    public void AddItem(ShopItem item);
    
}