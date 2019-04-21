using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowingSysPars
{
    public partial class Form1 : Form
    {
        private ulong ram;
        private ulong availExtendedVirtual;
        private ulong availPageFile;
        private ulong availPhys;
        private ulong availVirtual;

        public Form1(ulong ram, ulong availExtendedVirtual, 
            ulong availPageFile, 
            ulong availPhys, ulong availVirtual,
            uint memoryLoad, ulong totalPageFile, 
            ulong totalPhys, ulong totalVirtual, uint dwLength)
        {
            this.ram = ram;
            this.availExtendedVirtual = availExtendedVirtual;
            this.availPageFile = availPageFile;
            this.availPhys = availPhys;
            this.availVirtual = availVirtual;
            InitializeComponent();
            label1.Text = "Randome Access Memory " + ram / 1024 / 1024;
            label2.Text = "Файл подкачки " + availExtendedVirtual;
            label3.Text = "Свободных байт в файле подкачки " + availPageFile;
            label4.Text = "Свободная физическая память, байт " + availPhys;
            label5.Text = "Свободная виртуальная память " + availVirtual;
            label6.Text = "Процент использования памяти " + memoryLoad;
            label7.Text = "Размер файла подкачки, байт " + totalPageFile;
            label8.Text = "Физическая память, байт  " + totalPhys;
            label9.Text = "Виртуальная память, используемая процессом " + totalVirtual;
            label10.Text = "Размер структуры " + dwLength ;

            /*
            DWORD dwLength;          Размер структуры
            DWORD dwMemoryLoad;      Процент использования памяти
            DWORD dwTotalPhys;       Физическая память, байт
            DWORD dwAvailPhys;       Свободная физическая память, байт
            DWORD dwTotalPageFile;   Размер файла подкачки, байт
            DWORD dwAvailPageFile;   Свободных байт в файле подкачки
            DWORD dwTotalVirtual;    Виртуальная память, используемая процессом 
            DWORD dwAvailVirtual;    Свободная виртуальная память
            */


        }
    }
}
