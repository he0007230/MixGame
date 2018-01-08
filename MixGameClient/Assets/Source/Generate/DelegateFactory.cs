﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using System.Collections.Generic;
using LuaInterface;

public class DelegateFactory
{
	public delegate Delegate DelegateCreate(LuaFunction func, LuaTable self, bool flag);
	public static Dictionary<Type, DelegateCreate> dict = new Dictionary<Type, DelegateCreate>();
	static DelegateFactory factory = new DelegateFactory();

	public static void Init()
	{
		Register();
	}

	public static void Register()
	{
		dict.Clear();
		dict.Add(typeof(System.Action), factory.System_Action);
		dict.Add(typeof(UnityEngine.Events.UnityAction), factory.UnityEngine_Events_UnityAction);
		dict.Add(typeof(System.Predicate<int>), factory.System_Predicate_int);
		dict.Add(typeof(System.Action<int>), factory.System_Action_int);
		dict.Add(typeof(System.Comparison<int>), factory.System_Comparison_int);
		dict.Add(typeof(System.Func<int,int>), factory.System_Func_int_int);
		dict.Add(typeof(FairyGUI.EventCallback1), factory.FairyGUI_EventCallback1);
		dict.Add(typeof(FairyGUI.EventCallback0), factory.FairyGUI_EventCallback0);
		dict.Add(typeof(FairyGUI.ListItemRenderer), factory.FairyGUI_ListItemRenderer);
		dict.Add(typeof(FairyGUI.ListItemProvider), factory.FairyGUI_ListItemProvider);
		dict.Add(typeof(FairyGUI.PlayCompleteCallback), factory.FairyGUI_PlayCompleteCallback);
		dict.Add(typeof(FairyGUI.TransitionHook), factory.FairyGUI_TransitionHook);
		dict.Add(typeof(FairyGUI.UIPackage.LoadResource), factory.FairyGUI_UIPackage_LoadResource);
		dict.Add(typeof(FairyGUI.UIPackage.CreateObjectCallback), factory.FairyGUI_UIPackage_CreateObjectCallback);
		dict.Add(typeof(FairyGUI.GObjectPool.InitCallbackDelegate), factory.FairyGUI_GObjectPool_InitCallbackDelegate);
		dict.Add(typeof(FairyGUI.TimerCallback), factory.FairyGUI_TimerCallback);
		dict.Add(typeof(UnityEngine.Application.LogCallback), factory.UnityEngine_Application_LogCallback);
		dict.Add(typeof(UnityEngine.AudioClip.PCMReaderCallback), factory.UnityEngine_AudioClip_PCMReaderCallback);
		dict.Add(typeof(UnityEngine.AudioClip.PCMSetPositionCallback), factory.UnityEngine_AudioClip_PCMSetPositionCallback);

		DelegateTraits<System.Action>.Init(factory.System_Action);
		DelegateTraits<UnityEngine.Events.UnityAction>.Init(factory.UnityEngine_Events_UnityAction);
		DelegateTraits<System.Predicate<int>>.Init(factory.System_Predicate_int);
		DelegateTraits<System.Action<int>>.Init(factory.System_Action_int);
		DelegateTraits<System.Comparison<int>>.Init(factory.System_Comparison_int);
		DelegateTraits<System.Func<int,int>>.Init(factory.System_Func_int_int);
		DelegateTraits<FairyGUI.EventCallback1>.Init(factory.FairyGUI_EventCallback1);
		DelegateTraits<FairyGUI.EventCallback0>.Init(factory.FairyGUI_EventCallback0);
		DelegateTraits<FairyGUI.ListItemRenderer>.Init(factory.FairyGUI_ListItemRenderer);
		DelegateTraits<FairyGUI.ListItemProvider>.Init(factory.FairyGUI_ListItemProvider);
		DelegateTraits<FairyGUI.PlayCompleteCallback>.Init(factory.FairyGUI_PlayCompleteCallback);
		DelegateTraits<FairyGUI.TransitionHook>.Init(factory.FairyGUI_TransitionHook);
		DelegateTraits<FairyGUI.UIPackage.LoadResource>.Init(factory.FairyGUI_UIPackage_LoadResource);
		DelegateTraits<FairyGUI.UIPackage.CreateObjectCallback>.Init(factory.FairyGUI_UIPackage_CreateObjectCallback);
		DelegateTraits<FairyGUI.GObjectPool.InitCallbackDelegate>.Init(factory.FairyGUI_GObjectPool_InitCallbackDelegate);
		DelegateTraits<FairyGUI.TimerCallback>.Init(factory.FairyGUI_TimerCallback);
		DelegateTraits<UnityEngine.Application.LogCallback>.Init(factory.UnityEngine_Application_LogCallback);
		DelegateTraits<UnityEngine.AudioClip.PCMReaderCallback>.Init(factory.UnityEngine_AudioClip_PCMReaderCallback);
		DelegateTraits<UnityEngine.AudioClip.PCMSetPositionCallback>.Init(factory.UnityEngine_AudioClip_PCMSetPositionCallback);

		TypeTraits<System.Action>.Init(factory.Check_System_Action);
		TypeTraits<UnityEngine.Events.UnityAction>.Init(factory.Check_UnityEngine_Events_UnityAction);
		TypeTraits<System.Predicate<int>>.Init(factory.Check_System_Predicate_int);
		TypeTraits<System.Action<int>>.Init(factory.Check_System_Action_int);
		TypeTraits<System.Comparison<int>>.Init(factory.Check_System_Comparison_int);
		TypeTraits<System.Func<int,int>>.Init(factory.Check_System_Func_int_int);
		TypeTraits<FairyGUI.EventCallback1>.Init(factory.Check_FairyGUI_EventCallback1);
		TypeTraits<FairyGUI.EventCallback0>.Init(factory.Check_FairyGUI_EventCallback0);
		TypeTraits<FairyGUI.ListItemRenderer>.Init(factory.Check_FairyGUI_ListItemRenderer);
		TypeTraits<FairyGUI.ListItemProvider>.Init(factory.Check_FairyGUI_ListItemProvider);
		TypeTraits<FairyGUI.PlayCompleteCallback>.Init(factory.Check_FairyGUI_PlayCompleteCallback);
		TypeTraits<FairyGUI.TransitionHook>.Init(factory.Check_FairyGUI_TransitionHook);
		TypeTraits<FairyGUI.UIPackage.LoadResource>.Init(factory.Check_FairyGUI_UIPackage_LoadResource);
		TypeTraits<FairyGUI.UIPackage.CreateObjectCallback>.Init(factory.Check_FairyGUI_UIPackage_CreateObjectCallback);
		TypeTraits<FairyGUI.GObjectPool.InitCallbackDelegate>.Init(factory.Check_FairyGUI_GObjectPool_InitCallbackDelegate);
		TypeTraits<FairyGUI.TimerCallback>.Init(factory.Check_FairyGUI_TimerCallback);
		TypeTraits<UnityEngine.Application.LogCallback>.Init(factory.Check_UnityEngine_Application_LogCallback);
		TypeTraits<UnityEngine.AudioClip.PCMReaderCallback>.Init(factory.Check_UnityEngine_AudioClip_PCMReaderCallback);
		TypeTraits<UnityEngine.AudioClip.PCMSetPositionCallback>.Init(factory.Check_UnityEngine_AudioClip_PCMSetPositionCallback);

		StackTraits<System.Action>.Push = factory.Push_System_Action;
		StackTraits<UnityEngine.Events.UnityAction>.Push = factory.Push_UnityEngine_Events_UnityAction;
		StackTraits<System.Predicate<int>>.Push = factory.Push_System_Predicate_int;
		StackTraits<System.Action<int>>.Push = factory.Push_System_Action_int;
		StackTraits<System.Comparison<int>>.Push = factory.Push_System_Comparison_int;
		StackTraits<System.Func<int,int>>.Push = factory.Push_System_Func_int_int;
		StackTraits<FairyGUI.EventCallback1>.Push = factory.Push_FairyGUI_EventCallback1;
		StackTraits<FairyGUI.EventCallback0>.Push = factory.Push_FairyGUI_EventCallback0;
		StackTraits<FairyGUI.ListItemRenderer>.Push = factory.Push_FairyGUI_ListItemRenderer;
		StackTraits<FairyGUI.ListItemProvider>.Push = factory.Push_FairyGUI_ListItemProvider;
		StackTraits<FairyGUI.PlayCompleteCallback>.Push = factory.Push_FairyGUI_PlayCompleteCallback;
		StackTraits<FairyGUI.TransitionHook>.Push = factory.Push_FairyGUI_TransitionHook;
		StackTraits<FairyGUI.UIPackage.LoadResource>.Push = factory.Push_FairyGUI_UIPackage_LoadResource;
		StackTraits<FairyGUI.UIPackage.CreateObjectCallback>.Push = factory.Push_FairyGUI_UIPackage_CreateObjectCallback;
		StackTraits<FairyGUI.GObjectPool.InitCallbackDelegate>.Push = factory.Push_FairyGUI_GObjectPool_InitCallbackDelegate;
		StackTraits<FairyGUI.TimerCallback>.Push = factory.Push_FairyGUI_TimerCallback;
		StackTraits<UnityEngine.Application.LogCallback>.Push = factory.Push_UnityEngine_Application_LogCallback;
		StackTraits<UnityEngine.AudioClip.PCMReaderCallback>.Push = factory.Push_UnityEngine_AudioClip_PCMReaderCallback;
		StackTraits<UnityEngine.AudioClip.PCMSetPositionCallback>.Push = factory.Push_UnityEngine_AudioClip_PCMSetPositionCallback;
	}
    
    public static Delegate CreateDelegate(Type t, LuaFunction func = null)
    {
        DelegateCreate Create = null;

        if (!dict.TryGetValue(t, out Create))
        {
            throw new LuaException(string.Format("Delegate {0} not register", LuaMisc.GetTypeName(t)));            
        }

        if (func != null)
        {
            LuaState state = func.GetLuaState();
            LuaDelegate target = state.GetLuaDelegate(func);
            
            if (target != null)
            {
                return Delegate.CreateDelegate(t, target, target.method);
            }  
            else
            {
                Delegate d = Create(func, null, false);
                target = d.Target as LuaDelegate;
                state.AddLuaDelegate(target, func);
                return d;
            }       
        }

        return Create(null, null, false);        
    }
    
    public static Delegate CreateDelegate(Type t, LuaFunction func, LuaTable self)
    {
        DelegateCreate Create = null;

        if (!dict.TryGetValue(t, out Create))
        {
            throw new LuaException(string.Format("Delegate {0} not register", LuaMisc.GetTypeName(t)));
        }

        if (func != null)
        {
            LuaState state = func.GetLuaState();
            LuaDelegate target = state.GetLuaDelegate(func, self);

            if (target != null)
            {
                return Delegate.CreateDelegate(t, target, target.method);
            }
            else
            {
                Delegate d = Create(func, self, true);
                target = d.Target as LuaDelegate;
                state.AddLuaDelegate(target, func, self);
                return d;
            }
        }

        return Create(null, null, true);
    }
    
    public static Delegate RemoveDelegate(Delegate obj, LuaFunction func)
    {
        LuaState state = func.GetLuaState();
        Delegate[] ds = obj.GetInvocationList();

        for (int i = 0; i < ds.Length; i++)
        {
            LuaDelegate ld = ds[i].Target as LuaDelegate;

            if (ld != null && ld.func == func)
            {
                obj = Delegate.Remove(obj, ds[i]);
                state.DelayDispose(ld.func);
                break;
            }
        }

        return obj;
    }
    
    public static Delegate RemoveDelegate(Delegate obj, Delegate dg)
    {
        LuaDelegate remove = dg.Target as LuaDelegate;

        if (remove == null)
        {
            obj = Delegate.Remove(obj, dg);
            return obj;
        }

        LuaState state = remove.func.GetLuaState();
        Delegate[] ds = obj.GetInvocationList();        

        for (int i = 0; i < ds.Length; i++)
        {
            LuaDelegate ld = ds[i].Target as LuaDelegate;

            if (ld != null && ld == remove)
            {
                obj = Delegate.Remove(obj, ds[i]);
                state.DelayDispose(ld.func);
                state.DelayDispose(ld.self);
                break;
            }
        }

        return obj;
    }

	class System_Action_Event : LuaDelegate
	{
		public System_Action_Event(LuaFunction func) : base(func) { }
		public System_Action_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public System.Action System_Action(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			System_Action_Event target = new System_Action_Event(func);
			System.Action d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_Event target = new System_Action_Event(func, self);
			System.Action d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Action(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Action), L, pos);
	}

	void Push_System_Action(IntPtr L, System.Action o)
	{
		ToLua.Push(L, o);
	}

	class UnityEngine_Events_UnityAction_Event : LuaDelegate
	{
		public UnityEngine_Events_UnityAction_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Events_UnityAction_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public UnityEngine.Events.UnityAction UnityEngine_Events_UnityAction(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Events.UnityAction fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Events_UnityAction_Event target = new UnityEngine_Events_UnityAction_Event(func);
			UnityEngine.Events.UnityAction d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Events_UnityAction_Event target = new UnityEngine_Events_UnityAction_Event(func, self);
			UnityEngine.Events.UnityAction d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_UnityEngine_Events_UnityAction(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(UnityEngine.Events.UnityAction), L, pos);
	}

	void Push_UnityEngine_Events_UnityAction(IntPtr L, UnityEngine.Events.UnityAction o)
	{
		ToLua.Push(L, o);
	}

	class System_Predicate_int_Event : LuaDelegate
	{
		public System_Predicate_int_Event(LuaFunction func) : base(func) { }
		public System_Predicate_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public bool Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			bool ret = func.CheckBoolean();
			func.EndPCall();
			return ret;
		}

		public bool CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			bool ret = func.CheckBoolean();
			func.EndPCall();
			return ret;
		}
	}

	public System.Predicate<int> System_Predicate_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Predicate<int> fn = delegate(int param0) { return false; };
			return fn;
		}

		if(!flag)
		{
			System_Predicate_int_Event target = new System_Predicate_int_Event(func);
			System.Predicate<int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Predicate_int_Event target = new System_Predicate_int_Event(func, self);
			System.Predicate<int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Predicate_int(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Predicate<int>), L, pos);
	}

	void Push_System_Predicate_int(IntPtr L, System.Predicate<int> o)
	{
		ToLua.Push(L, o);
	}

	class System_Action_int_Event : LuaDelegate
	{
		public System_Action_int_Event(LuaFunction func) : base(func) { }
		public System_Action_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public System.Action<int> System_Action_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Action<int> fn = delegate(int param0) { };
			return fn;
		}

		if(!flag)
		{
			System_Action_int_Event target = new System_Action_int_Event(func);
			System.Action<int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Action_int_Event target = new System_Action_int_Event(func, self);
			System.Action<int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Action_int(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Action<int>), L, pos);
	}

	void Push_System_Action_int(IntPtr L, System.Action<int> o)
	{
		ToLua.Push(L, o);
	}

	class System_Comparison_int_Event : LuaDelegate
	{
		public System_Comparison_int_Event(LuaFunction func) : base(func) { }
		public System_Comparison_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public int Call(int param0, int param1)
		{
			func.BeginPCall();
			func.Push(param0);
			func.Push(param1);
			func.PCall();
			int ret = (int)func.CheckNumber();
			func.EndPCall();
			return ret;
		}

		public int CallWithSelf(int param0, int param1)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.Push(param1);
			func.PCall();
			int ret = (int)func.CheckNumber();
			func.EndPCall();
			return ret;
		}
	}

	public System.Comparison<int> System_Comparison_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Comparison<int> fn = delegate(int param0, int param1) { return 0; };
			return fn;
		}

		if(!flag)
		{
			System_Comparison_int_Event target = new System_Comparison_int_Event(func);
			System.Comparison<int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Comparison_int_Event target = new System_Comparison_int_Event(func, self);
			System.Comparison<int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Comparison_int(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Comparison<int>), L, pos);
	}

	void Push_System_Comparison_int(IntPtr L, System.Comparison<int> o)
	{
		ToLua.Push(L, o);
	}

	class System_Func_int_int_Event : LuaDelegate
	{
		public System_Func_int_int_Event(LuaFunction func) : base(func) { }
		public System_Func_int_int_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public int Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			int ret = (int)func.CheckNumber();
			func.EndPCall();
			return ret;
		}

		public int CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			int ret = (int)func.CheckNumber();
			func.EndPCall();
			return ret;
		}
	}

	public System.Func<int,int> System_Func_int_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			System.Func<int,int> fn = delegate(int param0) { return 0; };
			return fn;
		}

		if(!flag)
		{
			System_Func_int_int_Event target = new System_Func_int_int_Event(func);
			System.Func<int,int> d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			System_Func_int_int_Event target = new System_Func_int_int_Event(func, self);
			System.Func<int,int> d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_System_Func_int_int(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(System.Func<int,int>), L, pos);
	}

	void Push_System_Func_int_int(IntPtr L, System.Func<int,int> o)
	{
		ToLua.Push(L, o);
	}

	class FairyGUI_EventCallback1_Event : LuaDelegate
	{
		public FairyGUI_EventCallback1_Event(LuaFunction func) : base(func) { }
		public FairyGUI_EventCallback1_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(FairyGUI.EventContext param0)
		{
			func.BeginPCall();
			func.PushObject(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(FairyGUI.EventContext param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.PushObject(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public FairyGUI.EventCallback1 FairyGUI_EventCallback1(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			FairyGUI.EventCallback1 fn = delegate(FairyGUI.EventContext param0) { };
			return fn;
		}

		if(!flag)
		{
			FairyGUI_EventCallback1_Event target = new FairyGUI_EventCallback1_Event(func);
			FairyGUI.EventCallback1 d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			FairyGUI_EventCallback1_Event target = new FairyGUI_EventCallback1_Event(func, self);
			FairyGUI.EventCallback1 d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_FairyGUI_EventCallback1(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(FairyGUI.EventCallback1), L, pos);
	}

	void Push_FairyGUI_EventCallback1(IntPtr L, FairyGUI.EventCallback1 o)
	{
		ToLua.Push(L, o);
	}

	class FairyGUI_EventCallback0_Event : LuaDelegate
	{
		public FairyGUI_EventCallback0_Event(LuaFunction func) : base(func) { }
		public FairyGUI_EventCallback0_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public FairyGUI.EventCallback0 FairyGUI_EventCallback0(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			FairyGUI.EventCallback0 fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			FairyGUI_EventCallback0_Event target = new FairyGUI_EventCallback0_Event(func);
			FairyGUI.EventCallback0 d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			FairyGUI_EventCallback0_Event target = new FairyGUI_EventCallback0_Event(func, self);
			FairyGUI.EventCallback0 d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_FairyGUI_EventCallback0(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(FairyGUI.EventCallback0), L, pos);
	}

	void Push_FairyGUI_EventCallback0(IntPtr L, FairyGUI.EventCallback0 o)
	{
		ToLua.Push(L, o);
	}

	class FairyGUI_ListItemRenderer_Event : LuaDelegate
	{
		public FairyGUI_ListItemRenderer_Event(LuaFunction func) : base(func) { }
		public FairyGUI_ListItemRenderer_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(int param0, FairyGUI.GObject param1)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PushObject(param1);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(int param0, FairyGUI.GObject param1)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PushObject(param1);
			func.PCall();
			func.EndPCall();
		}
	}

	public FairyGUI.ListItemRenderer FairyGUI_ListItemRenderer(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			FairyGUI.ListItemRenderer fn = delegate(int param0, FairyGUI.GObject param1) { };
			return fn;
		}

		if(!flag)
		{
			FairyGUI_ListItemRenderer_Event target = new FairyGUI_ListItemRenderer_Event(func);
			FairyGUI.ListItemRenderer d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			FairyGUI_ListItemRenderer_Event target = new FairyGUI_ListItemRenderer_Event(func, self);
			FairyGUI.ListItemRenderer d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_FairyGUI_ListItemRenderer(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(FairyGUI.ListItemRenderer), L, pos);
	}

	void Push_FairyGUI_ListItemRenderer(IntPtr L, FairyGUI.ListItemRenderer o)
	{
		ToLua.Push(L, o);
	}

	class FairyGUI_ListItemProvider_Event : LuaDelegate
	{
		public FairyGUI_ListItemProvider_Event(LuaFunction func) : base(func) { }
		public FairyGUI_ListItemProvider_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public string Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			string ret = func.CheckString();
			func.EndPCall();
			return ret;
		}

		public string CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			string ret = func.CheckString();
			func.EndPCall();
			return ret;
		}
	}

	public FairyGUI.ListItemProvider FairyGUI_ListItemProvider(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			FairyGUI.ListItemProvider fn = delegate(int param0) { return null; };
			return fn;
		}

		if(!flag)
		{
			FairyGUI_ListItemProvider_Event target = new FairyGUI_ListItemProvider_Event(func);
			FairyGUI.ListItemProvider d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			FairyGUI_ListItemProvider_Event target = new FairyGUI_ListItemProvider_Event(func, self);
			FairyGUI.ListItemProvider d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_FairyGUI_ListItemProvider(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(FairyGUI.ListItemProvider), L, pos);
	}

	void Push_FairyGUI_ListItemProvider(IntPtr L, FairyGUI.ListItemProvider o)
	{
		ToLua.Push(L, o);
	}

	class FairyGUI_PlayCompleteCallback_Event : LuaDelegate
	{
		public FairyGUI_PlayCompleteCallback_Event(LuaFunction func) : base(func) { }
		public FairyGUI_PlayCompleteCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public FairyGUI.PlayCompleteCallback FairyGUI_PlayCompleteCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			FairyGUI.PlayCompleteCallback fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			FairyGUI_PlayCompleteCallback_Event target = new FairyGUI_PlayCompleteCallback_Event(func);
			FairyGUI.PlayCompleteCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			FairyGUI_PlayCompleteCallback_Event target = new FairyGUI_PlayCompleteCallback_Event(func, self);
			FairyGUI.PlayCompleteCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_FairyGUI_PlayCompleteCallback(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(FairyGUI.PlayCompleteCallback), L, pos);
	}

	void Push_FairyGUI_PlayCompleteCallback(IntPtr L, FairyGUI.PlayCompleteCallback o)
	{
		ToLua.Push(L, o);
	}

	class FairyGUI_TransitionHook_Event : LuaDelegate
	{
		public FairyGUI_TransitionHook_Event(LuaFunction func) : base(func) { }
		public FairyGUI_TransitionHook_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call()
		{
			func.Call();
		}

		public void CallWithSelf()
		{
			func.BeginPCall();
			func.Push(self);
			func.PCall();
			func.EndPCall();
		}
	}

	public FairyGUI.TransitionHook FairyGUI_TransitionHook(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			FairyGUI.TransitionHook fn = delegate() { };
			return fn;
		}

		if(!flag)
		{
			FairyGUI_TransitionHook_Event target = new FairyGUI_TransitionHook_Event(func);
			FairyGUI.TransitionHook d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			FairyGUI_TransitionHook_Event target = new FairyGUI_TransitionHook_Event(func, self);
			FairyGUI.TransitionHook d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_FairyGUI_TransitionHook(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(FairyGUI.TransitionHook), L, pos);
	}

	void Push_FairyGUI_TransitionHook(IntPtr L, FairyGUI.TransitionHook o)
	{
		ToLua.Push(L, o);
	}

	class FairyGUI_UIPackage_LoadResource_Event : LuaDelegate
	{
		public FairyGUI_UIPackage_LoadResource_Event(LuaFunction func) : base(func) { }
		public FairyGUI_UIPackage_LoadResource_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public UnityEngine.Object Call(string param0, string param1, System.Type param2)
		{
			func.BeginPCall();
			func.Push(param0);
			func.Push(param1);
			func.Push(param2);
			func.PCall();
			UnityEngine.Object ret = (UnityEngine.Object)func.CheckObject(typeof(UnityEngine.Object));
			func.EndPCall();
			return ret;
		}

		public UnityEngine.Object CallWithSelf(string param0, string param1, System.Type param2)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.Push(param1);
			func.Push(param2);
			func.PCall();
			UnityEngine.Object ret = (UnityEngine.Object)func.CheckObject(typeof(UnityEngine.Object));
			func.EndPCall();
			return ret;
		}
	}

	public FairyGUI.UIPackage.LoadResource FairyGUI_UIPackage_LoadResource(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			FairyGUI.UIPackage.LoadResource fn = delegate(string param0, string param1, System.Type param2) { return null; };
			return fn;
		}

		if(!flag)
		{
			FairyGUI_UIPackage_LoadResource_Event target = new FairyGUI_UIPackage_LoadResource_Event(func);
			FairyGUI.UIPackage.LoadResource d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			FairyGUI_UIPackage_LoadResource_Event target = new FairyGUI_UIPackage_LoadResource_Event(func, self);
			FairyGUI.UIPackage.LoadResource d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_FairyGUI_UIPackage_LoadResource(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(FairyGUI.UIPackage.LoadResource), L, pos);
	}

	void Push_FairyGUI_UIPackage_LoadResource(IntPtr L, FairyGUI.UIPackage.LoadResource o)
	{
		ToLua.Push(L, o);
	}

	class FairyGUI_UIPackage_CreateObjectCallback_Event : LuaDelegate
	{
		public FairyGUI_UIPackage_CreateObjectCallback_Event(LuaFunction func) : base(func) { }
		public FairyGUI_UIPackage_CreateObjectCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(FairyGUI.GObject param0)
		{
			func.BeginPCall();
			func.PushObject(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(FairyGUI.GObject param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.PushObject(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public FairyGUI.UIPackage.CreateObjectCallback FairyGUI_UIPackage_CreateObjectCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			FairyGUI.UIPackage.CreateObjectCallback fn = delegate(FairyGUI.GObject param0) { };
			return fn;
		}

		if(!flag)
		{
			FairyGUI_UIPackage_CreateObjectCallback_Event target = new FairyGUI_UIPackage_CreateObjectCallback_Event(func);
			FairyGUI.UIPackage.CreateObjectCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			FairyGUI_UIPackage_CreateObjectCallback_Event target = new FairyGUI_UIPackage_CreateObjectCallback_Event(func, self);
			FairyGUI.UIPackage.CreateObjectCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_FairyGUI_UIPackage_CreateObjectCallback(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(FairyGUI.UIPackage.CreateObjectCallback), L, pos);
	}

	void Push_FairyGUI_UIPackage_CreateObjectCallback(IntPtr L, FairyGUI.UIPackage.CreateObjectCallback o)
	{
		ToLua.Push(L, o);
	}

	class FairyGUI_GObjectPool_InitCallbackDelegate_Event : LuaDelegate
	{
		public FairyGUI_GObjectPool_InitCallbackDelegate_Event(LuaFunction func) : base(func) { }
		public FairyGUI_GObjectPool_InitCallbackDelegate_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(FairyGUI.GObject param0)
		{
			func.BeginPCall();
			func.PushObject(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(FairyGUI.GObject param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.PushObject(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public FairyGUI.GObjectPool.InitCallbackDelegate FairyGUI_GObjectPool_InitCallbackDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			FairyGUI.GObjectPool.InitCallbackDelegate fn = delegate(FairyGUI.GObject param0) { };
			return fn;
		}

		if(!flag)
		{
			FairyGUI_GObjectPool_InitCallbackDelegate_Event target = new FairyGUI_GObjectPool_InitCallbackDelegate_Event(func);
			FairyGUI.GObjectPool.InitCallbackDelegate d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			FairyGUI_GObjectPool_InitCallbackDelegate_Event target = new FairyGUI_GObjectPool_InitCallbackDelegate_Event(func, self);
			FairyGUI.GObjectPool.InitCallbackDelegate d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_FairyGUI_GObjectPool_InitCallbackDelegate(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(FairyGUI.GObjectPool.InitCallbackDelegate), L, pos);
	}

	void Push_FairyGUI_GObjectPool_InitCallbackDelegate(IntPtr L, FairyGUI.GObjectPool.InitCallbackDelegate o)
	{
		ToLua.Push(L, o);
	}

	class FairyGUI_TimerCallback_Event : LuaDelegate
	{
		public FairyGUI_TimerCallback_Event(LuaFunction func) : base(func) { }
		public FairyGUI_TimerCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(object param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(object param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public FairyGUI.TimerCallback FairyGUI_TimerCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			FairyGUI.TimerCallback fn = delegate(object param0) { };
			return fn;
		}

		if(!flag)
		{
			FairyGUI_TimerCallback_Event target = new FairyGUI_TimerCallback_Event(func);
			FairyGUI.TimerCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			FairyGUI_TimerCallback_Event target = new FairyGUI_TimerCallback_Event(func, self);
			FairyGUI.TimerCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_FairyGUI_TimerCallback(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(FairyGUI.TimerCallback), L, pos);
	}

	void Push_FairyGUI_TimerCallback(IntPtr L, FairyGUI.TimerCallback o)
	{
		ToLua.Push(L, o);
	}

	class UnityEngine_Application_LogCallback_Event : LuaDelegate
	{
		public UnityEngine_Application_LogCallback_Event(LuaFunction func) : base(func) { }
		public UnityEngine_Application_LogCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(string param0, string param1, UnityEngine.LogType param2)
		{
			func.BeginPCall();
			func.Push(param0);
			func.Push(param1);
			func.Push(param2);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(string param0, string param1, UnityEngine.LogType param2)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.Push(param1);
			func.Push(param2);
			func.PCall();
			func.EndPCall();
		}
	}

	public UnityEngine.Application.LogCallback UnityEngine_Application_LogCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.Application.LogCallback fn = delegate(string param0, string param1, UnityEngine.LogType param2) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_Application_LogCallback_Event target = new UnityEngine_Application_LogCallback_Event(func);
			UnityEngine.Application.LogCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_Application_LogCallback_Event target = new UnityEngine_Application_LogCallback_Event(func, self);
			UnityEngine.Application.LogCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_UnityEngine_Application_LogCallback(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(UnityEngine.Application.LogCallback), L, pos);
	}

	void Push_UnityEngine_Application_LogCallback(IntPtr L, UnityEngine.Application.LogCallback o)
	{
		ToLua.Push(L, o);
	}

	class UnityEngine_AudioClip_PCMReaderCallback_Event : LuaDelegate
	{
		public UnityEngine_AudioClip_PCMReaderCallback_Event(LuaFunction func) : base(func) { }
		public UnityEngine_AudioClip_PCMReaderCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(float[] param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(float[] param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public UnityEngine.AudioClip.PCMReaderCallback UnityEngine_AudioClip_PCMReaderCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.AudioClip.PCMReaderCallback fn = delegate(float[] param0) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_AudioClip_PCMReaderCallback_Event target = new UnityEngine_AudioClip_PCMReaderCallback_Event(func);
			UnityEngine.AudioClip.PCMReaderCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_AudioClip_PCMReaderCallback_Event target = new UnityEngine_AudioClip_PCMReaderCallback_Event(func, self);
			UnityEngine.AudioClip.PCMReaderCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_UnityEngine_AudioClip_PCMReaderCallback(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(UnityEngine.AudioClip.PCMReaderCallback), L, pos);
	}

	void Push_UnityEngine_AudioClip_PCMReaderCallback(IntPtr L, UnityEngine.AudioClip.PCMReaderCallback o)
	{
		ToLua.Push(L, o);
	}

	class UnityEngine_AudioClip_PCMSetPositionCallback_Event : LuaDelegate
	{
		public UnityEngine_AudioClip_PCMSetPositionCallback_Event(LuaFunction func) : base(func) { }
		public UnityEngine_AudioClip_PCMSetPositionCallback_Event(LuaFunction func, LuaTable self) : base(func, self) { }

		public void Call(int param0)
		{
			func.BeginPCall();
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			func.BeginPCall();
			func.Push(self);
			func.Push(param0);
			func.PCall();
			func.EndPCall();
		}
	}

	public UnityEngine.AudioClip.PCMSetPositionCallback UnityEngine_AudioClip_PCMSetPositionCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			UnityEngine.AudioClip.PCMSetPositionCallback fn = delegate(int param0) { };
			return fn;
		}

		if(!flag)
		{
			UnityEngine_AudioClip_PCMSetPositionCallback_Event target = new UnityEngine_AudioClip_PCMSetPositionCallback_Event(func);
			UnityEngine.AudioClip.PCMSetPositionCallback d = target.Call;
			target.method = d.Method;
			return d;
		}
		else
		{
			UnityEngine_AudioClip_PCMSetPositionCallback_Event target = new UnityEngine_AudioClip_PCMSetPositionCallback_Event(func, self);
			UnityEngine.AudioClip.PCMSetPositionCallback d = target.CallWithSelf;
			target.method = d.Method;
			return d;
		}
	}

	bool Check_UnityEngine_AudioClip_PCMSetPositionCallback(IntPtr L, int pos)
	{
		return TypeChecker.CheckDelegateType(typeof(UnityEngine.AudioClip.PCMSetPositionCallback), L, pos);
	}

	void Push_UnityEngine_AudioClip_PCMSetPositionCallback(IntPtr L, UnityEngine.AudioClip.PCMSetPositionCallback o)
	{
		ToLua.Push(L, o);
	}

}

