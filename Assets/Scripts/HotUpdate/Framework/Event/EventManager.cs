
using System;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 事件管理器
/// TODO:监听到事件立马移除事件会报错 集合被修改
/// </summary>
public class EventManager : Singleton<EventManager>
{
    private Dictionary<string, List<InvokableActionBase>> GlobalEventTable { get; set; } = new Dictionary<string, List<InvokableActionBase>>();
    private Dictionary<object, Dictionary<string, List<InvokableActionBase>>> EventTable { get; set; } = new Dictionary<object, Dictionary<string, List<InvokableActionBase>>>();


    #region Execute
    public void DispatchEvent(string eventName)
    {
        var actions = GetActions(eventName);
        if (actions != null)
        {
            // 使用列表副本进行迭代，避免在迭代过程中修改原始列表导致异常
            var actionsCopy = new List<InvokableActionBase>(actions);
            foreach (var action in actionsCopy)
            {
                (action as InvokableAction)?.Excute();
            }
        }
    }
    public void DispatchEvent<T1>(string eventName, T1 arg1)
    {
        var actions = GetActions(eventName);
        if (actions != null)
        {
            // 使用列表副本进行迭代，避免在迭代过程中修改原始列表导致异常
            var actionsCopy = new List<InvokableActionBase>(actions);
            foreach (var action in actionsCopy)
            {
                (action as InvokableAction<T1>)?.Excute(arg1);
            }
        }
    }
    public void DispatchEvent<T1, T2>(string eventName, T1 arg1, T2 arg2)
    {
        var actions = GetActions(eventName);
        if (actions != null)
        {
            // 使用列表副本进行迭代，避免在迭代过程中修改原始列表导致异常
            var actionsCopy = new List<InvokableActionBase>(actions);
            foreach (var action in actionsCopy)
            {
                (action as InvokableAction<T1, T2>)?.Excute(arg1, arg2);
            }
        }
    }
    public void DispatchEvent<T1, T2, T3>(string eventName, T1 arg1, T2 arg2, T3 arg3)
    {
        var actions = GetActions(eventName);
        if (actions != null)
        {
            foreach (var action in actions)
            {
                (action as InvokableAction<T1, T2, T3>)?.Excute(arg1, arg2, arg3);
            }
        }
    }
    public void DispatchEvent<T1, T2, T3, T4>(string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        var actions = GetActions(eventName);
        if (actions != null)
        {
            foreach (var action in actions)
            {
                (action as InvokableAction<T1, T2, T3, T4>)?.Excute(arg1, arg2, arg3, arg4);
            }
        }
    }
    public void DispatchEvent(object obj, string eventName)
    {
        var actions = GetActions(obj, eventName);
        if (actions != null)
        {
            foreach (var action in actions)
            {
                (action as InvokableAction)?.Excute();
            }
        }
    }
    public void DispatchEvent<T1>(object obj, string eventName, T1 arg1)
    {
        var actions = GetActions(obj, eventName);
        if (actions != null)
        {
            foreach (var action in actions)
            {
                (action as InvokableAction<T1>)?.Excute(arg1);
            }
        }
    }
    public void DispatchEvent<T1, T2>(object obj, string eventName, T1 arg1, T2 arg2)
    {
        var actions = GetActions(obj, eventName);
        if (actions != null)
        {
            foreach (var action in actions)
            {
                (action as InvokableAction<T1, T2>)?.Excute(arg1, arg2);
            }
        }
    }
    public void DispatchEvent<T1, T2, T3>(object obj, string eventName, T1 arg1, T2 arg2, T3 arg3)
    {
        var actions = GetActions(obj, eventName);
        if (actions != null)
        {
            foreach (var action in actions)
            {
                (action as InvokableAction<T1, T2, T3>)?.Excute(arg1, arg2, arg3);
            }
        }
    }
    public void DispatchEvent<T1, T2, T3, T4>(object obj, string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        var actions = GetActions(obj, eventName);
        if (actions != null)
        {
            foreach (var action in actions)
            {
                (action as InvokableAction<T1, T2, T3, T4>)?.Excute(arg1, arg2, arg3, arg4);
            }
        }
    }
    #endregion
    #region Subscrible
    public void AddEventListener(string eventName, Action action)
    {
        Subscribe(eventName, new InvokableAction(action));
    }
    public void AddEventListener<T1>(string eventName, Action<T1> action)
    {
        Subscribe(eventName, new InvokableAction<T1>(action));
    }
    public void AddEventListener<T1, T2>(string eventName, Action<T1, T2> action)
    {
        Subscribe(eventName, new InvokableAction<T1, T2>(action));
    }
    public void AddEventListener<T1, T2, T3>(string eventName, Action<T1, T2, T3> action)
    {
        Subscribe(eventName, new InvokableAction<T1, T2, T3>(action));
    }
    public void AddEventListener<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action)
    {
        Subscribe(eventName, new InvokableAction<T1, T2, T3, T4>(action));
    }
    public void AddEventListener(object obj, string eventName, Action action)
    {
        Subscribe(obj, eventName, new InvokableAction(action));
    }
    public void AddEventListener<T1>(object obj, string eventName, Action<T1> action)
    {
        Subscribe(obj, eventName, new InvokableAction<T1>(action));
    }
    public void AddEventListener<T1, T2>(object obj, string eventName, Action<T1, T2> action)
    {
        Subscribe(obj, eventName, new InvokableAction<T1, T2>(action));
    }
    public void AddEventListener<T1, T2, T3>(object obj, string eventName, Action<T1, T2, T3> action)
    {
        Subscribe(obj, eventName, new InvokableAction<T1, T2, T3>(action));
    }
    public void Subscribe<T1, T2, T3, T4>(object obj, string eventName, Action<T1, T2, T3, T4> action)
    {
        Subscribe(obj, eventName, new InvokableAction<T1, T2, T3, T4>(action));
    }
    private void Subscribe(string eventName, InvokableActionBase action)
    {
        if (GlobalEventTable.TryGetValue(eventName, out List<InvokableActionBase> actions))
        {
            actions.Add(action);
        }
        else
        {
            GlobalEventTable.Add(eventName, new List<InvokableActionBase> { action });
        }
    }
    private void Subscribe(object obj, string eventName, InvokableActionBase action)
    {
        if (!EventTable.TryGetValue(obj, out Dictionary<string, List<InvokableActionBase>> handlers))
        {
            handlers = new Dictionary<string, List<InvokableActionBase>>();
            EventTable.Add(obj, handlers);
        }

        if (!handlers.TryGetValue(eventName, out List<InvokableActionBase> actions))
        {
            actions = new List<InvokableActionBase>();
            handlers.Add(eventName, actions);
        }

        actions.Add(action);

    }
    #endregion
    #region Unsubscribe
    public void RemoveEventListener(string eventName, Action action)
    {
        var actions = GetActions(eventName);
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var invokableAction = actions[i] as InvokableAction;
                if (invokableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            TryRemoveActions(eventName, actions);
        }
    }
    public void RemoveEventListener<T1>(string eventName, Action<T1> action)
    {
        var actions = GetActions(eventName);
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var invokableAction = actions[i] as InvokableAction<T1>;
                if (invokableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            TryRemoveActions(eventName, actions);
        }
    }
    public void RemoveEventListener<T1, T2>(string eventName, Action<T1, T2> action)
    {
        var actions = GetActions(eventName);
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var invokableAction = actions[i] as InvokableAction<T1, T2>;
                if (invokableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            TryRemoveActions(eventName, actions);
        }
    }
    public void RemoveEventListener<T1, T2, T3>(string eventName, Action<T1, T2, T3> action)
    {
        var actions = GetActions(eventName);
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var invokableAction = actions[i] as InvokableAction<T1, T2, T3>;
                if (invokableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            TryRemoveActions(eventName, actions);
        }
    }
    public void RemoveEventListener<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action)
    {
        var actions = GetActions(eventName);
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var invokableAction = actions[i] as InvokableAction<T1, T2, T3, T4>;
                if (invokableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            TryRemoveActions(eventName, actions);
        }
    }
    public void RemoveEventListener(object obj, string eventName, Action action)
    {
        var actions = GetActions(obj, eventName);
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var invokableAction = actions[i] as InvokableAction;
                if (invokableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            TryRemoveActions(obj, eventName, actions);
        }
    }
    public void RemoveEventListener<T1>(object obj, string eventName, Action<T1> action)
    {
        var actions = GetActions(obj, eventName);
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var invokableAction = actions[i] as InvokableAction<T1>;
                if (invokableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            TryRemoveActions(obj, eventName, actions);
        }
    }
    public void RemoveEventListener<T1, T2>(object obj, string eventName, Action<T1, T2> action)
    {
        var actions = GetActions(obj, eventName);
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var invokableAction = actions[i] as InvokableAction<T1, T2>;
                if (invokableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            TryRemoveActions(obj, eventName, actions);
        }
    }
    public void RemoveEventListener<T1, T2, T3>(object obj, string eventName, Action<T1, T2, T3> action)
    {
        var actions = GetActions(obj, eventName);
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var invokableAction = actions[i] as InvokableAction<T1, T2, T3>;
                if (invokableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            TryRemoveActions(obj, eventName, actions);
        }
    }
    public void RemoveEventListener<T1, T2, T3, T4>(object obj, string eventName, Action<T1, T2, T3, T4> action)
    {
        var actions = GetActions(obj, eventName);
        if (actions != null)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var invokableAction = actions[i] as InvokableAction<T1, T2, T3, T4>;
                if (invokableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            TryRemoveActions(obj, eventName, actions);
        }
    }

    private void TryRemoveActions(string eventName, List<InvokableActionBase> actions)
    {
        if (actions.Count == 0)
        {
            GlobalEventTable.Remove(eventName);
        }
    }
    private void TryRemoveActions(object obj, string eventName, List<InvokableActionBase> actions)
    {
        if (actions.Count == 0 && EventTable.TryGetValue(obj, out Dictionary<String, List<InvokableActionBase>> handlers))
        {
            handlers.Remove(eventName);
            if (handlers.Count == 0)
            {
                EventTable.Remove(obj);
            }
        }
    }
    #endregion

    public void Clear()
    {
        if (GlobalEventTable != null)
        {
            GlobalEventTable.Clear();
        }
        if (EventTable != null)
        {
            EventTable.Clear();
        }
    }

    private List<InvokableActionBase> GetActions(string eventName)
    {
        GlobalEventTable.TryGetValue(eventName, out List<InvokableActionBase> actions);
        return actions;
    }
    private List<InvokableActionBase> GetActions(object obj, string eventName)
    {
        List<InvokableActionBase> actions = null;
        if (EventTable.TryGetValue(obj, out Dictionary<string, List<InvokableActionBase>> handlers))
        {
            handlers.TryGetValue(eventName, out actions);
        }

        return actions;
    }
}

#region InvokableAction
public abstract class InvokableActionBase { }
public class InvokableAction : InvokableActionBase
{
    public Action Action { get; private set; }
    public InvokableAction(Action action) => Action = action;
    public bool IsActionEqual(Action action) => Action == action;
    public void Excute() => Action?.Invoke();
}
public class InvokableAction<T1> : InvokableActionBase
{
    public Action<T1> Action { get; private set; }
    public InvokableAction(Action<T1> action) => Action = action;
    public bool IsActionEqual(Action<T1> action) => Action == action;
    public void Excute(T1 arg1) => Action?.Invoke(arg1);
}
public class InvokableAction<T1, T2> : InvokableActionBase
{
    public Action<T1, T2> Action { get; private set; }
    public InvokableAction(Action<T1, T2> action) => Action = action;
    public bool IsActionEqual(Action<T1, T2> action) => Action == action;
    public void Excute(T1 arg1, T2 arg2) => Action?.Invoke(arg1, arg2);
}
public class InvokableAction<T1, T2, T3> : InvokableActionBase
{
    public Action<T1, T2, T3> Action { get; private set; }
    public InvokableAction(Action<T1, T2, T3> action) => Action = action;
    public bool IsActionEqual(Action<T1, T2, T3> action) => Action == action;
    public void Excute(T1 arg1, T2 arg2, T3 arg3) => Action?.Invoke(arg1, arg2, arg3);
}
public class InvokableAction<T1, T2, T3, T4> : InvokableActionBase
{
    public Action<T1, T2, T3, T4> Action { get; private set; }
    public InvokableAction(Action<T1, T2, T3, T4> action) => Action = action;
    public bool IsActionEqual(Action<T1, T2, T3, T4> action) => Action == action;
    public void Excute(T1 arg1, T2 arg2, T3 arg3, T4 arg4) => Action?.Invoke(arg1, arg2, arg3, arg4);
}
#endregion