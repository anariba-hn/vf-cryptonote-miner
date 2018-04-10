using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetBrowser;
using DotNetBrowser.WinForms;


namespace VFCNMiner
{
    public partial class Main : Form
    {
        bool platform64bit;

        string simplewalletPath;
        string cpuminerPath;
        string claymoreminerPath;
        string ccminerPath;

        string walletPath;
        string address;

        List<Process> minerProcesses = new List<Process>();
        List<Process> GPUminerProcesses = new List<Process>();

        string miningBtnStart;
        string miningBtnStop;

        string GPUminingBtnStart;
        string GPUminingBtnStop;

        int generadorclick = 0;
        int version = 3;
        int activo = 0;

        SynchronizationContext _syncContext;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public Main()
        {
            InitializeComponent();
            _syncContext = SynchronizationContext.Current;

            cuda.SelectedIndex = 0;

            miningBtnStart = buttonStartCPUMining.Text;
            miningBtnStop = "Stop CPU Mining";
            GPUminingBtnStart = buttonStartGPUMining.Text;
            GPUminingBtnStop = "Stop GPU Mining";

            platform64bit = ArchitectureCheck.Is64Bit();

            string platformString = platform64bit ? "64bit" : "32bit"; //if 64 bit

            simplewalletPath = AppDomain.CurrentDomain.BaseDirectory + @"binaries\simplewallet\" + platformString + @"\simplewallet.exe"; //paths
            //verificar el tipo de sistema 32 o 64 y usarlo
            cpuminerPath = AppDomain.CurrentDomain.BaseDirectory + @"binaries\cpuminer\" + platformString + @"\xmrig.exe";
            
            claymoreminerPath = AppDomain.CurrentDomain.BaseDirectory + @"binaries\XMRAMD\" + platformString + @"\xmrig-amd.exe"; //AMD

            //verificar si es cuda8 o cuda9

            if (cuda.SelectedIndex == 0)
            {
                ccminerPath = AppDomain.CurrentDomain.BaseDirectory + @"binaries\XMRNvidia\" + platformString + @"\xmrig-nvidia-2.5.2-cuda8-win64" + @"\xmrig-nvidia.exe"; //NVIDIA
            }else
            {
                ccminerPath = AppDomain.CurrentDomain.BaseDirectory + @"binaries\XMRNvidia\" + platformString + @"\xmrig-nvidia-2.5.2-cuda9-win64" + @"\xmrig-nvidia.exe"; //NVIDIA
            }


            walletPath = AppDomain.CurrentDomain.BaseDirectory + @"wallet.address.txt";
            

            if (!File.Exists(simplewalletPath))
            {
                MessageBox.Show("Missing " + simplewalletPath);
                Process.GetCurrentProcess().Kill();
            }
            

            if (!File.Exists(cpuminerPath))
            {
                MessageBox.Show("Missing " + cpuminerPath);
                Process.GetCurrentProcess().Kill();
            }
            
            if (!File.Exists(claymoreminerPath))
            {
                MessageBox.Show("Missing " + claymoreminerPath);
                Process.GetCurrentProcess().Kill();
            }
           
            if (!File.Exists(ccminerPath))
            {
                MessageBox.Show("Missing " + ccminerPath);
                Process.GetCurrentProcess().Kill();
            }
           

            if (!File.Exists(walletPath))
            {
                MessageBox.Show("Generating new wallet with the password: x");
                GenerateWallet();
            }
            else
            {
                ReadWalletAddress();
            }

            var coresAvailable = Environment.ProcessorCount;

            for (var i = 0; i < coresAvailable; i++)
            {
                string text = (i + 1).ToString();
                if (i+1 == coresAvailable) text += " (max)";
                comboBoxCores.Items.Add(text);
            }

            var coresConfig = INI.Value("cores");
            int coresInt = comboBoxCores.Items.Count - 1;
            if (coresConfig != "")
            {
                int coresParsed;
                var parsed = int.TryParse(coresConfig, out coresParsed);
                if (parsed) coresInt = coresParsed - 1;
                if (coresInt+1 > coresAvailable) coresInt = coresAvailable - 1;

            }
            comboBoxCores.SelectedIndex = coresInt;
            comboBoxBrand.SelectedIndex = 1;

            var poolHost = INI.Value("pool_host");
            if (poolHost != ""){
                textBoxPoolHost.Text = poolHost;
            }
            var poolPort = INI.Value("pool_port");
            if (poolPort != "")
            {
                textBoxPoolPort.Text = poolPort;
            }

            Log("Thank you for using Superior Coin Miner, created by zone117x, modified by Jefrin Aguilar --- Superior-Coin.com");

            Application.ApplicationExit += (s, e) => killMiners();

            activo = 1;
        }

        void generardenuevo()
        {

            walletPath = AppDomain.CurrentDomain.BaseDirectory + @"wallet.address.txt";
             

            if (!File.Exists(simplewalletPath))
            {
                MessageBox.Show("Missing " + simplewalletPath);
                Process.GetCurrentProcess().Kill();
            }


            if (!File.Exists(cpuminerPath))
            {
                MessageBox.Show("Missing " + cpuminerPath);
                Process.GetCurrentProcess().Kill();
            }

            if (!File.Exists(claymoreminerPath))
            {
                MessageBox.Show("Missing " + claymoreminerPath);
                Process.GetCurrentProcess().Kill();
            }

            if (!File.Exists(ccminerPath))
            {
                MessageBox.Show("Missing " + ccminerPath);
                Process.GetCurrentProcess().Kill();
            }


            if (!File.Exists(walletPath))
            {
                MessageBox.Show("Generating new wallet with the password: x");
                GenerateWallet();
            }
            else
            {
                ReadWalletAddress();
            }

            var coresAvailable = Environment.ProcessorCount;

            for (var i = 0; i < coresAvailable; i++)
            {
                string text = (i + 1).ToString();
                if (i + 1 == coresAvailable) text += " (max)";
                comboBoxCores.Items.Add(text);
            }

            var coresConfig = INI.Value("cores");
            int coresInt = comboBoxCores.Items.Count - 1;
            if (coresConfig != "")
            {
                int coresParsed;
                var parsed = int.TryParse(coresConfig, out coresParsed);
                if (parsed) coresInt = coresParsed - 1;
                if (coresInt + 1 > coresAvailable) coresInt = coresAvailable - 1;

            }
            comboBoxCores.SelectedIndex = coresInt;
            comboBoxBrand.SelectedIndex = 1;

            var poolHost = INI.Value("pool_host");
            if (poolHost != "")
            {
                textBoxPoolHost.Text = poolHost;
            }
            var poolPort = INI.Value("pool_port");
            if (poolPort != "")
            {
                textBoxPoolPort.Text = poolPort;
            }

            Log("Thank you for using Superior Coin Miner, created by zone117x, modified by Jefrin Aguilar --- Superior-Coin.com");

            Application.ApplicationExit += (s, e) => killMiners();
        }

        void ReadWalletAddress()
        {
                address = File.ReadAllText(walletPath);
                textBoxAddress.Text = address;

                _syncContext.Post(_ =>
                {
                    textBoxAddress.Text = address;
                }, null);
           
            
            
        }

        void GenerateWallet()
        {

            
            var args = new [] { 
                "--generate-new-wallet=\"" + AppDomain.CurrentDomain.BaseDirectory + "wallet\"", 
                "--password=x"
            };

            Console.WriteLine(String.Join(" ", args));

            ProcessStartInfo psi = new ProcessStartInfo(simplewalletPath, String.Join(" ", args))
            {
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            Process process = Process.Start(psi);
            process.EnableRaisingEvents = true;

            process.Exited += (s, e) =>
            {
                if (!File.Exists(walletPath))
                    MessageBox.Show("Failed to generate new wallet");
                else 
                    ReadWalletAddress();
            };
        }

        void startMiningProcesses()
        {
    // Remove any leading or ending spaces - typical occurs when using copy and paste and will result in the mining process failing to start.
            textBoxPoolHost.Text = textBoxPoolHost.Text.Trim();
            textBoxPoolPort.Text = textBoxPoolPort.Text.Trim();

            if (version == 1)
            {
                var args = new ArrayList(new[] {
                "-a cryptonight",
                "-o stratum+tcp://" + textBoxPoolHost.Text + ':' + textBoxPoolPort.Text,
                "-u " + address,
                "-p x",
                "--donate-level 1",
                "-k",
                "--variant 0"

            });
                var cores = comboBoxCores.SelectedIndex + 1;
                if (cores != comboBoxCores.Items.Count)
                {
                    args.Add("-t " + cores);
                }

                startMiningProcess((string[])args.ToArray(typeof(string)), cores);
            }

            if (version == 2)
            {
                var args = new ArrayList(new[] {
                "-a cryptonight",
                "-o stratum+tcp://" + textBoxPoolHost.Text + ':' + textBoxPoolPort.Text,
                "-u " + address,
                "-p x",
                "--donate-level 1",
                "-k",
                "--variant 1"

            });
                var cores = comboBoxCores.SelectedIndex + 1;
                if (cores != comboBoxCores.Items.Count)
                {
                    args.Add("-t " + cores);
                }

                startMiningProcess((string[])args.ToArray(typeof(string)), cores);
            }

            if (version == 3)
            {
                var args = new ArrayList(new[] {
                "-a cryptonight",
                "-o stratum+tcp://" + textBoxPoolHost.Text + ':' + textBoxPoolPort.Text,
                "-u " + address,
                "-p x",
                "--donate-level 1",
                "-k"

            });
                var cores = comboBoxCores.SelectedIndex + 1;
                if (cores != comboBoxCores.Items.Count)
                {
                    args.Add("-t " + cores);
                }

                startMiningProcess((string[])args.ToArray(typeof(string)), cores);
            }




        }

        void startMiningProcess(string[] args, int cores)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(cpuminerPath, String.Join(" ", args));

            

            Process process = new Process();
            minerProcesses.Add(process);
            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => {
                Log("CPU Miner died");
                minerProcesses.Remove(process);
                if (minerProcesses.Count == 0)
                {
                    _syncContext.Post(_ => {
                        if (buttonStartCPUMining.Text != miningBtnStart)
                            buttonStartCPUMining.PerformClick();
                    }, null);
                }
            };

            process.Start();
            
            IntPtr ptr = IntPtr.Zero;
            while ((ptr = process.MainWindowHandle) == IntPtr.Zero || process.HasExited) ;

            SetParent(process.MainWindowHandle, panel1.Handle);
            MoveWindow(process.MainWindowHandle, 0, 0, panel1.Width, panel1.Height - 20, true);

            Log("CPU Miner started on " + cores + " cores");
        }


        void Log(string text)
        {
            if (text == null) return;
            _syncContext.Post(_ => {
                textBoxLog.AppendText(Environment.NewLine + text);
                textBoxLog.SelectionStart = textBoxLog.Text.Length;
                textBoxLog.ScrollToCaret();
            }, null);
        }

        void SaveINI()
        {
            try
            {
                INI.Config(
                                "pool_host", textBoxPoolHost.Text,
                                "pool_port", textBoxPoolPort.Text,
                                "cores", (comboBoxCores.SelectedIndex + 1).ToString()
                            );
            }
            catch
            {

            }
            
        }
        
        void killMiners()
        {
            foreach (Process process in minerProcesses)
            {
                if (!process.HasExited)
                    process.Kill();
            }
            minerProcesses.Clear();
        }

        void killGPUMiners()
        {
            foreach (Process process in GPUminerProcesses)
            {
                if (!process.HasExited)
                    process.Kill();
            }
            GPUminerProcesses.Clear();
        }

        private void buttonStartMining_Click(object sender, EventArgs e)
        {
            

            if (buttonStartCPUMining.Text == miningBtnStart)
            {
                SaveINI();
                tabControl1.SelectTab(0);
                buttonStartCPUMining.Text = miningBtnStop;
                //btnYourStats.Enabled = false;
                textBoxPoolHost.Enabled = textBoxPoolPort.Enabled = comboBoxCores.Enabled = false;
                ReadWalletAddress();
                startMiningProcesses();
                
            }
            else
            {
                //btnYourStats.Enabled = true;
                tabControl1.SelectTab(0);
                buttonStartCPUMining.Text = miningBtnStart;
                textBoxPoolHost.Enabled = textBoxPoolPort.Enabled = comboBoxCores.Enabled = true;
                killMiners();
            }
        }


        //Here comes major code changes

        void startGPUMiningProcesses()
        {
            // Remove any leading or ending spaces - typical occurs when using copy and paste and will result in the mining process failing to start.
            textBoxPoolHost.Text = textBoxPoolHost.Text.Trim();
            textBoxPoolPort2.Text = textBoxPoolPort2.Text.Trim();


            if (comboBoxBrand.SelectedIndex == 0)
            {
                if (version==1)
                {
                    var args = new ArrayList(new[] {
                "-o stratum+tcp://" + textBoxPoolHost.Text + ':' + textBoxPoolPort2.Text,
                "-u " + address,
                "-p x",
                "--donate-level 1",
                "-k",
                "--variant 0"
            });

                    startGPUMiningProcess((string[])args.ToArray(typeof(string)));
                }

                if (version == 2)
                {
                    var args = new ArrayList(new[] {
                "-o stratum+tcp://" + textBoxPoolHost.Text + ':' + textBoxPoolPort2.Text,
                "-u " + address,
                "-p x",
                "--donate-level 1",
                "-k",
                "--variant 1"
            });

                    startGPUMiningProcess((string[])args.ToArray(typeof(string)));
                }

                if (version == 3)
                {
                    var args = new ArrayList(new[] {
                "-o stratum+tcp://" + textBoxPoolHost.Text + ':' + textBoxPoolPort2.Text,
                "-u " + address,
                "-p x",
                "--donate-level 1",
                "-k",
            });

                    startGPUMiningProcess((string[])args.ToArray(typeof(string)));
                }


            }
            else
            {
                if (version==1)
                {
                    var args = new ArrayList(new[] {
                "-o " + textBoxPoolHost.Text + ':' + textBoxPoolPort2.Text,
                "-u " + address,
                "-p x",
                "--donate-level 1",
                "-k",
                "--variant 0"

                

            });

                    startGPUMiningProcess((string[])args.ToArray(typeof(string)));

                }

                if (version == 2)
                {
                    var args = new ArrayList(new[] {
                "-o stratum+tcp://" + textBoxPoolHost.Text + ':' + textBoxPoolPort2.Text,
                "-u " + address,
                "-p x",
                "--donate-level 1",
                "-k",
                "--variant 1"

            });

                    startGPUMiningProcess((string[])args.ToArray(typeof(string)));

                }


                if (version == 3)
                {
                    var args = new ArrayList(new[] {
                "-o stratum+tcp://" + textBoxPoolHost.Text + ':' + textBoxPoolPort2.Text,
                "-u " + address,
                "-p x",
                "--donate-level 1",
                "-k"

            });

                    startGPUMiningProcess((string[])args.ToArray(typeof(string)));

                }


            }
                 

        }

        void startGPUMiningProcess(string[] args)
        {
            ProcessStartInfo startInfo = null;

            if (comboBoxBrand.SelectedIndex == 0)
            {
                startInfo = new ProcessStartInfo(claymoreminerPath, String.Join(" ", args));
            } else
            {
                startInfo = new ProcessStartInfo(ccminerPath, String.Join(" ", args));
            }
            

            Process process = new Process();
            GPUminerProcesses.Add(process);
            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => {
                Log("GPU Miner died");
                GPUminerProcesses.Remove(process);
                if (GPUminerProcesses.Count == 0)
                {
                    _syncContext.Post(_ => {
                        if (buttonStartGPUMining.Text != GPUminingBtnStart)
                            buttonStartGPUMining.PerformClick();
                    }, null);
                }
            };

            process.Start();

            IntPtr ptr = IntPtr.Zero;
            while ((ptr = process.MainWindowHandle) == IntPtr.Zero || process.HasExited) ;

            SetParent(process.MainWindowHandle, panel2.Handle);
            MoveWindow(process.MainWindowHandle, 0, 0, panel2.Width, panel2.Height - 20, true);

            Log("GPU Miner started");
        }

        private void buttonStartGPUMining_Click(object sender, EventArgs e)
        {
            if (buttonStartGPUMining.Text == GPUminingBtnStart)
            {
                SaveINI();
                tabControl1.SelectTab(1);
                buttonStartGPUMining.Text = GPUminingBtnStop;
                textBoxPoolHost.Enabled = textBoxPoolPort2.Enabled = comboBoxBrand.Enabled = false;
                startGPUMiningProcesses();
                
                    cuda.Enabled = false;
                
            }
            else
            {
                tabControl1.SelectTab(1);
                buttonStartGPUMining.Text = GPUminingBtnStart;
                textBoxPoolHost.Enabled = textBoxPoolPort2.Enabled = comboBoxBrand.Enabled = true;
                killGPUMiners();

                if (comboBoxBrand.SelectedIndex == 1)
                {
                    cuda.Enabled = true;
                }
                else
                {
                    cuda.Enabled = false;
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

            cuda.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter fileWrite = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"temp.txt"))
                {
                    fileWrite.Write(textBoxAddress.Text.Trim());

                }

                //aqui se renombrea el archivo temporal 

                File.Delete(walletPath);
                File.Move((AppDomain.CurrentDomain.BaseDirectory + @"temp.txt"), walletPath);
                
                generardenuevo();
                
            }
            catch
            {

            }
        }

        private void webgenerador_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnYourStats_Click(object sender, EventArgs e)
        {
            frmStats frm = new frmStats();
            frm.ShowDialog();
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAddress_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAddress.SelectAll();
        }

        private void comboBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBrand.SelectedIndex == 1)
            {
                cuda.Enabled = true;
            }
            else
            {
                cuda.Enabled = false;
            }
        }

        private void textBoxPoolHost_Click(object sender, EventArgs e)
        {
          textBoxPoolHost.SelectAll();
        }

        private void textBoxPoolPort_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxPoolPort.SelectAll();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                version = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                version = 2;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                version = 3;
            }
        }

        private void cuda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activo==1)
            {
                _syncContext = SynchronizationContext.Current;

                miningBtnStart = buttonStartCPUMining.Text;
                miningBtnStop = "Stop CPU Mining";
                GPUminingBtnStart = buttonStartGPUMining.Text;
                GPUminingBtnStop = "Stop GPU Mining";

                platform64bit = ArchitectureCheck.Is64Bit();

                string platformString = platform64bit ? "64bit" : "32bit"; //if 64 bit

                simplewalletPath = AppDomain.CurrentDomain.BaseDirectory + @"binaries\simplewallet\" + platformString + @"\simplewallet.exe"; //paths
                                                                                                                                              //verificar el tipo de sistema 32 o 64 y usarlo
                cpuminerPath = AppDomain.CurrentDomain.BaseDirectory + @"binaries\cpuminer\" + platformString + @"\xmrig.exe";

                claymoreminerPath = AppDomain.CurrentDomain.BaseDirectory + @"binaries\XMRAMD\" + platformString + @"\xmrig-amd.exe"; //AMD

                //verificar si es cuda8 o cuda9

                if (cuda.SelectedIndex == 0)
                {
                    ccminerPath = AppDomain.CurrentDomain.BaseDirectory + @"binaries\XMRNvidia\" + platformString + @"\xmrig-nvidia-2.5.2-cuda8-win64" + @"\xmrig-nvidia.exe"; //NVIDIA
                }
                if (cuda.SelectedIndex == 1)
                {
                    ccminerPath = AppDomain.CurrentDomain.BaseDirectory + @"binaries\XMRNvidia\" + platformString + @"\xmrig-nvidia-2.5.2-cuda9-win64" + @"\xmrig-nvidia.exe"; //NVIDIA
                }


                walletPath = AppDomain.CurrentDomain.BaseDirectory + @"wallet.address.txt";


                if (!File.Exists(simplewalletPath))
                {
                    MessageBox.Show("Missing " + simplewalletPath);
                    Process.GetCurrentProcess().Kill();
                }


                if (!File.Exists(cpuminerPath))
                {
                    MessageBox.Show("Missing " + cpuminerPath);
                    Process.GetCurrentProcess().Kill();
                }

                if (!File.Exists(claymoreminerPath))
                {
                    MessageBox.Show("Missing " + claymoreminerPath);
                    Process.GetCurrentProcess().Kill();
                }

                if (!File.Exists(ccminerPath))
                {
                    MessageBox.Show("Missing " + ccminerPath);
                    Process.GetCurrentProcess().Kill();
                }


                if (!File.Exists(walletPath))
                {
                    MessageBox.Show("Generating new wallet with the password: x");
                    GenerateWallet();
                }
                else
                {
                    ReadWalletAddress();
                }

                var coresAvailable = Environment.ProcessorCount;

                for (var i = 0; i < coresAvailable; i++)
                {
                    string text = (i + 1).ToString();
                    if (i + 1 == coresAvailable) text += " (max)";
                    comboBoxCores.Items.Add(text);
                }

                var coresConfig = INI.Value("cores");
                int coresInt = comboBoxCores.Items.Count - 1;
                if (coresConfig != "")
                {
                    int coresParsed;
                    var parsed = int.TryParse(coresConfig, out coresParsed);
                    if (parsed) coresInt = coresParsed - 1;
                    if (coresInt + 1 > coresAvailable) coresInt = coresAvailable - 1;

                }
                comboBoxCores.SelectedIndex = coresInt;
                comboBoxBrand.SelectedIndex = 1;

                var poolHost = INI.Value("pool_host");
                if (poolHost != "")
                {
                    textBoxPoolHost.Text = poolHost;
                }
                var poolPort = INI.Value("pool_port");
                if (poolPort != "")
                {
                    textBoxPoolPort.Text = poolPort;
                }

                //Log("Thank you for using Superior Coin Miner, created by zone117x, modified by Jefrin Aguilar --- Superior-Coin.com");

            }

        }
    }
}
