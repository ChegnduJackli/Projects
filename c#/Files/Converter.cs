 
#region 泛型数据类型转换
        /// <summary>
        /// 泛型数据类型转换
        /// </summary>
        /// <typeparam name="T">自定义数据类型</typeparam>
        /// <param name="value">传入需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static T ConvertType<T>(object value, T defaultValue)
        {
            return (T)ConvertToT<T>(value, defaultValue);
        }
        /// <summary>
        /// 转换数据类型
        /// </summary>
        /// <typeparam name="T">自定义数据类型</typeparam>
        /// <param name="myvalue">传入需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        private static object ConvertToT<T>(object myvalue, T defaultValue)
        {
            try
            {
                TypeCode typeCode = System.Type.GetTypeCode(typeof(T));
                if (myvalue == null)
                    return defaultValue;
                string value = myvalue.ToString();
                switch (typeCode)
                {
                    case TypeCode.Boolean:
                        bool flag = false;
                        if (bool.TryParse(value, out flag))
                            return flag;
                        return defaultValue;
                    case TypeCode.Char:
                        char c;
                        if (Char.TryParse(value, out c))
                            return c;
                        return defaultValue;
                    case TypeCode.SByte:
                        sbyte s = 0;
                        if (SByte.TryParse(value, out s))
                            return s;
                        return defaultValue;
                    case TypeCode.Byte:
                        byte b = 0;
                        if (Byte.TryParse(value, out b))
                            return b;
                        return defaultValue;
                    case TypeCode.Int16:
                        Int16 i16 = 0;
                        if (Int16.TryParse(value, out i16))
                            return i16;
                        return defaultValue;
                    case TypeCode.UInt16:
                        UInt16 ui16 = 0;
                        if (UInt16.TryParse(value, out ui16))
                            return ui16;
                        return defaultValue;
                    case TypeCode.Int32:
                        int i = 0;
                        if (Int32.TryParse(value, out i))
                            return i;
                        return defaultValue;
                    case TypeCode.UInt32:
                        UInt32 ui32 = 0;
                        if (UInt32.TryParse(value, out ui32))
                            return ui32;
                        return defaultValue;
                    case TypeCode.Int64:
                        Int64 i64 = 0;
                        if (Int64.TryParse(value, out i64))
                            return i64;
                        return defaultValue;
                    case TypeCode.UInt64:
                        UInt64 ui64 = 0;
                        if (UInt64.TryParse(value, out ui64))
                            return ui64;
                        return defaultValue;
                    case TypeCode.Single:
                        Single single = 0;
                        if (Single.TryParse(value, out single))
                            return single;
                        return defaultValue;
                    case TypeCode.Double:
                        double d = 0;
                        if (Double.TryParse(value, out d))
                            return d;
                        return defaultValue;
                    case TypeCode.Decimal:
                        decimal de = 0;
                        if (Decimal.TryParse(value, out de))
                            return de;
                        return defaultValue;
                    case TypeCode.DateTime:
                        DateTime dt;
                        if (DateTime.TryParse(value, out dt))
                            return dt;
                        return defaultValue;
                    case TypeCode.String:
                        if (value.Length == 0)
                            return string.Empty;
                        return value.ToString();
                }
                throw new ArgumentNullException("defaultValue", "Cannot be Empty,Object,DBNull");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

调用：
 //可以用于实际验证中
            string str = txtNum.Text.Trim();
            int result= ConvertTOType.ConvertType<int>(str, -1);//只验证一次
            if (result < 0)
            {
                txtResult.Text = "Invalid Data";
                return;
            }
            txtResult.Text = result.ToString();

调用，主要用于winform 程序中
  string str = this.textBox1.Text;

            decimal dRet = ConvertToType<decimal>(str, "Qty", true,decimal.MinValue);
            {
                if(dRet == decimal.MinValue)
                {
                    return ;
                }
            }

  #region convert to specified type
        /// <summary>
        /// Convert to specified Type,if convert succeeded ,then
        /// return results after conversion ,otherwise,return default value
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="value">the Source Data need to convert</param>
        /// <param name="sMessage">The error message</param>
        /// <param name="IsGreaterThanZero">Is Greater than zero or not</param>
        /// <param name="defaultValue">convert failed return default value</param>
        /// <returns>specified value after conversion</returns>
        public T ConvertToType<T>(object value, object sMessage, bool IsGreaterThanZero, T defaultValue)
        {
            return (T)ValidateType<T>(value, sMessage, IsGreaterThanZero, defaultValue);
        }

        /// <summary>
        /// Convert to specified Type
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="myvalue">the Source data need to convert</param>
        /// <param name="sMessage">The error message</param>
        /// <param name="IsGreaterThanZero">Is Greater than zero or not</param>
        /// <param name="defaultValue">convert failed return default value</param>
        /// <returns>if converted successfully,then return results after conversion ,otherwise,return default value </returns>
        private object ValidateType<T>(object myvalue, object sMessage,bool IsGreaterThanZero,T defaultValue)
        {
            try
            {
                TypeCode typeCode = System.Type.GetTypeCode(typeof(T));
                if (myvalue == null || myvalue.ToString().Length == 0)
                {
                    MessageBox.Show(sMessage.ToString() + " cannot be empty", "Infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return defaultValue;
                }
                string value = myvalue.ToString();
                switch (typeCode)
                {
                    case TypeCode.Int32:
                        int i = 0;
                        if (Int32.TryParse(value, out i))
                        {
                            if (IsGreaterThanZero && i <= 0)
                            {
                                MessageBox.Show(sMessage.ToString() + " must greater than zero", "Infomation", MessageBoxButtons.OKCancel, 										MessageBoxIcon.Information);
                                return defaultValue;
                            }
                            return i;
                        }
                        MessageBox.Show("Invald " + sMessage.ToString(), "Infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        return defaultValue;

                    case TypeCode.Decimal:
                        decimal dc = 0;
                        if (Decimal.TryParse(value, out dc))
                        {
                            if (IsGreaterThanZero && dc <= 0)
                            {
                                MessageBox.Show(sMessage.ToString() + " must greater than zero", "Infomation", MessageBoxButtons.OKCancel, 										MessageBoxIcon.Information);
                                return defaultValue;
                            }
                            return dc;
                        }
                        MessageBox.Show("Invald " + sMessage.ToString(), "Infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        return defaultValue;

                    case TypeCode.Double:
                        double db = 0;
                        if (Double.TryParse(value, out db))
                        {
                            if (IsGreaterThanZero && db <= 0)
                            {
                                MessageBox.Show(sMessage.ToString() + " must greater than zero", "Infomation", MessageBoxButtons.OKCancel, 										MessageBoxIcon.Information);
                                return defaultValue;
                            }
                            return db;
                        }
                        MessageBox.Show("Invald " + sMessage.ToString(), "Infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        return defaultValue;

                }
                return defaultValue;
            }
            catch 
            {
                return defaultValue;
            }
        }
        #endregion


