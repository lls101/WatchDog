using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchDog.Commons
{
    public static class ComboBoxExtentions
    {

        /// <summary>
        /// 绑定ComboBoxEx数据源到枚举类型
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="enumType"></param>
        /// <param name="selectIndex">默认选择index</param>
        public static void BindToEnumName(this ComboBox cmb, Type enumType, int selectIndex = 0)
        {
            cmb.DataSource = Enum.GetNames(enumType);
        }
        /// <summary>
        /// 绑定ComboBoxEx数据源到枚举类型并设置
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="enumType"></param>
        /// <param name="t">默认选择项</param>
        public static void BindToEnumNameWithDefault<T>(this ComboBox cmb, Type enumType, T t)
        {
            cmb.DataSource = Enum.GetNames(enumType);
            SetSelectedItemToEnum(cmb, t);
        }
        /// <summary>
        ///  获取选择项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmb"></param>
        /// <returns></returns>
        public static T GetSelectedItemToEnum<T>(this ComboBox cmb)
        {
            return (T)Enum.Parse(typeof(T), cmb.SelectedItem.ToString(), false);
        }

        /// <summary>
        /// 设置选定项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmb"></param>
        /// <param name="t"></param>
        public static void SetSelectedItemToEnum<T>(this ComboBox cmb, T t)
        {
            cmb.SelectedItem = t.ToString();
        }

    }
}
