﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class FairyGUI_TimersWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FairyGUI.Timers), typeof(System.Object));
		L.RegFunction("Add", Add);
		L.RegFunction("CallLater", CallLater);
		L.RegFunction("AddUpdate", AddUpdate);
		L.RegFunction("StartCoroutine", StartCoroutine);
		L.RegFunction("Exists", Exists);
		L.RegFunction("Remove", Remove);
		L.RegFunction("Update", Update);
		L.RegFunction("New", _CreateFairyGUI_Timers);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("repeat", get_repeat, set_repeat);
		L.RegVar("time", get_time, set_time);
		L.RegVar("gameObject", get_gameObject, set_gameObject);
		L.RegVar("inst", get_inst, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateFairyGUI_Timers(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				FairyGUI.Timers obj = new FairyGUI.Timers();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: FairyGUI.Timers.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 4)
			{
				FairyGUI.Timers obj = (FairyGUI.Timers)ToLua.CheckObject<FairyGUI.Timers>(L, 1);
				float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
				int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
				FairyGUI.TimerCallback arg2 = (FairyGUI.TimerCallback)ToLua.CheckDelegate<FairyGUI.TimerCallback>(L, 4);
				obj.Add(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5)
			{
				FairyGUI.Timers obj = (FairyGUI.Timers)ToLua.CheckObject<FairyGUI.Timers>(L, 1);
				float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
				int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
				FairyGUI.TimerCallback arg2 = (FairyGUI.TimerCallback)ToLua.CheckDelegate<FairyGUI.TimerCallback>(L, 4);
				object arg3 = ToLua.ToVarObject(L, 5);
				obj.Add(arg0, arg1, arg2, arg3);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FairyGUI.Timers.Add");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CallLater(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				FairyGUI.Timers obj = (FairyGUI.Timers)ToLua.CheckObject<FairyGUI.Timers>(L, 1);
				FairyGUI.TimerCallback arg0 = (FairyGUI.TimerCallback)ToLua.CheckDelegate<FairyGUI.TimerCallback>(L, 2);
				obj.CallLater(arg0);
				return 0;
			}
			else if (count == 3)
			{
				FairyGUI.Timers obj = (FairyGUI.Timers)ToLua.CheckObject<FairyGUI.Timers>(L, 1);
				FairyGUI.TimerCallback arg0 = (FairyGUI.TimerCallback)ToLua.CheckDelegate<FairyGUI.TimerCallback>(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				obj.CallLater(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FairyGUI.Timers.CallLater");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddUpdate(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				FairyGUI.Timers obj = (FairyGUI.Timers)ToLua.CheckObject<FairyGUI.Timers>(L, 1);
				FairyGUI.TimerCallback arg0 = (FairyGUI.TimerCallback)ToLua.CheckDelegate<FairyGUI.TimerCallback>(L, 2);
				obj.AddUpdate(arg0);
				return 0;
			}
			else if (count == 3)
			{
				FairyGUI.Timers obj = (FairyGUI.Timers)ToLua.CheckObject<FairyGUI.Timers>(L, 1);
				FairyGUI.TimerCallback arg0 = (FairyGUI.TimerCallback)ToLua.CheckDelegate<FairyGUI.TimerCallback>(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				obj.AddUpdate(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FairyGUI.Timers.AddUpdate");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FairyGUI.Timers obj = (FairyGUI.Timers)ToLua.CheckObject<FairyGUI.Timers>(L, 1);
			System.Collections.IEnumerator arg0 = ToLua.CheckIter(L, 2);
			obj.StartCoroutine(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Exists(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FairyGUI.Timers obj = (FairyGUI.Timers)ToLua.CheckObject<FairyGUI.Timers>(L, 1);
			FairyGUI.TimerCallback arg0 = (FairyGUI.TimerCallback)ToLua.CheckDelegate<FairyGUI.TimerCallback>(L, 2);
			bool o = obj.Exists(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Remove(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FairyGUI.Timers obj = (FairyGUI.Timers)ToLua.CheckObject<FairyGUI.Timers>(L, 1);
			FairyGUI.TimerCallback arg0 = (FairyGUI.TimerCallback)ToLua.CheckDelegate<FairyGUI.TimerCallback>(L, 2);
			obj.Remove(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FairyGUI.Timers obj = (FairyGUI.Timers)ToLua.CheckObject<FairyGUI.Timers>(L, 1);
			obj.Update();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_repeat(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, FairyGUI.Timers.repeat);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, FairyGUI.Timers.time);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gameObject(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, FairyGUI.Timers.gameObject);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inst(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, FairyGUI.Timers.inst);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_repeat(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			FairyGUI.Timers.repeat = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_time(IntPtr L)
	{
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			FairyGUI.Timers.time = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gameObject(IntPtr L)
	{
		try
		{
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 2, typeof(UnityEngine.GameObject));
			FairyGUI.Timers.gameObject = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}
