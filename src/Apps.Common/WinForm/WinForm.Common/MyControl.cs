using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

using DreamCube.Foundation.Basic.Utility;

namespace DreamCube.WinForm.Common
{
    public static class MyControl
    {
        /// <summary>
        /// 根据控件名获取子控件
        /// </summary>
        /// <param name="oControl"></param>
        /// <param name="sControlName"></param>
        /// <returns></returns>
        public static Control GetSubControlByName(Control oControl, string sControlName)
        {
            Control oReturn = null;
            if (oControl.Controls.Count > 0)
            {
                foreach (Control oCtrl in oControl.Controls)
                {
                    if (oCtrl.Controls.Count > 0)
                    {
                        Control tempContrl = oCtrl;
                        oReturn = GetSubControlByName(tempContrl, sControlName);
                        if (oReturn != null)
                            break; // TODO: might not be correct. Was : Exit For
                    }
                    else if (MyString.StrEqual(oCtrl.Name, sControlName, true))
                    {
                        oReturn = oCtrl;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            return oReturn;
        }

        /// <summary>
        /// 禁止或者启用所有的子控件
        /// </summary>
        /// <param name="c"></param>
        /// <param name="enable"></param>
        public static void SetEnableAllControls(Control c, Boolean enable)
        {
            if (c != null)
            {
                MyControl.ControlBeginInvoke(c, new Action<Object>((o) =>
                {
                    List<Control> controlList = GetAllChildControls(c);
                    for (Int32 i = 0; i < controlList.Count; i++)
                    {
                        controlList[i].Enabled = enable;
                    }
                }), "");
            }
        }

        /// <summary>
        /// 获取所有的子控件
        /// </summary>
        /// <param name="c">父控件对象</param>
        /// <param name="controlTypeList">获取的子控件类型（指定或者某一类的子控件）</param>
        public static List<Control> GetAllChildControls(Control c, List<Type> controlTypeList = null)
        {
            List<Control> controls = new List<Control>();
            if (c != null)
            {
                Queue<Control> controlQueue = new Queue<Control>();
                if (c.HasChildren)
                {
                    //首先进队列
                    foreach (Control tempC in c.Controls)
                        controlQueue.Enqueue(tempC);
                }
                while (controlQueue.Count > 0)
                {
                    Control deQueueControl = controlQueue.Dequeue();
                    //加入列表中
                    if (controlTypeList == null || MyEnumerable.Contains<Type>(controlTypeList, deQueueControl.GetType()))
                        controls.Add(deQueueControl);
                    //循环所有的子控件，加入列表中，并判断该控件是否还有子控件，有的话继续加入列表中
                    foreach (Control tempC in deQueueControl.Controls)
                    {
                        if (controlTypeList == null || MyEnumerable.Contains<Type>(controlTypeList, tempC.GetType()))
                            controls.Add(tempC);
                        if (tempC.HasChildren) controlQueue.Enqueue(tempC);
                    }
                }
            }
            return controls;
        }

        /// <summary>
        /// 判断控件是否可以执行方法（被释放或者没有创建完毕，都不可以调用空间的invoke方法了）
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Boolean CanControlInvoke(Control c)
        {
            return !(c.Disposing || c.IsDisposed || !c.Created);
        }

        /// <summary>
        /// 通过UI线程同步去访问UI元素(支持线程安全访问)；
        /// 注意：在deletegate委托里面，必须先调用此方法CanControlInvoke()判断是否可以调用空间的UI线程执行方法，否则可能会报错
        /// </summary>
        /// <param name="c"></param>
        /// <param name="method"></param>
        public static Object ControlInvoke(Control c, Delegate method, params Object[] args)
        {
            if (c.InvokeRequired) return c.Invoke(method, args);
            else return method.DynamicInvoke(args);
        }

        /// <summary>
        /// ControlInvoke方法的泛型版本
        /// </summary>
        /// <param name="c"></param>
        /// <param name="method"></param>
        public static T ControlInvoke<T>(Control c, Delegate method, params Object[] args)
        {
            Object value = ControlInvoke(c, method, args);
            return (T)value;
        }

        /// <summary>
        /// 通过UI线程异步去访问UI元素(支持线程安全访问)；
        /// 注意：在deletegate委托里面，必须先调用此方法CanControlInvoke()判断是否可以调用空间的UI线程执行方法，否则可能会报错
        /// </summary>
        /// <param name="c"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        public static void ControlBeginInvoke(Control c, Delegate method, params Object[] args)
        {
            if (c.InvokeRequired) c.BeginInvoke(method, args);
            else method.DynamicInvoke(args);
        }
    }
}
