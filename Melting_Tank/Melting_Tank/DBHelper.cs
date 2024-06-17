using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Collections;

namespace Melting_Tank
{

    public class DBHelper
    {




        private static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;

        private static string TABLENAME = " Melting_Tank ";

        private static void connectDB()
        {

            string dataSource = "local";
            string db = "MeltTankDB";
            string security = "SSPI";

            conn.ConnectionString = $"Data Source=({dataSource}); " +
                $"initial Catalog={db}; " +
                $"integrated Security = {security};" +
                $"Timeout=3";

            conn = new SqlConnection(conn.ConnectionString);
            conn.Open();



        }

        public static void selectQuery(ComboBox cbox, DateTimePicker dPicker, TextBox startIdx, TextBox endIdx)
        {
            dPicker.Format = DateTimePickerFormat.Short;
            string selected = cbox.SelectedItem.ToString().Trim();
            string date = dPicker.Value.ToString("yyyy-MM-dd");
            string startindex = startIdx.Text.Trim();
            string endindex = endIdx.Text.Trim();


            try
            {
                connectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;


                if (selected == "STD_DT")
                {
                    cmd.CommandText = "SELECT * FROM " + TABLENAME + " WHERE YEAR(STD_DT) = YEAR(@date) AND MONTH(STD_DT) = MONTH(@date) AND DAY(STD_DT) = DAY(@date)";

                    cmd.Parameters.AddWithValue("@date", date);
                }
                else if (selected == "TAG")
                {
                    cmd.CommandText = "SELECT * FROM " + TABLENAME + " WHERE TAG = @startindex";
                    cmd.Parameters.AddWithValue("@startindex", startindex);
                }
                else if (selected == "NUM" || selected == "MELT_TEMP" || selected == "MOTORSPEED" || selected == "MELT_WEIGHT" || selected == "INSP")
                {

                   
                    cmd.CommandText = "SELECT DISTINCT * FROM " + TABLENAME + " WHERE " + selected + " BETWEEN @startindex AND @endindex ORDER BY " + selected;

                    cmd.Parameters.AddWithValue("@startindex", startindex);
                    cmd.Parameters.AddWithValue("@endindex", endindex);
                }


                da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, TABLENAME);
                dt = ds.Tables[0];

            }
            catch (Exception ex)
            {

                DataManager.printLog("select" + ex.StackTrace);
            }
            finally
            {

                conn.Close();
            }



        }


        /*  cmd.CommandText = "select * from " + TABLENAME + " where" + "=";

            cmd.CommandTEXT = "select * from" + TABLENAME + "where" + NUM + "between" + indexStart + "AND" indexEnd + "order by"+NUM; "
            "SELECT TOP(30) *FROM table_nameWHERE id BETWEEN 20 AND 50 ORDER BY id;"
            SELECT *
            FROM YourTableWHERE YourDateTimeColumn = CONVERT(DATETIME, @DateString, 120);*/
        public static void SelectALL()
        {



            try
            {
                connectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from " + TABLENAME;




                da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, TABLENAME);
                dt = ds.Tables[0];

            }
            catch (Exception ex)
            {

                DataManager.printLog("select" + ex.StackTrace);
            }
            finally
            {

                conn.Close();
            }

        }
        public static void SelectChart(DateTimePicker daPicker, ComboBox ctime)
        {
            daPicker.Format = DateTimePickerFormat.Short;
            string datechart = daPicker.Value.ToString("yyyy-MM-dd");
            string selecttime = ctime.SelectedItem.ToString().Trim();

            try
            {
                connectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (selecttime == null)
                {
                   
                    cmd.CommandText = "SELECT * FROM " + TABLENAME + " WHERE YEAR(STD_DT) = YEAR(@date) AND MONTH(STD_DT) = MONTH(@date) AND DAY(STD_DT) = DAY(@date)";
                    cmd.Parameters.AddWithValue("@date", datechart);
                }
                else
                {
                    
                    cmd.CommandText = @"SELECT * FROM " + TABLENAME + @"
                            WHERE YEAR(STD_DT) = YEAR(@date)
                            AND MONTH(STD_DT) = MONTH(@date)
                            AND DAY(STD_DT) = DAY(@date)
                            AND CAST(STD_DT AS TIME) >= @selectedTime
                            AND CAST(STD_DT AS TIME) < DATEADD(HOUR, 1, @selectedTime + ' 00:00:00.000')";

                    cmd.Parameters.AddWithValue("@date", datechart);
                    cmd.Parameters.AddWithValue("@selectedTime", selecttime);
                }

                da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, TABLENAME);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                conn.Close();
            }

            
        }
    }
        


    }

