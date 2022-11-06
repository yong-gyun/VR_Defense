using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance { get { Init();  return s_instance; } }
    static Managers s_instance = null;
    
    UIManager _ui = new UIManager();
    GameManager _game = new GameManager();
    SceneManagerEx _scene = new SceneManagerEx();
    ResourceManager _resource = new ResourceManager();
    PoolManager _pool = new PoolManager();
    DataManager _data = new DataManager();
    SoundManager _sound = new SoundManager();

    public static UIManager UI { get { return Instance._ui; } }
    public static GameManager Game { get { return Instance._game; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static DataManager Data { get { return Instance._data; } }
    public static SoundManager Sound { get { return Instance._sound; } }

    void Start()
    {
        Init();
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if (go == null)
                go = new GameObject { name = "@Managers" };

            s_instance = Util.GetOrAddComponent<Managers>(go);
            DontDestroyOnLoad(go);

            Data.Init();
            Pool.Init();
            Sound.Init();
        }
    }
}
