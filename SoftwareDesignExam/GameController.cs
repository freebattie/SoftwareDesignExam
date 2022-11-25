using Model.Base.Enemies;
using Model.Base.Enums;
using Model.Base.Player;
using Model.Base.Shop;
using Model.Base.ViewModel;
using Model.Decorator.Abstract;
using Model.Factory;
using Model.Interface;


namespace SoftwareDesignExam {

    /// <summary>
    /// main program, this is where game loop is handeled
    /// draw : draws to the console
    /// hadelinput : handels palyer input
    /// HandelGameMecknaics: handels all logic like saving, updating health ect
    /// </summary>
    public class Game {

        #region Private fileds
        private string _input = "";
        private bool _gameIsRunning = true;
        public IUserDao _userDao;
        private IUI _ui;
        private ViewModel _vm;
        private Dictionary<Menu, Delegate>? _gameMeckanics;
        private Menu _lastMenu = Menu.MAINMENU;
        private Menu _menu = Menu.MAINMENU;
        private IUpdateManagar _updater;
        private IItemDao _itemDao;
        
        #endregion

        #region Constructor
        public Game(IItemDao itemDao, IUserDao userDao, IUpdateManagar manager, IUI ui) {
            _itemDao = itemDao;
            _userDao = userDao;
            _updater = manager;
            _ui = ui;
            _vm = new ViewModel();  
            GameInit();
              
        }


        #endregion

        #region setup
        private void GameInit() { 
           
            _gameMeckanics = new Dictionary<Menu, Delegate>();
           
            _vm = new ViewModel();
            var _allItems = _itemDao?.GetAllItems();
            if (_allItems != null) {
                ShopItemSpawner.SetAllShopItems(_allItems);
                _vm.Items = _allItems;
            }
           
            
            _gameMeckanics.Add(Menu.ERROR, HandelErrorMeckanics);
            _gameMeckanics.Add(Menu.LOGIN, HandelLoginMeckanics);
            _gameMeckanics.Add(Menu.MAINMENU, HandelMainMenuMeckanics);
            _gameMeckanics.Add(Menu.SHOP, HandelShopMeckanics);
            _gameMeckanics.Add(Menu.WEAPONSHOP, HandelWeaponShopMeckanics);
            _gameMeckanics.Add(Menu.ITEMSHOP, HandelItemsShopMeckanics);
            _gameMeckanics.Add(Menu.NOMONEY, HandelNoMoneyShopMeckanics);
            _gameMeckanics.Add(Menu.ATTACK, HandelAttackMeckanics);
            _gameMeckanics.Add(Menu.INVETORY, HandelInventoryMeckanics);
            _gameMeckanics.Add(Menu.NEXTROOM, HandelNextRoomMeckanics);
            _gameMeckanics.Add(Menu.HIGHSCORE, HandelMaxScoreMeckanics);
            _gameMeckanics.Add(Menu.ENEMYTURN, HandelRoundUpdateMeckanics);
            _gameMeckanics.Add(Menu.GAMEOVER, HandelGameOverMeckanics);
            _gameMeckanics.Add(Menu.DOWNLOAD, HandelDownloadMeckanics);
        }

        #endregion

        #region Game flow

        /// <summary>
        /// game loop
        /// </summary>
        public void Update() {
            while (_gameIsRunning) {

                Draw();
                HandelInput();
                HandelGameMecknaics();

            }
        }
        /// <summary>
        /// tegner til Console basert på valgt Meny
        /// </summary>
        private void Draw() {
            if (_vm != null) {
                _ui.SetActiveViewModel(_vm);
                _ui.Draw(_menu);
            }
            
        }
        /// <summary>
        /// ahnterer all input bassert på valgt Meny
        /// </summary>
        private void HandelInput() {
            if (_ui != null) {
                _input = _ui.HandelPlayerInput(_menu);
                HandelErrorInput();
            }
        }
        /// <summary>
        /// håntere all logikk basert på menu valg
        /// </summary>
        public void HandelGameMecknaics() {
            
          if(_gameMeckanics != null) {
                _gameMeckanics[_menu].DynamicInvoke();
            }
        }
        #endregion

        #region Game Meckanics
        private void HandelInventoryMeckanics() {
            _lastMenu = _menu;
            if (_vm != null) {
                InventorySelection();
            }

        }

        private void InventorySelection() {
            if (int.Parse(_input) <= _vm.Playerhandler.GetInventory().Count &&
                           int.Parse(_input) > 0) {
                SelectActiveItems();

            }
            else if (int.Parse(_input) == 0) {
                _vm.Playerhandler.EquiptAllActiveItems();
                _menu = Menu.ATTACK;

            }
            else
                _menu = Menu.ERROR;
        }

        private void SelectActiveItems() {
            if (_vm != null) {
                var items = _vm.Playerhandler.GetInventory();

                var item = items[int.Parse(_input) - 1];
                _vm.Playerhandler.RemoveItem(item);
                _vm.Playerhandler.SetActiveGearItem(item.GearSpot, item);
            }
           
        }

        private void HandelMaxScoreMeckanics() {
            _lastMenu = _menu;
            _menu = Menu.MAINMENU;
        }

        private void HandelNextRoomMeckanics() {
            _lastMenu = _menu;
            if (_input == "1") {
                CreateNextRoom();
            }
            else
                _menu = Menu.MAINMENU;
        }

        private void CreateNextRoom() {
            Random random = new Random();
            int nrEnemies = random.Next(1, 3);
            int level = random.Next(1, _vm.Playerhandler.GetUser().Level);
           
            _vm.Enemies = EnemySpawner.SpawnEnemies(nrEnemies, level);
            _vm.Room++;
            if (_vm.Room % 3 == 0) {
                _menu = Menu.SHOP;
            }
            else
                _menu = Menu.ATTACK;

        }

        private void HandelRoundUpdateMeckanics() {
            if(_vm != null) {
                if (!_vm.Playerhandler.PlayerIsAlive()) {
                    SavePlayerToDB();
                    _menu = Menu.GAMEOVER;
                }
                else if (_vm.Enemies.Count == 0) {

                    _menu = Menu.NEXTROOM;
                }
                else
                    _menu = Menu.ATTACK;
            }
            
        }

        private void HandelErrorInput() {
            if (_input == "ERROR" && _menu != Menu.ERROR) {
                _lastMenu = _menu;
                _menu = Menu.ERROR;
                _input = "";
            }
        }
        private void HandelLoginMeckanics() {
            _lastMenu = _menu;
            HandelSettingActivePlayer();
            _menu = Menu.SHOP;
        }


        private void HandelMainMenuMeckanics() {
            _lastMenu = _menu;
            HandelMenuSelection();
            HandleExstra();
        }

        private void HandelErrorMeckanics() {
            if (_input == "1") {
                _menu = _lastMenu;
            }
            else if (_input == "2") {
                _gameIsRunning = false;
            }

        }
        private void HandelGameOverMeckanics() {
            if (_vm.Playerhandler.PlayerIsAlive()) { SavePlayerToDB();}
            HandelMenuSelection();



        }
        private void HandelDownloadMeckanics() {

            if (_input == "0") { 
                _menu = Menu.MAINMENU;

            }
            else if (_input == "1") {
                _updater.Start();
                _updater.Close();
            }



        }

        private void HandelSettingActivePlayer() {
           
            _vm.Playerhandler.SetUser(_userDao.GetUser(_input));
            var val = _vm.Playerhandler.GetPlayer()?.GetLevel();
            if (val != null) {
                var weapons = WeaponFactory.GenerateOneOfEachWeaponRandom((int)val);
                _vm.Weapons = weapons;
                _vm.Users = _userDao.GetAllUsers();
            }
            
            


        }
        private void HandelShopMeckanics() {
            _lastMenu = _menu;
           
            if (_input == "1") {
                _menu = Menu.WEAPONSHOP;
            }
            else if (_input == "2") {
                _menu = Menu.ITEMSHOP;
            }
            else if (_input == "0") {
                _menu = Menu.ATTACK;
            }
        }
        private void HandelWeaponShopMeckanics() {
            _lastMenu = _menu;
            var val = _vm.Playerhandler.GetPlayer()?.GetLevel();
            if (val != null) {
                var weapons = WeaponFactory.GenerateOneOfEachWeaponRandom((int)val);
                _vm.Weapons = weapons;
            }
                int index = int.Parse(_input) - 1;

            if (index < _vm.Weapons.Count && index != -1) {
                var weapon = _vm.Weapons[index];


                if (_vm.Playerhandler.CanAffordIt(weapon.Price)) {
                    _vm.Playerhandler?.GetPlayer()?.SetWeapon(weapon);
                    _vm.Playerhandler.Money -= weapon.Price;
                }
                else {
                    _menu = Menu.NOMONEY;
                }
            }
            else if (_input == "0") {
                _menu = Menu.SHOP;
            }
        }
        private void HandelItemsShopMeckanics() {
            _lastMenu = _menu;
            int index = int.Parse(_input) - 1;

            if (index < _vm.Items.Count && index != -1) {
                var item = _vm.Items[index];
                if (_vm.Playerhandler.CanAffordIt(item.Price)) {
                    _vm.Playerhandler.GetInventory().Add(item);
                    _vm.Playerhandler.Money -= item.Price;

                }
                else {
                    _menu = Menu.NOMONEY;
                }

            }
            else if (_input == "0") {
                _menu = Menu.SHOP;
            }
            
        }
        private void HandelNoMoneyShopMeckanics() {

            _menu = _lastMenu;
        }
        private void HandelAttackMeckanics() {
            // se om du har valgt å angripe en fiende eller gå til inventory
            _lastMenu = _menu;
            if (int.Parse(_input) > 0 && int.Parse(_input) <= _vm.Enemies.Count) {
                AttackSelectedTarget();
                HandelEnemiesTurn();
                //TODO: add leves some how

                _menu = Menu.ENEMYTURN;
            }
            else if (int.Parse(_input) == 0) {
                _menu = Menu.INVETORY;
            }
            else
                _menu = Menu.ERROR;

            


        }

        private void PlayerStatsUpdate() {
            var user = _vm.Playerhandler.GetUser();
            user.CurrentScore += 100;
            _vm.Playerhandler.Money += 100;
            user.Level += 1;
            _vm.Playerhandler.SetUser(user);
            _vm.Playerhandler.GetPlayer()?.SetLevel(user.Level);
        }

        private void AttackSelectedTarget() {
            var index = int.Parse(_input) - 1;
            _vm.Playerhandler.SetTarget(_vm.Enemies[index]);
            _vm.Playerhandler.Attack();
        }
        private void HandelEnemiesTurn() {
            List<CharacterInfo> remove = new();
            foreach (var enemy in _vm.Enemies) {
                if (enemy.GetHealth() <= 0) {
                    remove.Add(enemy);


                }
                else {
                    var player = _vm.Playerhandler.GetPlayer();
                    if (player != null) {
                        enemy.Attack(player);
                        enemy.GetWeapon().SetTarget(player);
                    }
                }


            }
            foreach (var enemy in remove) {
                _vm.Enemies.Remove(enemy);
                PlayerStatsUpdate();
            }
        }

        private void HandleExstra() {
            if (_input == "3") {
                _menu = Menu.HIGHSCORE;
            }
            if (_input == "4") {
                _menu = Menu.DOWNLOAD;
            }

        }
        private void HandelMenuSelection() {
            _lastMenu = _menu;
            _vm.Users = _userDao.GetAllUsers();
            if (_input == "1") {
                _vm.Playerhandler = new PlayerHandler();
              
                _vm.Enemies = EnemySpawner.SpawnEnemies(1, 1);
                _vm.Playerhandler.GetPlayer()?.SetWeapon(WeaponFactory.GenerateRandomWeapon(1));
                _menu = Menu.LOGIN;

            }
            else if (_input == "2") {
                SavePlayerToDB();
                _gameIsRunning = false;
            }

        }

        private void SavePlayerToDB() {
            var user = _vm.Playerhandler.GetUser();
            _userDao.UpdateUser(user, user.Name);
        }



    }
    #endregion
}