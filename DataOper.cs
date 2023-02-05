using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.IO;
using System.Data.OleDb;
using System.Collections;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.Mail;
using System.Data.SqlClient;

namespace Web_GZJL
{
    public class DataOper
    {
        public DataOper()
        {
            //
            //TODO:�ڴ˴���ӹ��캯���߼�
            //
        }



        #region ���ܺ���

        /// <summary>
        /// md5����
        /// </summary>
        /// <param name="pass">ԭʼ����</param>
        /// <returns></returns>
        public static string encryptmd5(string pass)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "md5");
        }

        /// <summary>
        /// sha1����
        /// </summary>
        /// <param name="pass">ԭʼ����</param>
        /// <returns></returns>
        public static string encryptsha1(string pass)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "sha1");

        }


        /// <summary>
        /// ���������des����
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string getDesEncryptPassword(string password)
        {
            //ʵ����des�����㷨�Ķ���
            DESCryptoServiceProvider aa = new DESCryptoServiceProvider();
            aa.Key = ASCIIEncoding.ASCII.GetBytes("fGyu+_4#");
            aa.IV = ASCIIEncoding.ASCII.GetBytes("fGyu+_4#");
            //�õ�һ�����ܶ���
            ICryptoTransform bb = aa.CreateEncryptor();

            byte[] b = Encoding.UTF8.GetBytes(password);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, bb, CryptoStreamMode.Write);
            cs.Write(b, 0, b.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }


        /// <summary>
        /// ���������des����
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string getBankTrans(string password)
        {
            if (password != "")
            {
                //ʵ����des�����㷨�Ķ���
                DESCryptoServiceProvider aa = new DESCryptoServiceProvider();
                aa.Key = ASCIIEncoding.ASCII.GetBytes("fGyu+_4#");
                aa.IV = ASCIIEncoding.ASCII.GetBytes("fGyu+_4#");
                //���ɽ����㷨
                ICryptoTransform bb = aa.CreateDecryptor();
                byte[] b1 = new byte[password.Length];
                //ת��ת�����ֵ
                b1 = Convert.FromBase64String(password);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, bb, CryptoStreamMode.Write);
                cs.Write(b1, 0, b1.Length);
                cs.FlushFinalBlock();
                Encoding ed = new UTF8Encoding();
                return ed.GetString(ms.ToArray());
            }
            else
                return "";
        }

        #endregion

        #region ���ú���

        /// <summary>
        /// ת���ַ���
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string setTrueString(string str)
        {
            str = str.Replace("'", "''");
            str = str.Replace("\"", "��");
            str = str.Replace("--", "����");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("%", "");
            return str.Trim();
        }

        /// <summary>
        /// �ָ��ַ���
        /// </summary>
        /// <param name="v">�ַ���</param>
        /// <param name="delimstr">�ָ��</param>
        /// <returns></returns>
        public static string[] Split(string v, string delimstr)
        {
            string[] a = null;
            string delimStr = delimstr;
            char[] delimiter = delimStr.ToCharArray();
            a = v.Split(delimiter);
            return a;
        }


        /// <summary>
        /// ȡ���ֵ�ƴ����
        /// </summary>
        /// <param name="hz"></param>
        /// <returns></returns>
        public static string GetFirstLetter(string hz)
        {

            string ls_second_eng = "CJWGNSPGCGNESYPBTYYZDXYKYGTDJNNJQMBSGZSCYJSYYQPGKBZGYCYWJKGKLJSWKPJQHYTWDDZLSGMRYPYWWCCKZNKYDGTTNGJEYKKZYTCJNMCYLQLYPYQFQRPZSLWBTGKJFYXJWZLTBNCXJJJJZXDTTSQZYCDXXHGCKBPHFFSSWYBGMXLPBYLLLHLXSPZMYJHSOJNGHDZQYKLGJHSGQZHXQGKEZZWYSCSCJXYEYXADZPMDSSMZJZQJYZCDJZWQJBDZBXGZNZCPWHKXHQKMWFBPBYDTJZZKQHYLYGXFPTYJYYZPSZLFCHMQSHGMXXSXJJSDCSBBQBEFSJYHWWGZKPYLQBGLDLCCTNMAYDDKSSNGYCSGXLYZAYBNPTSDKDYLHGYMYLCXPYCJNDQJWXQXFYYFJLEJBZRXCCQWQQSBNKYMGPLBMJRQCFLNYMYQMSQTRBCJTHZTQFRXQ" +
                "HXMJJCJLXQGJMSHZKBSWYEMYLTXFSYDSGLYCJQXSJNQBSCTYHBFTDCYZDJWYGHQFRXWCKQKXEBPTLPXJZSRMEBWHJLBJSLYYSMDXLCLQKXLHXJRZJMFQHXHWYWSBHTRXXGLHQHFNMNYKLDYXZPWLGGTMTCFPAJJZYLJTYANJGBJPLQGDZYQYAXBKYSECJSZNSLYZHZXLZCGHPXZHZNYTDSBCJKDLZAYFMYDLEBBGQYZKXGLDNDNYSKJSHDLYXBCGHXYPKDJMMZNGMMCLGWZSZXZJFZNMLZZTHCSYDBDLLSCDDNLKJYKJSYCJLKOHQASDKNHCSGANHDAASHTCPLCPQYBSDMPJLPCJOQLCDHJJYSPRCHNWJNLHLYYQYYWZPTCZGWWMZFFJQQQQYXACLBHKDJXDGMMYDJXZLLSYGXGKJRYWZWYCLZMSSJZLDBYDCFCXYHLXCHYZJQSFQAGMNYXPFRKSSB" +
                "JLYXYSYGLNSCMHCWWMNZJJLXXHCHSYDSTTXRYCYXBYHCSMXJSZNPWGPXXTAYBGAJCXLYSDCCWZOCWKCCSBNHCPDYZNFCYYTYCKXKYBSQKKYTQQXFCWCHCYKELZQBSQYJQCCLMTHSYWHMKTLKJLYCXWHEQQHTQHZPQSQSCFYMMDMGBWHWLGSSLYSDLMLXPTHMJHWLJZYHZJXHTXJLHXRSWLWZJCBXMHZQXSDZPMGFCSGLSXYMJSHXPJXWMYQKSMYPLRTHBXFTPMHYXLCHLHLZYLXGSSSSTCLSLDCLRPBHZHXYYFHBBGDMYCNQQWLQHJJZYWJZYEJJDHPBLQXTQKWHLCHQXAGTLXLJXMSLXHTZKZJECXJCJNMFBYCSFYWYBJZGNYSDZSQYRSLJPCLPWXSDWEJBJCBCNAYTWGMPAPCLYQPCLZXSBNMSGGFNZJJBZSFZYNDXHPLQKZCZWALSBCCJXJYZGWKYP" +
                "SGXFZFCDKHJGXDLQFSGDSLQWZKXTMHSBGZMJZRGLYJBPMLMSXLZJQQHZYJCZYDJWBMJKLDDPMJEGXYHYLXHLQYQHKYCWCJMYYXNATJHYCCXZPCQLBZWWYTWBQCMLPMYRJCCCXFPZNZZLJPLXXYZTZLGDLDCKLYRZZGQTGJHHHJLJAXFGFJZSLCFDQZLCLGJDJCSNCLLJPJQDCCLCJXMYZFTSXGCGSBRZXJQQCTZHGYQTJQQLZXJYLYLBCYAMCSTYLPDJBYREGKLZYZHLYSZQLZNWCZCLLWJQJJJKDGJZOLBBZPPGLGHTGZXYGHZMYCNQSYCYHBHGXKAMTXYXNBSKYZZGJZLQJDFCJXDYGJQJJPMGWGJJJPKQSBGBMMCJSSCLPQPDXCDYYKYFCJDDYYGYWRHJRTGZNYQLDKLJSZZGZQZJGDYKSHPZMTLCPWNJAFYZDJCNMWESCYGLBTZCGMSSLLYXQSXSBSJS" +
                "BBSGGHFJLWPMZJNLYYWDQSHZXTYYWHMCYHYWDBXBTLMSYYYFSXJCSDXXLHJHFSSXZQHFZMZCZTQCXZXRTTDJHNNYZQQMNQDMMGYYDXMJGDHCDYZBFFALLZTDLTFXMXQZDNGWQDBDCZJDXBZGSQQDDJCMBKZFFXMKDMDSYYSZCMLJDSYNSPRSKMKMPCKLGDBQTFZSWTFGGLYPLLJZHGJJGYPZLTCSMCNBTJBQFKTHBYZGKPBBYMTTSSXTBNPDKLEYCJNYCDYKZDDHQHSDZSCTARLLTKZLGECLLKJLQJAQNBDKKGHPJTZQKSECSHALQFMMGJNLYJBBTMLYZXDCJPLDLPCQDHZYCBZSCZBZMSLJFLKRZJSNFRGJHXPDHYJYBZGDLQCSEZGXLBLGYXTWMABCHECMWYJYZLLJJYHLGBDJLSLYGKDZPZXJYYZLWCXSZFGWYYDLYHCLJSCMBJHBLYZLYCBLYDPDQYSXQZB" +
                "YTDKYXJYYCNRJMDJGKLCLJBCTBJDDBBLBLCZQRPXJCGLZCSHLTOLJNMDDDLNGKAQHQHJGYKHEZNMSHRPHQQJCHGMFPRXHJGDYCHGHLYRZQLCYQJNZSQTKQJYMSZSWLCFQQQXYFGGYPTQWLMCRNFKKFSYYLQBMQAMMMYXCTPSHCPTXXZZSMPHPSHMCLMLDQFYQXSZYJDJJZZHQPDSZGLSTJBCKBXYQZJSGPSXQZQZRQTBDKYXZKHHGFLBCSMDLDGDZDBLZYYCXNNCSYBZBFGLZZXSWMSCCMQNJQSBDQSJTXXMBLTXZCLZSHZCXRQJGJYLXZFJPHYMZQQYDFQJJLZZNZJCDGZYGCTXMZYSCTLKPHTXHTLBJXJLXSCDQXCBBTJFQZFSLTJBTKQBXXJJLJCHCZDBZJDCZJDCPRNPQCJPFCZLCLZXZDMXMPHJSGZGSZZQJYLWTJPFSYASMCJBTZKYCWMYTCSJJLJCQLWZM" +
                "ALBXYFBPNLSFHTGJWEJJXXGLLJSTGSHJQLZFKCGNNDSZFDEQFHBSAQTGLLBXMMYGSZLDYDQMJJRGBJTKGDHGKBLQKBDMBYLXWCXYTTYBKMRTJZXQJBHLMHMJJZMQASLDCYXYQDLQCAFYWYXQHZ";
            string ls_second_ch = "ءآأؤإئابةتثجحخدذرزسشصضطظعغػؼؽ" +
                "ؾؿ������������������������������������������������������������������������������������������������������������������������������١٢٣٤٥٦٧٨٩٪٫٬٭ٮٯٰٱٲٳٴٵٶٷٸٹٺٻټٽپٿ������������������������������������������������������������������������������������������������������������������������������ڡڢڣڤڥڦڧڨکڪګڬڭڮگڰڱڲڳڴڵڶڷڸڹںڻڼڽھڿ����������������������������������������������������������������������������������" +
                "��������������������������������������������ۣۡۢۤۥۦۧۨ۩۪ۭ۫۬ۮۯ۰۱۲۳۴۵۶۷۸۹ۺۻۼ۽۾ۿ������������������������������������������������������������������������������������������������������������������������������ܡܢܣܤܥܦܧܨܩܪܫܬܭܮܯܱܴܷܸܹܻܼܾܰܲܳܵܶܺܽܿ������������������������������������������������������������������������������������������������������������������������������ݡݢݣݤݥݦݧݨݩݪݫݬݭݮݯݰݱݲݳݴݵݶ" +
                "ݷݸݹݺݻݼݽݾݿ������������������������������������������������������������������������������������������������������������������������������ޡޢޣޤޥަާިީުޫެޭޮޯްޱ޲޳޴޵޶޷޸޹޺޻޼޽޾޿������������������������������������������������������������������������������������������������������������������������������ߡߢߣߤߥߦߧߨߩߪ߲߫߬߭߮߯߰߱߳ߴߵ߶߷߸߹ߺ߻߼߽߾߿������������������������������������������������������������������������" +
                "�����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
                "����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
                "���������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
                "������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
                "�����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
                "��������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
                "���������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
                "������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
                "��������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
                "������������������������������������������������������������������������������������������������������������������������������������������������������������������������������";
            byte[] array = new byte[2];

            string return_py = "";
            for (int i = 0; i < hz.Length; i++)
            {
                array = System.Text.Encoding.Default.GetBytes(hz[i].ToString());
                if (array[0] < 176) //.�Ǻ���
                {
                    return_py += hz[i];
                }
                else if (array[0] >= 176 && array[0] <= 215) //һ������
                {

                    if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "z";
                    else if (hz[i].ToString().CompareTo("ѹ") >= 0)
                        return_py += "y";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "x";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "w";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "t";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "s";
                    else if (hz[i].ToString().CompareTo("Ȼ") >= 0)
                        return_py += "r";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "q";
                    else if (hz[i].ToString().CompareTo("ž") >= 0)
                        return_py += "p";
                    else if (hz[i].ToString().CompareTo("Ŷ") >= 0)
                        return_py += "o";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "n";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "m";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "l";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "k";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "j";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "h";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "g";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "f";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "e";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "d";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "c";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "b";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "a";
                }
                else if (array[0] >= 215) //��������
                {
                    return_py += ls_second_eng.Substring(ls_second_ch.IndexOf(hz[i].ToString(), 0), 1);
                }
            }
            return return_py.ToUpper();
        }



        /// <summary>
        /// �ж��Ƿ�������
        /// </summary>
        /// <param name="strNumber">�ַ���</param>
        /// <returns></returns>
        public static bool IsNumber(String strNumber)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strNumber);
        }


        /// <summary>
        /// �̵��Ƿ��Ǹ�����
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static bool IsFloat(String strNumber)
        {
            Regex objNotPositivePattern = new Regex("[^0-9.]");
            Regex objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");

            if (!(!objNotPositivePattern.IsMatch(strNumber) && objPositivePattern.IsMatch(strNumber) && !objTwoDotPattern.IsMatch(strNumber)))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// ���list��ѡ��ְ
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        public static void ListValue(System.Web.UI.WebControls.DropDownList list, string value)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Value == value)
                {
                    list.SelectedIndex = i;
                    return;
                }
            }
        }

        /// <summary>
        /// �����ַ�������
        /// </summary>
        /// <param name="str"></param>
        public static int strLength(string str)
        {
            byte[] mybyte;
            mybyte = System.Text.Encoding.Default.GetBytes(str);
            return mybyte.Length;
        }

        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="stringToSub"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetFirstString(string stringToSub, int length)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = stringToSub.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;
            bool isCut = false;
            for (int i = 0; i < stringChar.Length; i++)
            {
                if (regex.IsMatch((stringChar[i]).ToString()))
                {
                    sb.Append(stringChar[i]);
                    nLength += 2;
                }
                else
                {
                    sb.Append(stringChar[i]);
                    nLength = nLength + 1;
                }

                if (nLength > length)
                {
                    isCut = true;
                    break;
                }
            }
            if (isCut)
                return sb.ToString() + "...";
            else
                return sb.ToString();
        }

        public static string setDBNull(object dr)
        {
            if (dr == DBNull.Value)
                return "";
            else
                return dr.ToString();
        }

        /// <summary>
        /// �ϲ�GridView��ĳ����ͬ��Ϣ���У���Ԫ�� 
        /// </summary>
        /// <param name="GridView1">GridView</param>
        /// <param name="cellNum">�ڼ���</param>
        public static void GroupRows(GridView GridView1, int cellNum)
        {
            int i = 0, rowSpanNum = 1;
            while (i < GridView1.Rows.Count - 1)
            {
                GridViewRow gvr = GridView1.Rows[i];

                for (++i; i < GridView1.Rows.Count; i++)
                {
                    GridViewRow gvrNext = GridView1.Rows[i];
                    if (gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text)
                    {
                        gvrNext.Cells[cellNum].Visible = false;
                        rowSpanNum++;
                    }
                    else
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                        rowSpanNum = 1;
                        break;
                    }

                    if (i == GridView1.Rows.Count - 1)
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                    }
                }
            }
        }

        #endregion

        #region �����㷨

        /// <summary>
        /// ������ˮ���
        /// </summary>
        /// <param name="xh"></param>
        /// <returns>��ˮ���</returns>
        private static string getxh(int xh)
        {
            string num;

            num = xh.ToString();
            while (num.Length - 3 < 0)
            {
                num = "0" + num;
            }
            return num;
        }

        /// <summary>
        /// ���������ַ���
        /// </summary>
        /// <returns>�����ַ���(YYMMDD)</returns>
        private static string getrq()
        {
            string year = System.DateTime.Today.Year.ToString();
            string month = System.DateTime.Today.Month.ToString();
            string day = System.DateTime.Today.Day.ToString();

            if (month.Length == 1)
            {
                month = "0" + month;
            }
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            return year + month + day;
        }

        public static int ASC(String Data) //��ȡASC��
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(Data);
            int p = 0;

            if (b.Length == 1) //���ΪӢ���ַ�ֱ�ӷ���
                return (int)b[0];
            for (int i = 0; i < b.Length; i += 2)
            {
                p = (int)b[i];
                p = p * 256 + b[i + 1] - 65536;
            }
            return p;
        }
        /// <summary>
        /// 36�����㷨
        /// </summary>
        /// <param name="ws">��������λ��</param>
        /// <param name="pid">������</param>
        /// <returns></returns>
        public static string getxh(int ws, string pid)
        {
            string[] number = new string[ws];
            string restr = pid;
            int i;
            if (pid.Length < ws)
            {
                for (i = pid.Length; i < ws; i++)
                {
                    restr = "0" + restr;
                }
            }
            for (i = 0; i < ws; i++)
            {
                number[i] = restr.ToUpper().Substring(restr.Length - i - 1, 1);
            }
            restr = "";
            int p = 1;
            for (i = 0; i < ws; i++)
            {
                int asci = ASC(number[i]);
                if (asci > 47 & asci < 58)
                {
                    asci += p;
                    p = 0;
                    if (asci > 57)
                        asci = ASC("A");
                }
                else if (asci >= 65 & asci <= 90)
                {
                    asci += p;
                    p = 0;
                    if (asci > 90)
                    {
                        asci = ASC("0");
                        p = 1;
                    }
                }
                number[i] = ((char)asci).ToString();
                restr = number[i] + restr;
            }
            return restr;
        }

        #endregion

        #region ��ˮ�Ź���

        /// <summary>
        /// ȡ����ˮ��
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="lm">����</param>
        /// <returns>��ˮ��</returns>
        public static string getlsh(string tablename, string lm)
        {
            
            tablename = tablename.ToLower();
            lm = lm.ToLower();
           
             SqlConnection conn = DataBase.Conn();
            SqlCommand cmd;
            string rq;					//����
            int num;					//���
            string rnum = "";
            rq = getrq();
            conn.Open();            
            try
            {
                cmd = new SqlCommand("select count(*) from sys_lshglb where bm='" + tablename + "' and lm='" + lm + "' and rq='" + rq + "'", conn);
                num = int.Parse(cmd.ExecuteScalar().ToString());
                if (num > 0)
                {
                    int xh;
                    cmd.CommandText = "select xh from sys_lshglb where bm='" + tablename + "' and lm='" + lm + "' and rq='" + rq + "'";
                    xh = int.Parse(cmd.ExecuteScalar().ToString());
                    int xxx = xh + 1;
                    cmd.CommandText = "update sys_lshglb set xh=" + xxx.ToString() + " where bm='" + tablename + "' and lm='" + lm + "' and rq='" + rq + "'";
                    cmd.ExecuteNonQuery();
                    rnum = rq + getxh(xh + 1);
                }
                else
                {
                    cmd.CommandText = "insert into sys_lshglb(xh,bm,lm,rq) values(1,'" + tablename + "','" + lm + "','" + rq + "')";
                    cmd.ExecuteNonQuery();
                    rnum = rq + "001";
                }
            }
            catch
            {

            }
            conn.Close();
            return rnum;
        }

        /// <summary>
        /// ȡ����ˮ��
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="lm">����</param>
        /// <returns>��ˮ��</returns>
        public static string getlsh(string tablename, string lm, OleDbTransaction tr)
        {
            tablename = tablename.ToLower();
            lm = lm.ToLower();

            OleDbCommand cmd;
            string rq;					//����
            int num;					//���
            string rnum = "";
            rq = getrq();

            try
            {
                cmd = new OleDbCommand("select count(*) from sys_lshglb where bm='" + tablename + "' and lm='" + lm + "' and rq='" + rq + "'", tr.Connection);
                cmd.Transaction = tr;
                num = int.Parse(cmd.ExecuteScalar().ToString());
                if (num > 0)
                {
                    int xh;
                    cmd.CommandText = "select xh from sys_lshglb where bm='" + tablename + "' and lm='" + lm + "' and rq='" + rq + "'";
                    xh = int.Parse(cmd.ExecuteScalar().ToString());
                    int xxx = xh + 1;
                    cmd.CommandText = "update sys_lshglb set xh=" + xxx.ToString() + " where bm='" + tablename + "' and lm='" + lm + "' and rq='" + rq + "'";
                    cmd.ExecuteNonQuery();
                    rnum = rq + getxh(xh + 1);
                }
                else
                {
                    cmd.CommandText = "insert into sys_lshglb(xh,bm,lm,rq) values(1,'" + tablename + "','" + lm + "','" + rq + "')";
                    cmd.ExecuteNonQuery();
                    rnum = rq + "0001";
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return rnum;

        }


        

        /// <summary>
        /// ȡ��36λ��ˮ��
        /// </summary>
        /// <param name="tr">�ⲿ����</param>
        /// <param name="talbename">����</param>
        /// <param name="lm">����</param>
        /// <returns></returns>
        public static string getlsh36(SqlTransaction tr, string tablename, string lm)
        {
            tablename = tablename.ToLower();
            if (lm != "X")
                lm = lm.ToLower();

            string rq;//����
            int num;//���
            string rnum = "";
            try
            {
                num = Int32.Parse(DataBase.Exe_Scalar("select " + OleDbIsNull("count(*)", "0") + " from sys_lshglb where bm='" + tablename + "' and lm='" + lm + "'", tr));
                if (num > 0)
                {
                    string xh;
                    xh = DataBase.Exe_Scalar("select " + OleDbIsNull("rq", "'0001'") + " from sys_lshglb where bm='" + tablename + "' and lm='" + lm + "' and xh=1", tr);
                    if (xh != "0000")
                    {
                        xh = getxh(4, xh);
                        DataBase.Exe_cmd("update sys_lshglb set rq='" + xh + "' where bm='" + tablename + "' and lm='" + lm + "' and xh=1", tr);
                    }
                    rnum = xh;
                }
                else
                {
                    DataBase.Exe_cmd("insert into sys_lshglb(xh,bm,lm,rq) values(1,'" + tablename + "','" + lm + "','0001')", tr);
                    rnum = "0001";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rnum;
        }

        /// <summary>
        /// ȡ��36λ��ˮ��
        /// </summary>
        /// <param name="tr">�ⲿ����</param>
        /// <param name="talbename">����</param>
        /// <param name="lm">����</param>
        /// <returns></returns>
        public static string getlsh36(SqlTransaction tr, string tablename, string lm,string aa)
        {
            tablename = tablename.ToLower();
            if (lm != "X")
                lm = lm.ToLower();

            string rq;//����
            int num;//���
            string rnum = "";
            try
            {
                num = Int32.Parse(DataBase.Exe_Scalar("select " + OleDbIsNull("count(*)", "0") + " from sys_lshglb where bm='" + tablename + "' and lm='" + lm + "'", tr));
                if (num > 0)
                {
                    string xh;
                    xh = DataBase.Exe_Scalar("select " + OleDbIsNull("rq", "'0001'") + " from sys_lshglb where bm='" + tablename + "' and lm='" + lm + "' and xh=1", tr);
                    if (decimal.Parse(xh) < 6)
                        xh = "0006";
                    if (xh != "0000")
                    {
                        xh = getxh(4, xh);
                        DataBase.Exe_cmd("update sys_lshglb set rq='" + xh + "' where bm='" + tablename + "' and lm='" + lm + "' and xh=1", tr);
                    }
                    rnum = xh;
                }
                else
                {
                    DataBase.Exe_cmd("insert into sys_lshglb(xh,bm,lm,rq) values(1,'" + tablename + "','" + lm + "','0001')", tr);
                    rnum = "0001";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rnum;
        }

        /// <summary>
        /// ȡ��36λ��ˮ��
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="lm"></param>
        /// <returns></returns>
        public static string getlsh36(string tablename, string lm)
        {
            tablename = tablename.ToLower();
            if(lm!="X")
                lm = lm.ToLower();

            string rq;//'����
            int num;//���
            string rnum = "";
            try
            {
                num = Int32.Parse(DataBase.Exe_Scalar("select " + OleDbIsNull("count(*)", "0") + " from sys_lshglb where bm='" + tablename + "' and lm='" + lm + "'"));
                if (num > 0)
                {
                    string xh;
                    xh = DataBase.Exe_Scalar("select " + OleDbIsNull("rq", "'0001'") + " from sys_lshglb where bm='" + tablename + "' and lm='" + lm + "' and xh=1");
                    if (xh != "0000")
                    {
                        xh = getxh(4, xh);
                        DataBase.Exe_cmd("update sys_lshglb set rq='" + xh + "' where bm='" + tablename + "' and lm='" + lm + "' and xh=1");
                    }
                    rnum = xh;
                }
                else
                {
                    DataBase.Exe_cmd("insert into sys_lshglb(xh,bm,lm,rq) values(1,'" + tablename + "','" + lm + "','0001')");
                    rnum = "0001";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rnum;
        }
        #endregion        
       
        #region sql��Ӧ�����任

        /// <summary>
        /// ����sql��Ӧ��ʱ�亯��
        /// </summary>
        /// <returns></returns>
        public static string OleDbgetdate()
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "getdate()";
                case "1":
                    return "sysdate";
                case "2":
                    return "date()";
                default:
                    return "getdate()";
            }
        }

        /// <summary>
        /// ����sql��Ӧisnull�ĺ���
        /// </summary>
        /// <param name="y">�ֶ���</param>
        /// <param name="nvl">ת��ֵ</param>
        /// <returns></returns>
        public static string OleDbIsNull(string y, string nvl)
        {
            string NVL = nvl;
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "isnull(" + y + "," + NVL + ")";
                case "1":
                    return "nvl(" + y + "," + NVL + ")";
                case "2":
                    return "iif(isnull(" + y + ")," + NVL + "," + y + ")";
                default:
                    return "isnull(" + y + "," + NVL + ")";
            }
        }

        public static string setDate(object dr)
        {
            if (dr == DBNull.Value || dr == "")
            {
                dr = DateTime.Today.ToShortDateString();
            }
            return dr.ToString();
        }
        /// <summary>
        /// ����sql��Ӧ���ַ���תʱ��
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string OleDbStrToDate(string date)
        {
            if (date == null || date=="")
                date = DateTime.Today.ToShortDateString();

            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "'" + date + "'";
                case "1":
                    return "to_date('" + date + "','yyyy-mm-dd')";
                case "2":
                    return "datevalue('" + date + "')";
                default:
                    return "'" + date + "'";
            }
        }
        /// <summary>
        /// ����sql��Ӧ���ַ���תʱ��
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string OleDbStrToDate2(string date)
        {
            if (date == null || date == "")
                date = DateTime.Today.ToShortDateString();

            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "'" + date + "'";
                case "1":
                    return "to_date('" + date + "','yyyy-mm-dd hh24:mi:ss')";
                case "2":
                    return "datevalue('" + date + "')";
                default:
                    return "'" + date + "'";
            }
        }

        /// <summary>
        /// ����sql��Ӧ���ַ���תʱ��(ƴ���ֶ�)
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string OleDbStrToDatePJ(string date)
        {
            if (date == null || date == "")
                date = DateTime.Today.ToShortDateString();

            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "cast(" + date + ")";
                case "1":
                    return "to_date(" + date + ",'yyyy-mm-dd')";
                case "2":
                    return "datevalue('" + date + "')";
                default:
                    return "'" + date + "'";
            }
        }

        /// <summary>
        /// ����sql��Ӧ���ַ���תʱ�䣨ʱ���룩
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string OleDbStrToDateTime(string date)
        {
            if (date == null || date == "")
                date = DateTime.Today.ToShortDateString();

            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "'" + date + "'";
                case "1":
                    return "to_date('" + date + "','yyyy-mm-dd hh24:MI:ss')";
                case "2":
                    return "datevalue('" + date + "')";
                default:
                    return "'" + date + "'";
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string OleDBGetYear(string date)
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "year(" + date + ")";
                case "1":
                    return "to_char(" + date + ",'yyyy')";
                default:
                    return "year(" + date + ")";
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string OleDBGetMonth(string date)
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "month(" + date + ")";
                case "1":
                    return "to_char(" + date + ",'mm')";
                default:
                    return "month(" + date + ")";
            }
        }

        /// <summary>
        /// �ַ���ת����
        /// </summary>
        /// <param name="str">�ַ����ֶ�</param>
        /// <returns></returns>
        public static string OleStrToNUM(string str)
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "cast(" + str + " as numeric)";
                case "1":
                    return "to_number(" + str + ")";
                default:
                    return "cast(" + str + " as numeric)";
            }
        }

        /// <summary>
        /// ����ת�ַ���
        /// </summary>
        /// <param name="str">�ַ����ֶ�</param>
        /// <returns></returns>
        public static string OleNUMToStr(string str)
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "cast(" + str + " as varchar)";
                case "1":
                    return "to_char(" + str + ")";
                default:
                    return "cast(" + str + " as varchar)";
            }
        }

        /// <summary>
        /// ����sql���ַ�����Ӧ����ӷ���
        /// </summary>
        /// <returns></returns>
        public static string OleDbStrAdd()
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "+";
                case "1":
                    return "||";
                case "2":
                    return "+";
                default:
                    return "+";
            }
        }
        public static string OleDbStrSub(string a,string star,string length)
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "Substring(" + a + "," + star + "," + length + ")";
                case "1":
                    return "Substr(" + a + "," + star + "," + length + ")";
                case "2":
                    return "Substring(" + a + "," + star + "," + length + ")";
                default:
                    return "Substring(" + a + "," + star + "," + length + ")";
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="col"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string OleDbAddMonth(string col, int month)
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "dateadd(mm, " + month.ToString() + ", " + col + ")";
                case "1":
                    return "add_months(" + col + ", " + month.ToString() + ")";
                default:
                    return "dateadd(mm, " + month.ToString() + ", " + col + ")";
            }
        }

        /// <summary>
        /// ������-1
        /// </summary>
        /// <param name="col"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string OleDbAddMonthA(string col, int month)
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "dateadd(mm, " + (month-1).ToString() + ", " + col + ")";
                case "1":
                    return "add_months(" + col + ", " + month.ToString() + ")";
                default:
                    return "dateadd(mm, " + month.ToString() + ", " + col + ")";
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="col"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string OleDbAddMonth(string col, string  month)
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "dateadd(mm, " + month.ToString() + ", " + col + ")";
                case "1":
                    return "add_months(" + col + ", " + month.ToString() + ")";
                default:
                    return "dateadd(mm, " + month.ToString() + ", " + col + ")";
            }
        }

        /// <summary>
        /// ������-1
        /// </summary>
        /// <param name="col"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string OleDbAddMonthA(string col, string month)
        {
            switch (DataBase.OleDbClass())
            {
                case "0":
                    return "dateadd(mm, " +month+ "-1, " + col + ")";
                case "1":
                    return "add_months(" + col + ", " + month.ToString() + ")";
                default:
                    return "dateadd(mm, " + month.ToString() + ", " + col + ")";
            }
        }
        #endregion      
       
        #region ҳ��Ȩ���ж�

        
        /// <summary>
        /// Ȩ���ж�
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="menuid"></param>
        /// <returns></returns>
        public static bool getqxpd(string userid, string menuid)
        {
            string qx = "";
            qx = DataBase.Exe_Scalar("SELECT power FROM SYS_USER where userid='" + userid + "'");

            qx = DataOper.getBankTrans(qx);
            if (DataBase.Exe_Scalar("select " + DataOper.OleDbIsNull("isMust","'0'") + " from SYS_Menu where menuid='" + menuid + "'").Trim() == "1")
            {
                return false;
            }
            else if (qx == "")
            {
                return true;
            }
            else
            {
                string aaaa = qx.Substring(0, qx.IndexOf("#"));
                if (qx.IndexOf("#" + menuid + "#") > -1 | menuid == aaaa)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// ҳ��Ȩ���ж�
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool getqxpdy(string userid, string path)
        {
            string[] p = DataOper.Split(path, "/");
            string pathh = p[p.Length - 2] + "/" + p[p.Length - 1];
            string qx = "";
            string menuid = DataBase.Exe_Scalar("select menuid from SYS_Menu where hlink like '%" + pathh + "'");
            qx = DataOper.getBankTrans(DataBase.Exe_Scalar("SELECT power FROM SYS_USER where userid='" + userid + "'"));
            if (qx == "")
                return true;
            string aaaa = qx.Substring(0, qx.IndexOf("#"));
            if (qx.IndexOf("#" + menuid + "#") > -1 | menuid == aaaa)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// ���ز˵���
        /// </summary>
        /// <param name="path">·��</param>
        /// <param name="state">0 �����˵���1�ϼ��˵�</param>
        /// <returns></returns>
        public static string retMenuTitle(string path,string state)
        {
            string[] p = DataOper.Split(path, "/");
            string pathh = p[p.Length - 2] + "/" + p[p.Length - 1];
            string qx = "";
            string menuid = DataBase.Exe_Scalar("select menuid from SYS_Menu where hlink like '%" + pathh + "'");

            string title = "";

            if(state=="0")
                title = DataBase.Exe_Scalar("select menuname from sys_menu where menuid='" + menuid + "'");
            else 
            {
                title = DataBase.Exe_Scalar("select menuname from sys_menu where menuid=(select main_id from sys_menu where menuid='" + menuid + "')");
            }

            return title;
                
        }
        
        
        #endregion


        public static string treetitle()
        {
            return ConfigurationManager.AppSettings["BMTree"];
        }

    }
	
}
