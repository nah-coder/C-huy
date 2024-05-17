using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanSach.database
{
    internal class IDAuto
    {
        Database db;
        public IDAuto()
        {
            db = new Database();
        }

        public string LayIdTuDong(string tenBang, string kiTu)
        {
            string sql = $"Select * from {tenBang}";
            DataTable tb = db.Execute(sql);
            string ma;
            if (tb.Rows.Count <= 0)
                ma = $"{kiTu}001";
            else
            {
                int k;
                ma = kiTu;
                if (kiTu.Length < 3)
                    k = Convert.ToInt32(tb.Rows[tb.Rows.Count - 1][0].ToString().Substring(2, 3));
                else
                    k = Convert.ToInt32(tb.Rows[tb.Rows.Count - 1][0].ToString().Substring(3, 3));
                k += 1;
                if (k < 10)
                    ma += "00";
                else if (k < 100)
                    ma += "0";
                ma += k.ToString();
            }
            return ma;
        }

    }
}
