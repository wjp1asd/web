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
            //TODO:ÔÚ´Ë´¦Ìí¼Ó¹¹Ôìº¯ÊıÂß¼­
            //
        }



        #region ¼ÓÃÜº¯Êı

        /// <summary>
        /// md5¼ÓÃÜ
        /// </summary>
        /// <param name="pass">Ô­Ê¼ÃÜÂë</param>
        /// <returns></returns>
        public static string encryptmd5(string pass)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "md5");
        }

        /// <summary>
        /// sha1¼ÓÃÜ
        /// </summary>
        /// <param name="pass">Ô­Ê¼ÃÜÂë</param>
        /// <returns></returns>
        public static string encryptsha1(string pass)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "sha1");

        }


        /// <summary>
        /// ¶ÔÃÜÂë½øĞĞdes¼ÓÃÜ
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string getDesEncryptPassword(string password)
        {
            //ÊµÀı»¯des¼ÓÃÜËã·¨µÄ¶ÔÏó
            DESCryptoServiceProvider aa = new DESCryptoServiceProvider();
            aa.Key = ASCIIEncoding.ASCII.GetBytes("fGyu+_4#");
            aa.IV = ASCIIEncoding.ASCII.GetBytes("fGyu+_4#");
            //µÃµ½Ò»¸ö¼ÓÃÜ¶ÔÏó
            ICryptoTransform bb = aa.CreateEncryptor();

            byte[] b = Encoding.UTF8.GetBytes(password);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, bb, CryptoStreamMode.Write);
            cs.Write(b, 0, b.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }


        /// <summary>
        /// ¶ÔÃÜÂë½øĞĞdes½âÃÜ
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string getBankTrans(string password)
        {
            if (password != "")
            {
                //ÊµÀı»¯des¼ÓÃÜËã·¨µÄ¶ÔÏó
                DESCryptoServiceProvider aa = new DESCryptoServiceProvider();
                aa.Key = ASCIIEncoding.ASCII.GetBytes("fGyu+_4#");
                aa.IV = ASCIIEncoding.ASCII.GetBytes("fGyu+_4#");
                //Éú³É½âÃÜËã·¨
                ICryptoTransform bb = aa.CreateDecryptor();
                byte[] b1 = new byte[password.Length];
                //×ª»»×ª»»ºóµÄÖµ
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

        #region ³£ÓÃº¯Êı

        /// <summary>
        /// ×ª»»×Ö·û´®
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string setTrueString(string str)
        {
            str = str.Replace("'", "''");
            str = str.Replace("\"", "¡°");
            str = str.Replace("--", "£­£­");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("%", "");
            return str.Trim();
        }

        /// <summary>
        /// ·Ö¸î×Ö·û´®
        /// </summary>
        /// <param name="v">×Ö·û´®</param>
        /// <param name="delimstr">·Ö¸î·û</param>
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
        /// È¡ºº×ÖµÄÆ´ÒôÂë
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
            string ls_second_ch = "Ø¡Ø¢Ø£Ø¤Ø¥Ø¦Ø§Ø¨Ø©ØªØ«Ø¬Ø­Ø®Ø¯Ø°Ø±Ø²Ø³Ø´ØµØ¶Ø·Ø¸Ø¹ØºØ»Ø¼Ø½" +
                "Ø¾Ø¿ØÀØÁØÂØÃØÄØÅØÆØÇØÈØÉØÊØËØÌØÍØÎØÏØĞØÑØÒØÓØÔØÕØÖØ×ØØØÙØÚØÛØÜØİØŞØßØàØáØâØãØäØåØæØçØèØéØêØëØìØíØîØïØğØñØòØóØôØõØöØ÷ØøØùØúØûØüØıØşÙ¡Ù¢Ù£Ù¤Ù¥Ù¦Ù§Ù¨Ù©ÙªÙ«Ù¬Ù­Ù®Ù¯Ù°Ù±Ù²Ù³Ù´ÙµÙ¶Ù·Ù¸Ù¹ÙºÙ»Ù¼Ù½Ù¾Ù¿ÙÀÙÁÙÂÙÃÙÄÙÅÙÆÙÇÙÈÙÉÙÊÙËÙÌÙÍÙÎÙÏÙĞÙÑÙÒÙÓÙÔÙÕÙÖÙ×ÙØÙÙÙÚÙÛÙÜÙİÙŞÙßÙàÙáÙâÙãÙäÙåÙæÙçÙèÙéÙêÙëÙìÙíÙîÙïÙğÙñÙòÙóÙôÙõÙöÙ÷ÙøÙùÙúÙûÙüÙıÙşÚ¡Ú¢Ú£Ú¤Ú¥Ú¦Ú§Ú¨Ú©ÚªÚ«Ú¬Ú­Ú®Ú¯Ú°Ú±Ú²Ú³Ú´ÚµÚ¶Ú·Ú¸Ú¹ÚºÚ»Ú¼Ú½Ú¾Ú¿ÚÀÚÁÚÂÚÃÚÄÚÅÚÆÚÇÚÈÚÉÚÊÚËÚÌÚÍÚÎÚÏÚĞÚÑÚÒÚÓÚÔÚÕÚÖÚ×ÚØÚÙÚÚÚÛÚÜÚİÚŞÚßÚàÚáÚâÚãÚäÚåÚæÚçÚè" +
                "ÚéÚêÚëÚìÚíÚîÚïÚğÚñÚòÚóÚôÚõÚöÚ÷ÚøÚùÚúÚûÚüÚıÚşÛ¡Û¢Û£Û¤Û¥Û¦Û§Û¨Û©ÛªÛ«Û¬Û­Û®Û¯Û°Û±Û²Û³Û´ÛµÛ¶Û·Û¸Û¹ÛºÛ»Û¼Û½Û¾Û¿ÛÀÛÁÛÂÛÃÛÄÛÅÛÆÛÇÛÈÛÉÛÊÛËÛÌÛÍÛÎÛÏÛĞÛÑÛÒÛÓÛÔÛÕÛÖÛ×ÛØÛÙÛÚÛÛÛÜÛİÛŞÛßÛàÛáÛâÛãÛäÛåÛæÛçÛèÛéÛêÛëÛìÛíÛîÛïÛğÛñÛòÛóÛôÛõÛöÛ÷ÛøÛùÛúÛûÛüÛıÛşÜ¡Ü¢Ü£Ü¤Ü¥Ü¦Ü§Ü¨Ü©ÜªÜ«Ü¬Ü­Ü®Ü¯Ü°Ü±Ü²Ü³Ü´ÜµÜ¶Ü·Ü¸Ü¹ÜºÜ»Ü¼Ü½Ü¾Ü¿ÜÀÜÁÜÂÜÃÜÄÜÅÜÆÜÇÜÈÜÉÜÊÜËÜÌÜÍÜÎÜÏÜĞÜÑÜÒÜÓÜÔÜÕÜÖÜ×ÜØÜÙÜÚÜÛÜÜÜİÜŞÜßÜàÜáÜâÜãÜäÜåÜæÜçÜèÜéÜêÜëÜìÜíÜîÜïÜğÜñÜòÜóÜôÜõÜöÜ÷ÜøÜùÜúÜûÜüÜıÜşİ¡İ¢İ£İ¤İ¥İ¦İ§İ¨İ©İªİ«İ¬İ­İ®İ¯İ°İ±İ²İ³İ´İµİ¶" +
                "İ·İ¸İ¹İºİ»İ¼İ½İ¾İ¿İÀİÁİÂİÃİÄİÅİÆİÇİÈİÉİÊİËİÌİÍİÎİÏİĞİÑİÒİÓİÔİÕİÖİ×İØİÙİÚİÛİÜİİİŞİßİàİáİâİãİäİåİæİçİèİéİêİëİìİíİîİïİğİñİòİóİôİõİöİ÷İøİùİúİûİüİıİşŞ¡Ş¢Ş£Ş¤Ş¥Ş¦Ş§Ş¨Ş©ŞªŞ«Ş¬Ş­Ş®Ş¯Ş°Ş±Ş²Ş³Ş´ŞµŞ¶Ş·Ş¸Ş¹ŞºŞ»Ş¼Ş½Ş¾Ş¿ŞÀŞÁŞÂŞÃŞÄŞÅŞÆŞÇŞÈŞÉŞÊŞËŞÌŞÍŞÎŞÏŞĞŞÑŞÒŞÓŞÔŞÕŞÖŞ×ŞØŞÙŞÚŞÛŞÜŞİŞŞŞßŞàŞáŞâŞãŞäŞåŞæŞçŞèŞéŞêŞëŞìŞíŞîŞïŞğŞñŞòŞóŞôŞõŞöŞ÷ŞøŞùŞúŞûŞüŞıŞşß¡ß¢ß£ß¤ß¥ß¦ß§ß¨ß©ßªß«ß¬ß­ß®ß¯ß°ß±ß²ß³ß´ßµß¶ß·ß¸ß¹ßºß»ß¼ß½ß¾ß¿ßÀßÁßÂßÃßÄßÅßÆßÇßÈßÉßÊßËßÌßÍßÎßÏßĞßÑßÒßÓßÔßÕßÖß×ßØßÙßÚßÛßÜßİßŞßßßàßáßâßã" +
                "ßäßåßæßçßèßéßêßëßìßíßîßïßğßñßòßóßôßõßöß÷ßøßùßúßûßüßıßşà¡à¢à£à¤à¥à¦à§à¨à©àªà«à¬à­à®à¯à°à±à²à³à´àµà¶à·à¸à¹àºà»à¼à½à¾à¿àÀàÁàÂàÃàÄàÅàÆàÇàÈàÉàÊàËàÌàÍàÎàÏàĞàÑàÒàÓàÔàÕàÖà×àØàÙàÚàÛàÜàİàŞàßàààáàâàãàäàåàæàçàèàéàêàëàìàíàîàïàğàñàòàóàôàõàöà÷àøàùàúàûàüàıàşá¡á¢á£á¤á¥á¦á§á¨á©áªá«á¬á­á®á¯á°á±á²á³á´áµá¶á·á¸á¹áºá»á¼á½á¾á¿áÀáÁáÂáÃáÄáÅáÆáÇáÈáÉáÊáËáÌáÍáÎáÏáĞáÑáÒáÓáÔáÕáÖá×áØáÙáÚáÛáÜáİáŞáßáàáááâáãáäáåáæáçáèáéáêáëáìáíáîáïáğáñáòáóáôáõáöá÷áøáùáúáûáüáıáşâ¡â¢â£â¤â¥â¦â§â¨â©âªâ«â¬â­â®â¯â°â±â²â³â´âµ" +
                "â¶â·â¸â¹âºâ»â¼â½â¾â¿âÀâÁâÂâÃâÄâÅâÆâÇâÈâÉâÊâËâÌâÍâÎâÏâĞâÑâÒâÓâÔâÕâÖâ×âØâÙâÚâÛâÜâİâŞâßâàâáâââãâäâåâæâçâèâéâêâëâìâíâîâïâğâñâòâóâôâõâöâ÷âøâùâúâûâüâıâşã¡ã¢ã£ã¤ã¥ã¦ã§ã¨ã©ãªã«ã¬ã­ã®ã¯ã°ã±ã²ã³ã´ãµã¶ã·ã¸ã¹ãºã»ã¼ã½ã¾ã¿ãÀãÁãÂãÃãÄãÅãÆãÇãÈãÉãÊãËãÌãÍãÎãÏãĞãÑãÒãÓãÔãÕãÖã×ãØãÙãÚãÛãÜãİãŞãßãàãáãâãããäãåãæãçãèãéãêãëãìãíãîãïãğãñãòãóãôãõãöã÷ãøãùãúãûãüãıãşä¡ä¢ä£ä¤ä¥ä¦ä§ä¨ä©äªä«ä¬ä­ä®ä¯ä°ä±ä²ä³ä´äµä¶ä·ä¸ä¹äºä»ä¼ä½ä¾ä¿äÀäÁäÂäÃäÄäÅäÆäÇäÈäÉäÊäËäÌäÍäÎäÏäĞäÑäÒäÓäÔäÕäÖä×äØäÙäÚäÛäÜäİäŞäßäàäáäâäãäääåäæäçäè" +
                "äéäêäëäìäíäîäïäğäñäòäóäôäõäöä÷äøäùäúäûäüäıäşå¡å¢å£å¤å¥å¦å§å¨å©åªå«å¬å­å®å¯å°å±å²å³å´åµå¶å·å¸å¹åºå»å¼å½å¾å¿åÀåÁåÂåÃåÄåÅåÆåÇåÈåÉåÊåËåÌåÍåÎåÏåĞåÑåÒåÓåÔåÕåÖå×åØåÙåÚåÛåÜåİåŞåßåàåáåâåãåäåååæåçåèåéåêåëåìåíåîåïåğåñåòåóåôåõåöå÷åøåùåúåûåüåıåşæ¡æ¢æ£æ¤æ¥æ¦æ§æ¨æ©æªæ«æ¬æ­æ®æ¯æ°æ±æ²æ³æ´æµæ¶æ·æ¸æ¹æºæ»æ¼æ½æ¾æ¿æÀæÁæÂæÃæÄæÅæÆæÇæÈæÉæÊæËæÌæÍæÎæÏæĞæÑæÒæÓæÔæÕæÖæ×æØæÙæÚæÛæÜæİæŞæßæàæáæâæãæäæåæææçæèæéæêæëæìæíæîæïæğæñæòæóæôæõæöæ÷æøæùæúæûæüæıæşç¡ç¢ç£ç¤ç¥ç¦ç§ç¨ç©çªç«ç¬ç­ç®ç¯ç°ç±ç²ç³ç´çµç¶ç·ç¸ç¹çºç»ç¼ç½" +
                "ç¾ç¿çÀçÁçÂçÃçÄçÅçÆçÇçÈçÉçÊçËçÌçÍçÎçÏçĞçÑçÒçÓçÔçÕçÖç×çØçÙçÚçÛçÜçİçŞçßçàçáçâçãçäçåçæçççèçéçêçëçìçíçîçïçğçñçòçóçôçõçöç÷çøçùçúçûçüçıçşè¡è¢è£è¤è¥è¦è§è¨è©èªè«è¬è­è®è¯è°è±è²è³è´èµè¶è·è¸è¹èºè»è¼è½è¾è¿èÀèÁèÂèÃèÄèÅèÆèÇèÈèÉèÊèËèÌèÍèÎèÏèĞèÑèÒèÓèÔèÕèÖè×èØèÙèÚèÛèÜèİèŞèßèàèáèâèãèäèåèæèçèèèéèêèëèìèíèîèïèğèñèòèóèôèõèöè÷èøèùèúèûèüèıèşé¡é¢é£é¤é¥é¦é§é¨é©éªé«é¬é­é®é¯é°é±é²é³é´éµé¶é·é¸é¹éºé»é¼é½é¾é¿éÀéÁéÂéÃéÄéÅéÆéÇéÈéÉéÊéËéÌéÍéÎéÏéĞéÑéÒéÓéÔéÕéÖé×éØéÙéÚéÛéÜéİéŞéßéàéáéâéãéäéåéæéçéèéééêéëéìéíéîéïéğéñéòéó" +
                "éôéõéöé÷éøéùéúéûéüéıéşê¡ê¢ê£ê¤ê¥ê¦ê§ê¨ê©êªê«ê¬ê­ê®ê¯ê°ê±ê²ê³ê´êµê¶ê·ê¸ê¹êºê»ê¼ê½ê¾ê¿êÀêÁêÂêÃêÄêÅêÆêÇêÈêÉêÊêËêÌêÍêÎêÏêĞêÑêÒêÓêÔêÕêÖê×êØêÙêÚêÛêÜêİêŞêßêàêáêâêãêäêåêæêçêèêéêêêëêìêíêîêïêğêñêòêóêôêõêöê÷êøêùêúêûêüêıêşë¡ë¢ë£ë¤ë¥ë¦ë§ë¨ë©ëªë«ë¬ë­ë®ë¯ë°ë±ë²ë³ë´ëµë¶ë·ë¸ë¹ëºë»ë¼ë½ë¾ë¿ëÀëÁëÂëÃëÄëÅëÆëÇëÈëÉëÊëËëÌëÍëÎëÏëĞëÑëÒëÓëÔëÕëÖë×ëØëÙëÚëÛëÜëİëŞëßëàëáëâëãëäëåëæëçëèëéëêëëëìëíëîëïëğëñëòëóëôëõëöë÷ëøëùëúëûëüëıëşì¡ì¢ì£ì¤ì¥ì¦ì§ì¨ì©ìªì«ì¬ì­ì®ì¯ì°ì±ì²ì³ì´ìµì¶ì·ì¸ì¹ìºì»ì¼ì½ì¾ì¿ìÀìÁìÂìÃìÄìÅìÆìÇìÈìÉìÊìËìÌìÍ" +
                "ìÎìÏìĞìÑìÒìÓìÔìÕìÖì×ìØìÙìÚìÛìÜìİìŞìßìàìáìâìãìäìåìæìçìèìéìêìëìììíìîìïìğìñìòìóìôìõìöì÷ìøìùìúìûìüìıìşí¡í¢í£í¤í¥í¦í§í¨í©íªí«í¬í­í®í¯í°í±í²í³í´íµí¶í·í¸í¹íºí»í¼í½í¾í¿íÀíÁíÂíÃíÄíÅíÆíÇíÈíÉíÊíËíÌíÍíÎíÏíĞíÑíÒíÓíÔíÕíÖí×íØíÙíÚíÛíÜíİíŞíßíàíáíâíãíäíåíæíçíèíéíêíëíìíííîíïíğíñíòíóíôíõíöí÷íøíùíúíûíüíıíşî¡î¢î£î¤î¥î¦î§î¨î©îªî«î¬î­î®î¯î°î±î²î³î´îµî¶î·î¸î¹îºî»î¼î½î¾î¿îÀîÁîÂîÃîÄîÅîÆîÇîÈîÉîÊîËîÌîÍîÎîÏîĞîÑîÒîÓîÔîÕîÖî×îØîÙîÚîÛîÜîİîŞîßîàîáîâîãîäîåîæîçîèîéîêîëîìîíîîîïîğîñîòîóîôîõîöî÷îøîùîúîûîüîıîşï¡ï¢ï£ï¤ï¥ï¦ï§ï¨ï©ïª" +
                "ï«ï¬ï­ï®ï¯ï°ï±ï²ï³ï´ïµï¶ï·ï¸ï¹ïºï»ï¼ï½ï¾ï¿ïÀïÁïÂïÃïÄïÅïÆïÇïÈïÉïÊïËïÌïÍïÎïÏïĞïÑïÒïÓïÔïÕïÖï×ïØïÙïÚïÛïÜïİïŞïßïàïáïâïãïäïåïæïçïèïéïêïëïìïíïîïïïğïñïòïóïôïõïöï÷ïøïùïúïûïüïıïşğ¡ğ¢ğ£ğ¤ğ¥ğ¦ğ§ğ¨ğ©ğªğ«ğ¬ğ­ğ®ğ¯ğ°ğ±ğ²ğ³ğ´ğµğ¶ğ·ğ¸ğ¹ğºğ»ğ¼ğ½ğ¾ğ¿ğÀğÁğÂğÃğÄğÅğÆğÇğÈğÉğÊğËğÌğÍğÎğÏğĞğÑğÒğÓğÔğÕğÖğ×ğØğÙğÚğÛğÜğİğŞğßğàğáğâğãğäğåğæğçğèğéğêğëğìğíğîğïğğğñğòğóğôğõğöğ÷ğøğùğúğûğüğığşñ¡ñ¢ñ£ñ¤ñ¥ñ¦ñ§ñ¨ñ©ñªñ«ñ¬ñ­ñ®ñ¯ñ°ñ±ñ²ñ³ñ´ñµñ¶ñ·ñ¸ñ¹ñºñ»ñ¼ñ½ñ¾ñ¿ñÀñÁñÂñÃñÄñÅñÆñÇñÉñÊñËñÌñÍñÎñÏñĞñÑñÒñÓñÔñÕñÖñ×ñØñÙñÚñÛñÜñİñŞñßñàñâñãñäñåñæñç" +
                "ñèñéñêñëñìñíñîñïñğñññòñóñôñõñöñ÷ñøñùñúñûñüñıñşò¡ò¢ò£ò¤ò¥ò¦ò§ò¨ò©òªò«ò¬ò­ò®ò¯ò°ò±ò²ò³ò´òµò¶ò·ò¸ò¹òºò»ò¼ò½ò¾ò¿òÀòÁòÂòÃòÄòÅòÆòÇòÈòÉòÊòËòÌòÍòÎòÏòĞòÑòÒòÓòÔòÕòÖò×òØòÙòÚòÛòÜòİòŞòßòàòáòâòãòäòåòæòçòèòéòêòëòìòíòîòïòğòñòòòóòôòõòöò÷òøòùòúòûòüòıòşó¡ó¢ó£ó¤ó¥ó¦ó§ó¨ó©óªó«ó¬ó­ó®ó¯ó°ó±ó²ó³ó´óµó¶ó·ó¸ó¹óºó»ó¼ó½ó¾ó¿óÀóÁóÂóÃóÄóÅóÆóÇóÈóÉóÊóËóÌóÍóÎóÏóĞóÑóÒóÓóÔóÕóÖó×óØóÙóÚóÛóÜóİóŞóßóàóáóâóãóäóåóæóçóèóéóêóëóìóíóîóïóğóñóòóóóôóõóöó÷óøóùóúóûóüóıóşô¡ô¢ô£ô¤ô¥ô¦ô§ô¨ô©ôªô«ô¬ô­ô®ô¯ô°ô±ô²ô³ô´ôµô¶ô·ô¸ô¹ôºô»ô¼ô½ô¾ô¿ôÀôÁôÂôÃôÄôÅôÆôÇ" +
                "ôÈôÉôÊôËôÌôÍôÎôÏôĞôÑôÒôÓôÔôÕôÖô×ôØôÙôÚôÛôÜôİôŞôßôàôáôâôãôäôåôæôçôèôéôêôëôìôíôîôïôğôñôòôóôôôõôöô÷ôøôùôúôûôüôıôşõ¡õ¢õ£õ¤õ¥õ¦õ§õ¨õ©õªõ«õ¬õ­õ®õ¯õ°õ±õ²õ³õ´õµõ¶õ·õ¸õ¹õºõ»õ¼õ½õ¾õ¿õÀõÁõÂõÃõÄõÅõÆõÇõÈõÉõÊõËõÌõÍõÎõÏõĞõÑõÒõÓõÔõÕõÖõ×õØõÙõÚõÛõÜõİõŞõßõàõáõâõãõäõåõæõçõèõéõêõëõìõíõîõïõğõñõòõóõôõõõöõ÷õøõùõúõûõüõıõşö¡ö¢ö£ö¤ö¥ö¦ö§ö¨ö©öªö«ö¬ö­ö®ö¯ö°ö±ö²ö³ö´öµö¶ö·ö¸ö¹öºö»ö¼ö½ö¾ö¿öÀöÁöÂöÃöÄöÅöÆöÇöÈöÉöÊöËöÌöÍöÎöÏöĞöÑöÒöÓöÔöÕöÖö×öØöÙöÚöÛöÜöİöŞößöàöáöâöãöäöåöæöçöèöéöêöëöìöíöîöïöğöñöòöóöôöõööö÷öøöùöúöûöüöıöş÷¡÷¢÷£÷¤÷¥÷¦÷§" +
                "÷¨÷©÷ª÷«÷¬÷­÷®÷¯÷°÷±÷²÷³÷´÷µ÷¶÷·÷¸÷¹÷º÷»÷¼÷½÷¾÷¿÷À÷Á÷Â÷Ã÷Ä÷Å÷Æ÷Ç÷È÷É÷Ê÷Ë÷Ì÷Í÷Î÷Ï÷Ğ÷Ñ÷Ò÷Ó÷Ô÷Õ÷Ö÷×÷Ø÷Ù÷Ú÷Û÷Ü÷İ÷Ş÷ß÷à÷á÷â÷ã÷ä÷å÷æ÷ç÷è÷é÷ê÷ë÷ì÷í÷î÷ï÷ğ÷ñ÷ò÷ó÷ô÷õ÷ö÷÷÷ø÷ù÷ú÷û÷ü÷ı÷ş";
            byte[] array = new byte[2];

            string return_py = "";
            for (int i = 0; i < hz.Length; i++)
            {
                array = System.Text.Encoding.Default.GetBytes(hz[i].ToString());
                if (array[0] < 176) //.·Çºº×Ö
                {
                    return_py += hz[i];
                }
                else if (array[0] >= 176 && array[0] <= 215) //Ò»¼¶ºº×Ö
                {

                    if (hz[i].ToString().CompareTo("ÔÑ") >= 0)
                        return_py += "z";
                    else if (hz[i].ToString().CompareTo("Ñ¹") >= 0)
                        return_py += "y";
                    else if (hz[i].ToString().CompareTo("Îô") >= 0)
                        return_py += "x";
                    else if (hz[i].ToString().CompareTo("ÍÚ") >= 0)
                        return_py += "w";
                    else if (hz[i].ToString().CompareTo("Ëú") >= 0)
                        return_py += "t";
                    else if (hz[i].ToString().CompareTo("Èö") >= 0)
                        return_py += "s";
                    else if (hz[i].ToString().CompareTo("È»") >= 0)
                        return_py += "r";
                    else if (hz[i].ToString().CompareTo("ÆÚ") >= 0)
                        return_py += "q";
                    else if (hz[i].ToString().CompareTo("Å¾") >= 0)
                        return_py += "p";
                    else if (hz[i].ToString().CompareTo("Å¶") >= 0)
                        return_py += "o";
                    else if (hz[i].ToString().CompareTo("ÄÃ") >= 0)
                        return_py += "n";
                    else if (hz[i].ToString().CompareTo("Âè") >= 0)
                        return_py += "m";
                    else if (hz[i].ToString().CompareTo("À¬") >= 0)
                        return_py += "l";
                    else if (hz[i].ToString().CompareTo("¿¦") >= 0)
                        return_py += "k";
                    else if (hz[i].ToString().CompareTo("»÷") >= 0)
                        return_py += "j";
                    else if (hz[i].ToString().CompareTo("¹ş") >= 0)
                        return_py += "h";
                    else if (hz[i].ToString().CompareTo("¸Á") >= 0)
                        return_py += "g";
                    else if (hz[i].ToString().CompareTo("·¢") >= 0)
                        return_py += "f";
                    else if (hz[i].ToString().CompareTo("¶ê") >= 0)
                        return_py += "e";
                    else if (hz[i].ToString().CompareTo("´î") >= 0)
                        return_py += "d";
                    else if (hz[i].ToString().CompareTo("²Á") >= 0)
                        return_py += "c";
                    else if (hz[i].ToString().CompareTo("°Å") >= 0)
                        return_py += "b";
                    else if (hz[i].ToString().CompareTo("°¡") >= 0)
                        return_py += "a";
                }
                else if (array[0] >= 215) //¶ş¼¶ºº×Ö
                {
                    return_py += ls_second_eng.Substring(ls_second_ch.IndexOf(hz[i].ToString(), 0), 1);
                }
            }
            return return_py.ToUpper();
        }



        /// <summary>
        /// ÅĞ¶ÏÊÇ·ñÊÇÕûÊı
        /// </summary>
        /// <param name="strNumber">×Ö·û´®</param>
        /// <returns></returns>
        public static bool IsNumber(String strNumber)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strNumber);
        }


        /// <summary>
        /// ÅÌµãÊÇ·ñÊÇ¸¡µãÊı
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
        /// Ìî³älistµÄÑ¡ÔñÖ°
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
        /// ·µ»Ø×Ö·û´®³¤¶È
        /// </summary>
        /// <param name="str"></param>
        public static int strLength(string str)
        {
            byte[] mybyte;
            mybyte = System.Text.Encoding.Default.GetBytes(str);
            return mybyte.Length;
        }

        /// <summary>
        /// ½ØÈ¡×Ö·û´®
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
        /// ºÏ²¢GridViewÖĞÄ³ÁĞÏàÍ¬ĞÅÏ¢µÄĞĞ£¨µ¥Ôª¸ñ£© 
        /// </summary>
        /// <param name="GridView1">GridView</param>
        /// <param name="cellNum">µÚ¼¸ÁĞ</param>
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

        #region ¸÷ÖÖËã·¨

        /// <summary>
        /// ·µ»ØÁ÷Ë®ĞòºÅ
        /// </summary>
        /// <param name="xh"></param>
        /// <returns>Á÷Ë®ĞòºÅ</returns>
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
        /// ·µ»ØÈÕÆÚ×Ö·û´®
        /// </summary>
        /// <returns>ÈÕÆÚ×Ö·û´®(YYMMDD)</returns>
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

        public static int ASC(String Data) //»ñÈ¡ASCÂë
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(Data);
            int p = 0;

            if (b.Length == 1) //Èç¹ûÎªÓ¢ÎÄ×Ö·ûÖ±½Ó·µ»Ø
                return (int)b[0];
            for (int i = 0; i < b.Length; i += 2)
            {
                p = (int)b[i];
                p = p * 256 + b[i + 1] - 65536;
            }
            return p;
        }
        /// <summary>
        /// 36½øÖÆËã·¨
        /// </summary>
        /// <param name="ws">·µ»ØÊıµÄÎ»Êı</param>
        /// <param name="pid">×î´óĞòºÅ</param>
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

        #region Á÷Ë®ºÅ¹ÜÀí

        /// <summary>
        /// È¡µÃÁ÷Ë®ºÅ
        /// </summary>
        /// <param name="tablename">±íÃû</param>
        /// <param name="lm">ÁĞÃû</param>
        /// <returns>Á÷Ë®ºÅ</returns>
        public static string getlsh(string tablename, string lm)
        {
            
            tablename = tablename.ToLower();
            lm = lm.ToLower();
           
             SqlConnection conn = DataBase.Conn();
            SqlCommand cmd;
            string rq;					//ÈÕÆÚ
            int num;					//ĞòºÅ
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
        /// È¡µÃÁ÷Ë®ºÅ
        /// </summary>
        /// <param name="tablename">±íÃû</param>
        /// <param name="lm">ÁĞÃû</param>
        /// <returns>Á÷Ë®ºÅ</returns>
        public static string getlsh(string tablename, string lm, OleDbTransaction tr)
        {
            tablename = tablename.ToLower();
            lm = lm.ToLower();

            OleDbCommand cmd;
            string rq;					//ÈÕÆÚ
            int num;					//ĞòºÅ
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
        /// È¡µÃ36Î»Á÷Ë®ºÅ
        /// </summary>
        /// <param name="tr">Íâ²¿ÊÂÎñ</param>
        /// <param name="talbename">±íÃû</param>
        /// <param name="lm">ÁĞÃû</param>
        /// <returns></returns>
        public static string getlsh36(SqlTransaction tr, string tablename, string lm)
        {
            tablename = tablename.ToLower();
            if (lm != "X")
                lm = lm.ToLower();

            string rq;//ÈÕÆÚ
            int num;//ĞòºÅ
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
        /// È¡µÃ36Î»Á÷Ë®ºÅ
        /// </summary>
        /// <param name="tr">Íâ²¿ÊÂÎñ</param>
        /// <param name="talbename">±íÃû</param>
        /// <param name="lm">ÁĞÃû</param>
        /// <returns></returns>
        public static string getlsh36(SqlTransaction tr, string tablename, string lm,string aa)
        {
            tablename = tablename.ToLower();
            if (lm != "X")
                lm = lm.ToLower();

            string rq;//ÈÕÆÚ
            int num;//ĞòºÅ
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
        /// È¡µÃ36Î»Á÷Ë®ºÅ
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="lm"></param>
        /// <returns></returns>
        public static string getlsh36(string tablename, string lm)
        {
            tablename = tablename.ToLower();
            if(lm!="X")
                lm = lm.ToLower();

            string rq;//'ÈÕÆÚ
            int num;//ĞòºÅ
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
       
        #region sql¶ÔÓ¦º¯Êı±ä»»

        /// <summary>
        /// ·µ»Øsql¶ÔÓ¦µÄÊ±¼äº¯Êı
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
        /// ·µ»Øsql¶ÔÓ¦isnullµÄº¯Êı
        /// </summary>
        /// <param name="y">×Ö¶ÎÃû</param>
        /// <param name="nvl">×ª»»Öµ</param>
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
        /// ·µ»Øsql¶ÔÓ¦µÄ×Ö·û´®×ªÊ±¼ä
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
        /// ·µ»Øsql¶ÔÓ¦µÄ×Ö·û´®×ªÊ±¼ä
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
        /// ·µ»Øsql¶ÔÓ¦µÄ×Ö·û´®×ªÊ±¼ä(Æ´½Ó×Ö¶Î)
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
        /// ·µ»Øsql¶ÔÓ¦µÄ×Ö·û´®×ªÊ±¼ä£¨Ê±·ÖÃë£©
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
        /// ·µ»ØÄê
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
        /// ·µ»ØÔÂ
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
        /// ×Ö·û´®×ªÊı×Ö
        /// </summary>
        /// <param name="str">×Ö·û´®×Ö¶Î</param>
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
        /// Êı×Ö×ª×Ö·û´®
        /// </summary>
        /// <param name="str">×Ö·û´®×Ö¶Î</param>
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
        /// ·µ»ØsqlÖĞ×Ö·û´®¶ÔÓ¦µÄÏà¼Ó·ûºÅ
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
        /// Ôö¼ÓÔÂ
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
        /// Ôö¼ÓÔÂ-1
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
        /// Ôö¼ÓÔÂ
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
        /// Ôö¼ÓÔÂ-1
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
       
        #region Ò³ÃæÈ¨ÏŞÅĞ¶Ï

        
        /// <summary>
        /// È¨ÏŞÅĞ¶Ï
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
        /// Ò³ÃæÈ¨ÏŞÅĞ¶Ï
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
        /// ·µ»Ø²Ëµ¥Ãû
        /// </summary>
        /// <param name="path">Â·¾¶</param>
        /// <param name="state">0 ±¾¼¶²Ëµ¥£¬1ÉÏ¼¶²Ëµ¥</param>
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
