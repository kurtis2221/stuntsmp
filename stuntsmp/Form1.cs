using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace stuntsmp
{
    public partial class Form1 : Form
    {
        const string TITLE = "Stunts/4D Sports Driving Multiplayer Client 1.0 Alpha";
        const string FILE_CFG = "stuntsmp.txt";
        const int PORT = 7777;
        //Client send
        const int BUFFER_SEND_SIZE = 0x80;
        const int THD_SLEEP = 40; //25 FPS
        //Client recieve
        const int BUFFER_SIZE = BUFFER_SEND_SIZE + 1;
        //Max players -1
        const int MAX_PLAYERS = 2;
        //Player, network car
        static uint BASE_ADDR = 0x0;
        static uint[] PLAYER_ADDR = 
        {
            0x36A24
        };
        static uint[] NET_ADDR =
        {
            0x36ADA
        };
        static int[] DATA_LEN =
        {
            0x80
        };
        //
        StreamReader sr;
        StreamWriter sw;
        //
        TcpClient client;
        Socket sock;
        Thread thd, thd2;
        MemoryEdit.Memory mem;
        Process game;

        public Form1()
        {
            InitializeComponent();
            Text = TITLE;
            if (File.Exists(FILE_CFG))
            {
                sr = new StreamReader(FILE_CFG);
                tb_base.Text = sr.ReadLine();
                tb_exe.Text = sr.ReadLine();
                tb_exe_par.Text = sr.ReadLine();
                tb_ip.Text = sr.ReadLine();
                sr.Close();
            }
            if (tb_base.Text.Length == 0)
            {
                //DOSBox 0.74-3 address
                tb_base.Text = "01D3C370";
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (game != null && !game.HasExited)
                game.Kill();
            Environment.Exit(0);
            base.OnClosed(e);
        }

        void bt_connect_Click(object sender, EventArgs e)
        {
            if (tb_ip.Text.Length == 0)
            {
                MessageBox.Show("IP address is empty!", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tb_exe.Text.Length == 0)
            {
                MessageBox.Show("DOSBox path is empty!", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tb_exe_par.Text.Length == 0)
            {
                MessageBox.Show("Stunts path is empty!", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tb_base.Text.Length == 0)
            {
                MessageBox.Show("Base address is empty!", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(tb_exe.Text))
            {
                MessageBox.Show("Game not found! (" + tb_exe.Text + ")",
                    Form1.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bt_connect.Enabled = false;
            tb_ip.Enabled = false;
            try
            {
                client = new TcpClient(tb_ip.Text, PORT);
                sw = new StreamWriter(FILE_CFG, false, Encoding.Default);
                sw.WriteLine(tb_base.Text);
                sw.WriteLine(tb_exe.Text);
                sw.WriteLine(tb_exe_par.Text);
                sw.WriteLine(tb_ip.Text);
                sw.Close();
                BASE_ADDR = Convert.ToUInt32(tb_base.Text, 16);
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = tb_exe.Text;
                proc.Arguments = tb_exe_par.Text;
                proc.UseShellExecute = true;
                game = Process.Start(proc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + " - " + ex.Message, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                bt_connect.Enabled = true;
                tb_ip.Enabled = true;
                return;
            }
            mem = new MemoryEdit.Memory(game, 0x001F0FFF);
            sock = client.Client;
            thd = new Thread(new ThreadStart(NetRec));
            thd.Start();
            thd2 = new Thread(new ThreadStart(NetSend));
            thd2.Start();
        }

        void NetRec()
        {
            try
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                byte[] data = new byte[BUFFER_SEND_SIZE];
                uint tmp;
                int src_idx;
                int len;
                uint ptr;
                while (true)
                {
                    for (int idx = 0; idx < BUFFER_SIZE; idx += sock.Receive(buffer, idx, BUFFER_SIZE - idx, SocketFlags.None)) ;
                    src_idx = 1;
                    ptr = BitConverter.ToUInt32(mem.ReadByte(BASE_ADDR, 4), 0);
                    for (int i = 0; i < NET_ADDR.Length; i++)
                    {
                        len = DATA_LEN[i];
                        Array.Copy(buffer, src_idx, data, 0, len);
                        tmp = ptr + NET_ADDR[i];
                        mem.WriteByte(tmp, data, len);
                        src_idx += len;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Source + " - " + e.Message, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (game != null && !game.HasExited)
                    game.Kill();
                Environment.Exit(0);
            }
        }

        void NetSend()
        {
            try
            {
                byte[] buffer = new byte[BUFFER_SEND_SIZE];
                byte[] data;
                uint tmp;
                int trg_idx;
                int len;
                uint ptr;
                while (true)
                {
                    Thread.Sleep(THD_SLEEP);
                    trg_idx = 0;
                    ptr = BitConverter.ToUInt32(mem.ReadByte(BASE_ADDR, 4), 0);
                    for (int i = 0; i < PLAYER_ADDR.Length; i++)
                    {
                        len = DATA_LEN[i];
                        tmp = ptr + PLAYER_ADDR[i];
                        data = mem.ReadByte(tmp, len);
                        Array.Copy(data, 0, buffer, trg_idx, len);
                        trg_idx += len;
                    }
                    sock.Send(buffer);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Source + " - " + e.Message, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (game != null && !game.HasExited)
                    game.Kill();
                Environment.Exit(0);
            }
        }

        private void bt_exe_Click(object sender, EventArgs e)
        {
            ofd.Filter = "EXE files|*.exe|BAT files|*.bat|All files|*.*";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            tb_exe.Text = ofd.FileName;
        }

        private void bt_exe_par_Click(object sender, EventArgs e)
        {
            ofd.Filter = "COM files|*.com|EXE files|*.exe|BAT files|*.bat|All files|*.*";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            tb_exe_par.Text = ofd.FileName;
        }
    }
}
