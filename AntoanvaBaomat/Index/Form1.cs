using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Index
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string strPlainText2;
        public BigInteger PlainRSA;
        

        private void btnFileT2_Click(object sender, EventArgs e)
        {
            OpenFileDialog chonFile = new OpenFileDialog();
            chonFile.Filter = "TXT Files|*.txt";
            if (chonFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtLinkFileP2.Text = Path.GetFullPath(chonFile.FileName);
                    using (StreamReader str = new StreamReader(chonFile.FileName))
                    {
                        strPlainText2 = str.ReadToEnd();
                        str.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void btnCeasar_Click(object sender, EventArgs e)
        {
            int n = 2;
            try
            {
                if (int.TryParse(txtKeyC2.Text, out n) == false || txtLinkFileP2.Text == "" || (radioMH.Checked == false && radioMH.Checked == false))
                    MessageBox.Show("Bạn chưa nhập đủ thông tin hoặc sai kiểu dữ liệu. Vui lòng kiểm tra lại!", "Thông báo");
                if (radioMH.Checked == true)
                {
                    txtKQ2.Text = Ceasar.Encrypt(strPlainText2, int.Parse(txtKeyC2.Text));
                }
                if (radioGM.Checked == true)
                {
                    txtKQ2.Text = Ceasar.Decrypt(strPlainText2, int.Parse(txtKeyC2.Text));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void btnPlayfair_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKeyC2.Text == "" || txtLinkFileP2.Text == "" || (radioMH.Checked == false && radioMH.Checked == false))
                    MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại!", "Thông báo");
                if (radioMH.Checked == true)
                {
                    Playfair.KhoiTao(strPlainText2, txtKeyC2.Text);
                    txtKQ2.Text = string.Format(Playfair.MaHoaPlayfair(Playfair.k, Playfair.p));



                }
                if (radioGM.Checked == true)
                {
                    Playfair.KhoiTao(strPlainText2, txtKeyC2.Text);
                    txtKQ2.Text = Playfair.GiaiMaPlayfair(Playfair.k, Playfair.p);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnVigenere_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKeyC2.Text == "" || txtLinkFileP2.Text == "" || (radioMH.Checked == false && radioMH.Checked == false))
                    MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại!", "Thông báo");
                if (radioMH.Checked == true)
                {

                    txtKQ2.Text = Vigenere.Encrypt(strPlainText2, txtKeyC2.Text);
                }
                if (radioGM.Checked == true)
                {
                    txtKQ2.Text = Vigenere.Decrypt(strPlainText2, txtKeyC2.Text);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        
       
        private void btnTinhEuclid_Click(object sender, EventArgs e)
        {
            BigInteger n = 2;
            try
            {
                if ( txtA.Text =="" || txtB.Text == "" || BigInteger.TryParse(txtA.Text, out n) == false || BigInteger.TryParse(txtB.Text, out n) == false)
                    MessageBox.Show("Bạn chưa nhập đủ thông tin hoặc sai kiểu dữ liệu. Vui lòng kiểm tra lại!", "Thông báo");
                BigInteger a = BigInteger.Parse(txtA.Text);
                BigInteger b = BigInteger.Parse(txtB.Text);
                //if(ExtendEuclid.Euclid(a,b) != 1)
                //    txtKqEuclid.Text = string.Format("gcd({0}, {1}) = {2} {3} Không có nghịch đảo", a, b, ExtendEuclid.Euclid(a, b), Environment.NewLine);
                //else
                //    txtKqEuclid.Text = string.Format("gcd({0}, {1}) = {2} {4} 1 mod {0} = {3}", a, b, ExtendEuclid.Euclid(a, b), (ExtendEuclid.ExtendedEuclid(a, b) + a), Environment.NewLine);
                var result = ExtendEuclid.ExtendedEuclid1(a, b);
                if (result.Key == 1)
                    txtKqEuclid.Text = string.Format("gcd({0}, {1}) = {2} {4} 1 mod {0} = {3}", a, b, result.Key, (result.Value + a), Environment.NewLine);
                else
                    txtKqEuclid.Text = string.Format("gcd({0}, {1}) = {2} {3} Không có nghịch đảo", a, b, result.Key, Environment.NewLine);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnTinhBP_Click(object sender, EventArgs e)
        {
            BigInteger z = 2;
            try
            {
                if (txtA.Text == "" || txtB.Text == "" || BigInteger.TryParse(txtA.Text, out z) == false || BigInteger.TryParse(txtB.Text, out z) == false)
                    MessageBox.Show("Bạn chưa nhập đủ thông tin hoặc sai kiểu dữ liệu. Vui lòng kiểm tra lại!", "Thông báo");
                BigInteger x = BigInteger.Parse(txtxBP.Text);
                BigInteger b = BigInteger.Parse(txtbBP.Text);
                BigInteger n = BigInteger.Parse(txtnBP.Text);
                txtKqBP.Text = string.Format(" {0} ", BinhPhuong.Power(x, b, n));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnSNT_Click(object sender, EventArgs e)
        {
            try
            {
                var rs = RSA.Timp_q();
                txtSNTp.Text = string.Format("{0}", rs.Key);
                txtSNTq.Text = string.Format("{0}", rs.Value);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnFileRSA_Click(object sender, EventArgs e)
        {
            OpenFileDialog chonFile = new OpenFileDialog();
            chonFile.Filter = "TXT Files|*.txt";
            if (chonFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtFileRSA.Text = Path.GetFullPath(chonFile.FileName);
                    using (StreamReader str = new StreamReader(chonFile.FileName))
                    {
                        PlainRSA = BigInteger.Parse(str.ReadToEnd());
                        str.Close();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnEncryptRSA_Click(object sender, EventArgs e)
        {
            try
            {
                var rs = RSA.Timp_q();
                BigInteger e1 = RSA.Tim_e(rs.Key, rs.Value);
                BigInteger n = (rs.Value - 1) * (rs.Key - 1);
                var rs1 = ExtendEuclid.ExtendedEuclid1(e1, n);
                if (radioMHBM.Checked == true)
                {
                    txtPrivateKeyRSA.Text = "";
                    txtPublicKeyRSA.Text = string.Format("Ku = (e, N) = ({0}, {2}{1})", e1, rs.Key * rs.Value,Environment.NewLine);
                    //txtKqRSA.Text = string.Format("{0}", BinhPhuong.Power(PlainRSA, e1, rs.Value * rs.Key));
                     //txtKqRSA.Text = string.Format("{0}", BinhPhuong.Power(15,7,33));
                   // txtKqRSA.Text = string.Format("{0}", 15, 3, 33);
                }
                if (radioMHCT.Checked == true)
                {
                    if (rs1.Key == 1)
                    {
                        txtPublicKeyRSA.Text = "";
                        txtPrivateKeyRSA.Text = string.Format("Kr = (d, N) = ({0}, {2}{1})", rs1.Value, rs.Key * rs.Value, Environment.NewLine);
                        //txtKqRSA.Text = string.Format("{0}", BinhPhuong.Power(PlainRSA, e1, rs.Value * rs.Key));
                        txtKqRSA.Text = string.Format("{0}", BinhPhuong.Power(15, 7, 33));
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi, mời bạn tính lại", "Thông báo");
                    }
                }
                if(txtFileRSA.Text == "" || (radioMHBM.Checked == false && radioMHCT.Checked == false) || txtSNTp.Text == "" || txtSNTq.Text == "")
                    MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại", "Thông báo");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }          
        }

        private void btnDecryptRSA_Click(object sender, EventArgs e)
        {
            try
            {
                var rs = RSA.Timp_q();
                BigInteger e1 = RSA.Tim_e(rs.Key, rs.Value);
                BigInteger n = (rs.Value - 1) * (rs.Key - 1);
                var rs1 = ExtendEuclid.ExtendedEuclid1(e1, n);
                if (radioMHBM.Checked == true)
                {
                    txtPublicKeyRSA.Text = "";
                    txtPrivateKeyRSA.Text = string.Format("Kr = (d, N) = ({0}, {1})", rs1.Value, rs.Key * rs.Value);
                    txtKqRSA.Text = string.Format("{0}", BinhPhuong.Power(PlainRSA, e1, rs.Value * rs.Key));
                    //txtKqRSA.Text = string.Format("{0}", BinhPhuong.Power(9,7,33));
                }
                if (radioMHCT.Checked == true)
                {
                    if (rs1.Key == 1)
                    {
                        txtPrivateKeyRSA.Text = "";
                        txtPublicKeyRSA.Text = string.Format("Ku = (e, N) = ({0}, {1})", e1, rs.Key * rs.Value);
                        txtKqRSA.Text = string.Format("{0}", BinhPhuong.Power(PlainRSA, e1, rs.Value * rs.Key));
                        //txtKqRSA.Text = string.Format("{0}", BinhPhuong.Power(27, 3, 33));
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi, mời bạn tính lại", "Thông báo");
                    }
                }
                if (txtFileRSA.Text == "" || (radioMHBM.Checked == false && radioMHCT.Checked == false) || txtSNTp.Text == "" || txtSNTq.Text == "")
                    MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại", "Thông báo");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }          
        }
        string filetextDES = "", kDES = "";
        int flagDEStext = 0, flagDESKey = 0;        
        private void btn_browser_input_Click_1(object sender, EventArgs e)
        {
            
                Stream mystream;
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if ((mystream = openFile.OpenFile()) != null)
                    {
                        string filename = openFile.FileName;
                        filetextDES = DES.StringToBinary(File.ReadAllText(filename));
                        txt_Input_DES.Text = filename;
                    }
                    flagDEStext = 1;
                }
            
        }
        private void btn_browse_key_Click_1(object sender, EventArgs e)
        {
            try
            {
                Stream mystream;
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if ((mystream = openFile.OpenFile()) != null)
                    {
                        string filename = openFile.FileName;
                        kDES = DES.hex2binary(File.ReadAllText(filename));
                        txt_Key_DES.Text = filename;
                    }
                    flagDESKey = 1;
                }
            }
            catch
            {
                MessageBox.Show("Khóa là chữ số thập lục phân","Thông báo");
            }
        }

        

        private void btn_EnDES_Click_1(object sender, EventArgs e)
        {

            try
            {
                string resultEn = "";
                if (flagDEStext == 0 || flagDESKey == 0)
                {
                    MessageBox.Show("Chưa nhập đủ thông tin");
                }

                else
                {
                    DES.TaoKhoaDES(kDES);
                    resultEn = DES.MaHoaDES(filetextDES, DES.key);
                    resultEn = DES.bin2hex(resultEn);
                    txtKqDES.Text = resultEn;
                    string filename = "EnDES.txt";
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                    }
                    StreamWriter MyFile = new StreamWriter(filename);
                    MyFile.Write(resultEn);
                    MyFile.Close();
                    txt_Output_DES.Text = Path.GetFullPath(filename);
                    MessageBox.Show("Mã hóa thành công");
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi, xin vui lòng kiểm tra lại dữ liệu hoặc file dữ liệu đang sử dụng tại một tiến trình khác!!!");
            }
        }

        private void btn_DeDES_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                string resultDe = "";
                if (flagDEStext == 0 || flagDESKey == 0)
                {
                    MessageBox.Show("Chưa nhập đủ thông tin");
                }

                else
                {
                    DES.TaoKhoaDES(kDES);
                    resultDe = DES.GiaiMaDES(filetextDES, DES.key);
                    resultDe = DES.bin2hex(resultDe);
                    //resultDe = DES.BinaryToString(resultDe,System.Text.Encoding.UTF8);
                    //resultDe = DES.hex2string(resultDe, System.Text.Encoding.UTF8);
                    txtKqDES.Text = resultDe;
                    string filename = "DeDES.txt";
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                    }
                    StreamWriter MyFile = new StreamWriter(filename);
                    MyFile.Write(resultDe);
                    MyFile.Close();
                    txt_Output_DES.Text = Path.GetFullPath(filename);
                    MessageBox.Show("Giải mã thành công");
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi, xin vui lòng kiểm tra lại dữ liệu hoặc file dữ liệu đang sử dụng tại một tiến trình khác!!!");
            }
        }

        private void btnSinhKeyA5_Click(object sender, EventArgs e)
        {
            try
            {
                txtKhoaX.Text = A51.SinhKhoa(19);
                txtKhoaY.Text = A51.SinhKhoa(22);
                txtKhoaZ.Text = A51.SinhKhoa(23);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }          
        }

        private void btnInputA5_Click(object sender, EventArgs e)
        {
            OpenFileDialog chonFile = new OpenFileDialog();
            chonFile.Filter = "TXT Files|*.txt";

            chonFile.ShowDialog();
            if (chonFile.FileName != " ")
            {
                try
                {
                    txtInputA5.Text = chonFile.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
        

        
        private void btnEncryptA5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInputA5.Text != ""  & txtKhoaX.TextLength == 19 & txtKhoaY.TextLength == 22 & txtKhoaZ.TextLength == 23)
                {
                    
                    A51.X = A51.string2bool(txtKhoaX.Text);
                    A51.Y = A51.string2bool(txtKhoaY.Text);
                    A51.Z = A51.string2bool(txtKhoaZ.Text);
                    A51.banro = new BitArray(File.ReadAllBytes(txtInputA5.Text));
                    
                    byte[] BanMa = A51.BitArr2ByteArr(A51.MaHoa());
                    try
                    {
                        txtOutputA5.Text = DES.hex2binary((BitConverter.ToString(BanMa)).Replace("-", ""));
                        MessageBox.Show("Thực hiện thành công");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    if (txtInputA5.Text == "") MessageBox.Show("Chưa chọn file !!");
                    
                    if (txtKhoaX.TextLength != 19 || txtKhoaY.TextLength != 22 || txtKhoaZ.TextLength != 23) 
                        MessageBox.Show("Khóa chưa đúng","Thông báo");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDecryptA5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInputA5.Text != ""  & txtKhoaX.TextLength == 19 & txtKhoaY.TextLength == 22 & txtKhoaZ.TextLength == 23)
                {
                    
                    A51.X = A51.string2bool(txtKhoaX.Text);
                    A51.Y = A51.string2bool(txtKhoaY.Text);
                    A51.Z = A51.string2bool(txtKhoaZ.Text);
                    A51.banro = new BitArray(File.ReadAllBytes(txtInputA5.Text));
                    
                    byte[] BanMa = A51.BitArr2ByteArr(A51.MaHoa());
                    try
                    {
                        //Encoding enc8 = Encoding.UTF8;
                        
                        txtOutputA5.Text = DES.hex2binary((BitConverter.ToString(BanMa)).Replace("-", ""));
                        //txtOutputA5.Text = enc8.GetString(BanMa);
                        MessageBox.Show("Thực hiện thành công");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    if (txtInputA5.Text == "") MessageBox.Show("Chưa chọn file !!");
                    
                    if (txtKhoaX.TextLength != 19 || txtKhoaY.TextLength != 22 || txtKhoaZ.TextLength != 23) 
                        MessageBox.Show("Khóa chưa đúng","Thông báo");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
