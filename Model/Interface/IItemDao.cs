using Model.Base.Shop;


namespace Model.Interface;

public interface IItemDao
{
    public List<ShopItem> GetAllItems();
    public void AddItem(ShopItem item);
    
}