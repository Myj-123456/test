using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace ADK
{
    /// <summary>
    /// 反射工具类,带缓存，提高效率
    /// 
    /// </summary>
    public static class ReflectionUtil
    {
        private const BindingFlags _bindingFlags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        private static Dictionary<ulong, MemberInfo> _memberNameInfoDic = new Dictionary<ulong, MemberInfo>();
        private static Dictionary<int, Attribute> _attributeDic = new Dictionary<int, Attribute>();

        public static T GetCustomAttribute<T>(MemberInfo memberInfo,bool inherit) where T : Attribute
        {
            Attribute t;
            int key = memberInfo.GetHashCode();
            if (_attributeDic.TryGetValue(key, out t)==false)
            {
                object[] atts = memberInfo.GetCustomAttributes(typeof(T), inherit);
                if (atts != null && atts.Length > 0)
                    t = atts[0] as Attribute;
                _attributeDic.Add(key, t);
            }
  
            return t as T;
        }
        public static MemberInfo GetMemberInfo(Type type, string memberName, int paramsCount = 0, BindingFlags bindingFlags = _bindingFlags)
        {
            MemberInfo member = null;
            ulong key = ((ulong)(type.GetHashCode()) << 32);
            key = key + (uint)(memberName.GetHashCode());


            if (_memberNameInfoDic.TryGetValue(key, out member) == false)
            {
                MemberInfo[] menbers = type.GetMember(memberName, bindingFlags);
                if (menbers != null && menbers.Length > 0)
                {
                    for (int j = 0; j < menbers.Length; j++)
                    {
                        MemberInfo tempMember = menbers[j];
                        if (tempMember is FieldInfo || tempMember is PropertyInfo)
                        {
                            member = tempMember;
                            break;
                        }
                        else if (tempMember is MethodInfo)
                        {
                            ParameterInfo[] paramters = (tempMember as MethodInfo).GetParameters();
                            if (paramters == null || paramters.Length == paramsCount)
                            {
                                member = tempMember;
                                break;
                            }
                        }
                    }
                }
                if (member == null)
                {
                    Type t = type.BaseType;
                    if (t != null)
                        member = GetMemberInfo(t, memberName, paramsCount, bindingFlags);
                }

                _memberNameInfoDic.Add(key, member);
            }

            return member;
        }

        public static T GetMemberInfoValue<T>(object target, string memberName)
        {
            T value;
            GetMemberInfoValue(target, memberName, out value);
            return value;
        }
        public static T GetMemberInfoValue<T>(object target, MemberInfo member)
        {
            T value;
            GetMemberInfoValue(target, member, out value);
            return value;
        }
        public static bool GetMemberInfoValue<T>(object target, string memberName,out T value)
        {
            MemberInfo member = GetMemberInfo(target.GetType(), memberName);
            if (member != null)
            {
                GetMemberInfoValue(target, member,out value);
                return true;
            }
            value = default(T);
            return false;
        }
        public static bool GetMemberInfoValue<T>(object target, MemberInfo member ,out T value)
        {
        
            if (member is FieldInfo)
            {
                value=(T)((FieldInfo)member).GetValue(target);
                return true;
            }
            if (member is PropertyInfo)
            {
                value = (T)((PropertyInfo)member).GetValue(target, null);
                return true;
            }
            else if (member is MethodInfo)
            {
                value = (T)((MethodInfo)member).Invoke(target, null);
                return true;
            }
            value = default(T);
            return false;
        }
        public static bool SetMemberInfoValue<T>(object target, string memberName, T value)
        {
            MemberInfo member = GetMemberInfo(target.GetType(), memberName,1);
            if (member != null)
            {
                return SetMemberInfoValue(target, member, value);
            }
            return false;

        }
        public static bool SetMemberInfoValue<T>(object target, MemberInfo member, T value)
        {
            if (member is FieldInfo)
            {
                ((FieldInfo)member).SetValue(target, value);
                return true;
            }
            else if (member is PropertyInfo)
            {
                ((PropertyInfo)member).SetValue(target, value, null);
                return true;
            }
            else if (member is MethodInfo)
            {
                ((MethodInfo)member).Invoke(target, new object[] { value });
                return true;
            }
            return false;
        }

        public static Func<T> CreateGetterDelegate<T>(object target, string memberName)
        {
            MemberInfo member = GetMemberInfo(target.GetType(), memberName);
            if (member != null)
            {
                return CreateGetterDelegate<T>(target, member);
            }
            return null;
        }
        public static Func<T> CreateGetterDelegate<T>(object target, MemberInfo member)
        {
            if (member is FieldInfo)
            {
                return CreateGetterDelegate<T>(target, (FieldInfo)member);
            }
            else if (member is PropertyInfo)
            {
                return CreateGetterDelegate<T>(target, (PropertyInfo)member);
            }
            else if (member is MethodInfo)
            {
                return CreateGetterDelegate<T>(target, (MethodInfo)member);
            }
            return null;
        }
        public static Func<T> CreateGetterDelegate<T>(object target,FieldInfo fieldInfo)
        {
        
            var instExp = Expression.Constant(target);
            var fieldExp = Expression.Field(instExp, fieldInfo);
            var action= Expression.Lambda<Func<T>>(fieldExp).Compile();
            return action;
        }

        public static Func<T> CreateGetterDelegate<T>(object target,PropertyInfo propertyInfo)
        {
            return Delegate.CreateDelegate(typeof(Func<T>), target, propertyInfo.GetGetMethod(true)) as Func<T>;
        }

        public static Func<T> CreateGetterDelegate<T>(object target, MethodInfo methodInfo)
        {
            return Delegate.CreateDelegate(typeof(Func<T>), target, methodInfo) as Func<T>;
        }

        //

        public static Action<T> CreateSetterDelegate<T>(object target, string memberName)
        {
            MemberInfo member = GetMemberInfo(target.GetType(), memberName);
            if (member != null)
            {
                return CreateSetterDelegate<T>(target, member);
            }
            return null;
        }
        public static Action<T> CreateSetterDelegate<T>(object target, MemberInfo member)
        {
            if (member is FieldInfo)
            {
                return CreateSetterDelegate<T>(target, (FieldInfo)member);
            }
            else if (member is PropertyInfo)
            {
                return CreateSetterDelegate<T>(target, (PropertyInfo)member);
            }
            else if (member is MethodInfo)
            {
                return CreateSetterDelegate<T>(target, (MethodInfo)member);
            }
            return null;
        }

        public static Action<T> CreateSetterDelegate<T>(object target, FieldInfo fieldInfo)
        {
             return (value) => fieldInfo.SetValue(target, value);
        }

        public static Action<T> CreateSetterDelegate<T>(object target, PropertyInfo propertyInfo)
        {
            return Delegate.CreateDelegate(typeof(Action<T>), target, propertyInfo.GetSetMethod(true)) as Action<T>;
        }

        public static Action<T> CreateSetterDelegate<T>(object target, MethodInfo methodInfo)
        {
            return Delegate.CreateDelegate(typeof(Action<T>), target, methodInfo) as Action<T>;
        }
        public static Action<T1,T2,T3> CreateSetterDelegate<T1,T2,T3>(object target, MethodInfo methodInfo)
        {
            return Delegate.CreateDelegate(typeof(Action<T1, T2, T3>), target, methodInfo) as Action<T1,T2,T3>;
        }
        public static Action CreateSetterDelegate(object target, MethodInfo methodInfo)
        {
            return Delegate.CreateDelegate(typeof(Action), target, methodInfo) as Action;
        }
    }
}