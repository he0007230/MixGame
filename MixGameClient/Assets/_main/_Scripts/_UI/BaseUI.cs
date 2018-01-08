using UnityEngine;
using System.Collections;
using FairyGUI;

public class BaseUI : MonoBehaviour {

    public GComponent _mainView;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void InitUI(string pkgPath,string pkgName)
    {
        //加载UI
        GRoot.inst.SetContentScaleFactor(640, 360
            , UIContentScaler.ScreenMatchMode.MatchHeight);
        UIPackage.AddPackage(pkgPath);
        _mainView = UIPackage.CreateObject(pkgName, "main").asCom;
        _mainView.fairyBatching = true;
        _mainView.SetSize(GRoot.inst.width, GRoot.inst.height);
        _mainView.AddRelation(GRoot.inst, RelationType.Size);
        GRoot.inst.AddChild(_mainView);
    }
}
