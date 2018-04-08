//////////////////////////////////////////////////////////////////////////
/// Author: Burnian
/// Date: 2018-3-22
/// Description: 场景管理器
//////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using Utils;
using Common;
using UnityEngine;
using Behaviors;
using Races;


class SceneManager : Updatable
{
    public static SceneManager Instance;
    public static void Init()
    {
        Instance = new SceneManager();
    }

    public SceneManager()
    {
        campAgents = new Dictionary<Camp, List<Agent>>();
        campAgents.Add(Camp.Tribe, new List<Agent>());
        campAgents.Add(Camp.Alliance, new List<Agent>());
        campAgents.Add(Camp.Neutral, new List<Agent>());

        DoLogic();
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left
        {
            Debug.Log("left click " + Input.mousePosition);
            //_heroAgent.GetComponent<Rigidbody2D>().velocity = Vector2.up;
            //_heroAgent.SetBehavior(BEHAVIOR_TYPE.CastSkill);
            _velocity = Vector2.zero;
        }

        if (Input.GetMouseButtonDown(1)) // right
        {
            Debug.Log("right click " + Input.mousePosition);
            _heroAgent.SetBehavior<Move>();
            BehaviorManager.Instance.blackboard.Set("endPos", Input.mousePosition, _heroAgent.behavior.tree.id);
        }

        if (Input.GetMouseButtonDown(2)) // middle
        {
            Debug.Log("middle click.");
            //BehaviorManager.Instance.ShowAllPoolIdleCount();
        }
    }


    void DoLogic()
    {
        // TODO: 将 prefab 打包到 assetbundle 中去，再加载
        //Debug.Log(Application.streamingAssetsPath);
        //var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "Prefabs"));
        //if (myLoadedAssetBundle == null)
        //{
        //    Debug.Log("Failed to load AssetBundle!");
        //    return;
        //}
        //var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("Character");
        //myLoadedAssetBundle.Unload(false);


        _prefab = Resources.Load("Prefabs/Character");

        //OnHeroSpawn<Human>();
        OnEnemySpawn<Orc>(5);
    }

    GameObject NewCharacter()
    {
        GameObject go = GameObject.Instantiate(_prefab) as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        go.transform.parent = canvas.transform;
        return go;
    }

    void OnHeroSpawn<T>()
    {
        var go = NewCharacter();
        go.name = "Hero";
        go.transform.localPosition = Vector3.zero;
        _heroAgent = go.GetComponent<Agent>();
        _heroAgent.SetRace<T>();
        _heroAgent.camp = Camp.Alliance;
        campAgents[_heroAgent.camp].Add(_heroAgent);
    }

    void OnEnemySpawn<T>(int count)
    {
        //for (int i=0; i<count; i++)
        //{
        //    var go = NewCharacter();
        //    go.name = typeof(T).Name;
        //    go.transform.localPosition = Vector3.zero;
        //    var agent = go.GetComponent<Agent>();
        //    agent.SetRace<T>();
        //}

        var go = NewCharacter();
        go.name = typeof(T).Name;
        go.transform.localPosition = new Vector3(-100, 0);
        var agent = go.GetComponent<Agent>();
        agent.camp = Camp.Tribe;
        agent.SetRace<T>();
        agent.MoveTo(go.transform.parent.TransformPoint(100, 0, 0));
        campAgents[agent.camp].Add(agent);


        var parallel = new Parallel(new BaseNode[] {
            BehaviorManager.Instance.GetBehavior<Patrol>().root,
            BehaviorManager.Instance.GetBehavior<Guard>().root,
        });

        BehaviorManager.Instance.RecycleBehavior(behavior);
        
        agent.SetBehavior(parallel);

        //go = NewCharacter();
        //go.name = typeof(T).Name;
        //go.transform.localPosition = new Vector3(100, 0);
        //agent = go.GetComponent<Agent>();
        //agent.camp = Common.Camp.Two;
        //agent.SetRace<T>();
        //agent.MoveTo(go.transform.parent.TransformPoint(-100, 0, 0));
    }


    public Dictionary<Camp, List<Agent>> campAgents;

    Vector2 _velocity;
    Object _prefab;
    Agent _heroAgent;
}
