namespace SingletonPattern
{
    //Perfect singleton

    public class Singleton
    {
        public DateTime CreatedAt { get; }

        private Singleton() => CreatedAt = DateTime.Now;

        private static readonly Lazy<Singleton> Lazy = new(() => new Singleton());

        public static Singleton GetInstance() => Lazy.Value;

        public static int GetSomething => 10; //If you access this property, Instance will not be created and it will not be created until you explicitly call GetInstance()
    }

    //Almost perfect, but the instance will be created whenever you use this type for the first time

    //public class Singleton
    //{
    //    private static readonly Singleton Instance = new();

    //    public DateTime CreatedAt { get; }

    //    private Singleton() => CreatedAt = DateTime.Now;

    //    public static Singleton GetInstance() => Instance;

    //    public static int GetSomething => 10; //If you access this property, Instance will be created whether you want it or not
    //}

    //Too much boilerplate for so poor result considering using modern language;

    //public class Singleton
    //{
    //    private static volatile Singleton _instance; //remember about volatile

    //    private static readonly object PadLock = new();

    //    public DateTime CreatedAt { get; }

    //    private Singleton()
    //    {
    //        CreatedAt = DateTime.Now;
    //    }

    //    public static Singleton GetInstance()
    //    {
    //        if (_instance != null)
    //            return _instance;

    //        lock (PadLock)
    //        {
    //            if (_instance == null)
    //                _instance = new Singleton();
    //        }

    //        return _instance;
    //    }
    //}

    //poor performance

    // public class Singleton
    // {
    //     private static Singleton _instance;
    //     
    //     private static object _padLock = new object();
    //
    //     public DateTime CreatedAt { get; }
    //
    //     private Singleton()
    //     {
    //         CreatedAt = DateTime.Now;
    //     }
    //
    //     public static Singleton GetInstance()
    //     {
    //         lock (_padLock)
    //         {
    //             if (_instance == null)
    //                 _instance = new Singleton();
    //         }
    //
    //         return _instance;
    //     }
    // }

    //This approach will not work (reliably) in multhreaded applications

    // public class Singleton
    // {
    //     private static Singleton _instance;
    //
    //     public DateTime CreatedAt { get; }
    //
    //     private Singleton()
    //     {
    //         CreatedAt = DateTime.Now;
    //     }
    //
    //     public static Singleton GetInstance()
    //     {
    //         if (_instance == null)
    //             _instance = new Singleton();
    //
    //         return _instance;
    //     }
    // }
}