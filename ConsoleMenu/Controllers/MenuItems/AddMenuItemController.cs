using PizzaLibrary;

public class AddMenuItemController
{
    private IMenuItemRepository _menuItemRepository;
    public MenuItem MenuItem { get; set; }

    public AddMenuItemController(string name, double price, string description, MenuType menuType, IMenuItemRepository menuItemRepository)
    {
        MenuItem = new MenuItem(name, price, description, menuType);
        _menuItemRepository = menuItemRepository;
    }

    public void AddMenuItem()
    {
        _menuItemRepository.AddMenuItem(MenuItem);
    }
}
