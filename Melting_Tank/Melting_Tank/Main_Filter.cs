using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Melting_Tank
{
    public partial class Form_Filter : Form
    {
        public Form_Filter()
        {
            InitializeComponent();
            comboBox_Filter.SelectedIndex = 0;
        }

        private void comboBox_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox_Filter.SelectedItem.ToString();


            // 선택된 값에 따라 Label의 텍스트를 변경합니다.
            switch (selectedValue)
            {
                case "NUM":
                    notice_Filter.Text = "NUM값은 index값이니 정수만 입력해주세요";
                    break;
                case "MELT_TEMP":
                    notice_Filter.Text = "MELT_TEMP 값은 정수로 입력해주세요";
                    break;
                case "MOTORSPEED":
                    notice_Filter.Text = "MOTORSPEED값은 정수로 입력해주세요";
                    break;
                case "MELT_WEIGHT":
                    notice_Filter.Text = "MELT_WEIGHT값은 정수로 입력해주세요";
                    break;
                case "INSP":
                    notice_Filter.Text = "INSP값은 소숫점2째자리까지 입력해주세요";
                    break;
                case "TAG":
                    notice_Filter.Text = "TAG값은 Ok가 양품 NG가 불량을의미합니다";
                    break;


                default:
                    notice_Filter.Text = "입력값의 정수실수여부를 확인해주세요";
                    break;
            }
        }
    }
}
