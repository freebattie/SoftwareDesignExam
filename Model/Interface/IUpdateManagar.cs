namespace Model.Interface {
    public  interface IUpdateManagar {
        FileSystemWatcher Watcher { get; }

        void Close();
        void Start();
    }
}