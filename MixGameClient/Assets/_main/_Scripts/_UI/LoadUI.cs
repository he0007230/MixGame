using UnityEngine;
using System.Collections;
using FairyGUI;
using LuaInterface;

public class LoadUI : MonoBehaviour {

    //private GComponent _mainView;
    LuaState lua = null;
    private string strLog = ""; 

	// Use this for initialization
	void Start () {
        InitUISetting();
	
	}


    void Log(string msg, string stackTrace, LogType type)
    {
        strLog += msg;
        strLog += "\r\n";
    }


    private void InitUISetting()
    {

        //加载UI
        //GRoot.inst.SetContentScaleFactor(640, 360);
        //UIPackage.AddPackage("FairyGUI/LoadUI/_load");
        //_mainView = UIPackage.CreateObject("_load", "main").asCom;
        //_mainView.fairyBatching = true;
        //_mainView.SetSize(GRoot.inst.width, GRoot.inst.height);
        //_mainView.AddRelation(GRoot.inst, RelationType.Size);
        //GRoot.inst.AddChild(_mainView);

        //开始设置UI组件

#if UNITY_5 || UNITY_2017		
        Application.logMessageReceived += Log;
#else
        Application.RegisterLogCallback(Log);
#endif   
        new LuaResLoader();
        lua = new LuaState();
        lua.Start();
        string fullPath = Application.dataPath + "\\Lua";
        lua.AddSearchPath(fullPath);
        lua.LogGC = true;
        LuaBinder.Bind(lua);
        DelegateFactory.Init();
        lua.Require("test");
        LuaFunction func = lua["initLoadUI"] as LuaFunction;
        func.Call();
        func.Dispose();
        //Debug.Log(strLog);

    }


	
	// Update is called once per frame
	void Update () {
	
	}

    void OnApplicationQuit()
    {
        lua.Dispose();
        lua = null;
#if UNITY_5 || UNITY_2017	
        Application.logMessageReceived -= Log;
#else
        Application.RegisterLogCallback(null);
#endif 
    }
}
