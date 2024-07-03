using HMI.CO.General;
using HMI.Resources;
using System;
using System.Collections.Generic;

namespace HMI.CO.PD
{
    class Barcode
    {
        public Barcode(string _value)
        {
            Value = _value;

            if (Value != "")
            {
                Decode();
            }
        }

        #region - - - Properties - - -

        public string Value { get ; } = "";
        public Dictionary<string, string> Data { get; } = new Dictionary<string, string>();
        #endregion

        #region - - - Methods - - -
        void Decode() 
        {
            try 
            {
                string temp = Value.Replace("{", "").Replace("}", "");

                int j = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] != 92) //backslash
                    {
                        if (temp[i] == 59 || i == temp.Length - 1) //;
                        {
                            if (i != temp.Length - 1)
                            {
                                string[] t = Split(temp.Substring(j, i - j));
                                Data.Add(t[0], t[1]);
                                j = i + 1;
                            }
                            else
                            {
                                string[] t = Split(temp.Substring(j, i - j + 1));
                                Data.Add(t[0], t[1]);
                            }
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            catch 
            {
                new MessageBoxTask("@Scanner.Text5", "@Scanner.Text4", MessageBoxIcon.Error);
            }
        }
        string[] Split(string s) 
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != 92) //backslash
                {
                    if (s[i] == 58) //:
                    {
                        return new string[] { s.Substring(0, i), Clear(s.Substring(i + 1, s.Length - (i + 1))) };
                    }
                }
                else
                {
                    i++;
                }
            }
            return new string[] { };
        }
        string Clear(string s)
        {
            string t = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != 92) //backslash
                {
                    t += s[i];
                }
                else
                {
                    i++;
                    t += s[i];
                }
            }
            return t;
        }

        #endregion
    }


}
