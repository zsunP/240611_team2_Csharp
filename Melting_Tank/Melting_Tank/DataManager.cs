using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melting_Tank
{
    internal class DataManager
    {
        public static List<MeltingTank> datas = new List<MeltingTank>();

        static DataManager()
        {
            Load();
        }

        public static void Load(ComboBox cbox, DateTimePicker dPicker, TextBox startIdx, TextBox endIdx)
        {
            string selected=cbox.SelectedItem.ToString().Trim();            
            string startindex=startIdx.Text.Trim();
            string endindex=endIdx.Text.Trim();

          
                if (selected == null)
                {
                    MessageBox.Show("검색 조건을 선택하세요.");
                    return;
                }
                else if (selected != null)
                {
                if (selected == "STD_DT")
                {
                    // 유효성을 처리하므로써 값이 변경되지 않습니다.
                    startIdx.Text = "";
                    endIdx.Text = "";
                }
                else if (selected == "TAG")
                {
                    // startIdx만 설정하고 endIdx는 비웁니다.
                    startIdx.Text = startindex;
                    endIdx.Text = "";
                }
                else
                {
                    // 두 텍스트 상자에 받아온 값을 그대로 설정합니다.
                    startIdx.Text = startindex;
                    endIdx.Text = endindex;
                }

                try
                    {
                        DBHelper.selectQuery(cbox, dPicker, startIdx, endIdx);
                        datas.Clear();
                        foreach (DataRow item in DBHelper.dt.Rows)
                        {
                            MeltingTank m = new MeltingTank();
                            m.STD_DT = string.IsNullOrEmpty(item["STD_DT"].ToString()) ? DateTime.Now : DateTime.Parse(item["STD_DT"].ToString());
                            m.NUM = int.Parse(item["NUM"].ToString());
                            m.MELT_TEMP = int.Parse(item["MELT_TEMP"].ToString());
                            m.MOTORSPEED = int.Parse(item["MOTORSPEED"].ToString());
                            m.MELT_WEIGHT = int.Parse(item["MELT_WEIGHT"].ToString());
                            m.INSP = (float)Math.Round(float.Parse(item["INSP"].ToString()), 2);
                            m.TAG = item["TAG"].ToString();

                        /*for (int i = 0; i < dataGridView.Main Rows.Count; i++)
                            {
                            dataGridView1.Rows[i].Cells["번호"].Value = i + 1;
                            }*/




                        datas.Add(m);

                        }


                    }
                    catch (Exception ex)
                    {

                    }
                }
          
           

                    
            

        }

        public static void Load()
        {
            try
            {
                DBHelper.SelectALL();
                datas.Clear();
                foreach (DataRow item in DBHelper.dt.Rows)
                {
                    MeltingTank m = new MeltingTank();
                    m.STD_DT = string.IsNullOrEmpty(item["STD_DT"].ToString())? DateTime.Now: DateTime.Parse(item["STD_DT"].ToString());                    
                    m.NUM = int.Parse(item["NUM"].ToString());
                    m.MELT_TEMP = int.Parse(item["MELT_TEMP"].ToString());
                    m.MOTORSPEED = int.Parse(item["MOTORSPEED"].ToString());
                    m.MELT_WEIGHT = int.Parse(item["MELT_WEIGHT"].ToString());
                    m.INSP = (float)Math.Round(float.Parse(item["INSP"].ToString()),2);
                    m.TAG = item["TAG"].ToString();
                    

                    datas.Add(m);
                }


            }
            catch (Exception ex)
            {

            }


        }
        public static void Load(DateTimePicker daPicker, ComboBox ctime)
        {
            string selecttime = ctime.SelectedItem.ToString().Trim();
           

            try
            {
                DBHelper.SelectChart(daPicker,ctime);
                datas.Clear();
                foreach (DataRow item in DBHelper.dt.Rows)
                {
                    MeltingTank m = new MeltingTank();
                    m.STD_DT = string.IsNullOrEmpty(item["STD_DT"].ToString()) ? DateTime.Now : DateTime.Parse(item["STD_DT"].ToString());
                    m.NUM = int.Parse(item["NUM"].ToString());
                    m.MELT_TEMP = int.Parse(item["MELT_TEMP"].ToString());
                    m.MOTORSPEED = int.Parse(item["MOTORSPEED"].ToString());
                    m.MELT_WEIGHT = int.Parse(item["MELT_WEIGHT"].ToString());
                    m.INSP = (float)Math.Round(float.Parse(item["INSP"].ToString()), 2);
                    m.TAG = item["TAG"].ToString();


                    datas.Add(m);

                }


            }
            catch (Exception ex)
            {

            }

        }

            public static void printLog(string v)
        {
            DirectoryInfo DI = new DirectoryInfo("DBhistory");
            if (DI.Exists == false) { }
            DI.Create();
            using (StreamWriter w = new StreamWriter(@"DBhistory\DBhistory.txt", true))
            {

                string now = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}]";
                w.WriteLine(now + v);



            }

        }
    }
}
