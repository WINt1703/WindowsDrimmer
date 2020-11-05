using WindowsDrimmer.Base;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace WindowsDrimmer.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        #region Fields
        private Process _selectProcess;
        private ICollection<Process> _processesSource;
        private string _pName,
                       _pId,
                       _hWindow;
        private RelayCommand _changeColor,
                             _updateProcesses;
        #endregion

        #region Properties

        public RelayCommand ChangeColor
        {
            get
            {
                return _changeColor ?? (_changeColor = new RelayCommand(obj =>
                {
                    var config = new Config.Config();
                    config.ShowDialog();
                },
                obj=> 
                {
                    return _selectProcess != null && _selectProcess.MainWindowHandle != IntPtr.Zero;
                }));
            }
        }

        public RelayCommand UpdateProcesses
        {
            get
            {
                return _updateProcesses ?? (_updateProcesses = new RelayCommand(obj =>
                {
                    ProcessesSource = getProcessApp(Process.GetProcesses());
                },
                obj =>
                {
                    return _processesSource != null;
                }));
            }
        }

        public Process SelectProcess
        {
            get
            {
                if (_selectProcess != null)
                    setInfoProcess(_selectProcess);
                
                return null;
            } 
            set => OnPropertyChanged(ref _selectProcess, value);
                    
        }

        public string PName
        {
            get => _pName;
            set => OnPropertyChanged(ref _pName, value);
        }
        
        public string PId
        {
            get => _pId;
            set => OnPropertyChanged(ref _pId, value);
        }

        public string HWindow
        {
            get => _hWindow;
            set => OnPropertyChanged(ref _hWindow, value);
        }

        public ICollection<Process> ProcessesSource
        {
            get => _processesSource;
            set => OnPropertyChanged(ref _processesSource, value);
        }
        #endregion

        #region Methods
     
        private Process setInfoProcess(Process process)
        {
            if (process.MainWindowHandle == IntPtr.Zero)
            {
                ProcessesSource = getProcessApp(Process.GetProcesses());
                return null;
            }

            PId = $"Process Id : {process.Id}";
            PName = $"Process Name : {process.ProcessName}";
            HWindow = $"Handle window : {process.MainWindowHandle}";

            return null;
        }

        private ICollection<Process> getProcessApp(ICollection<Process> rawProcesses)
        {
            ICollection<Process> processes = new List<Process>();

            foreach(var item in rawProcesses)
            {
                if (item.MainWindowHandle != IntPtr.Zero) processes.Add(item);
            }

            return processes;
        }
        #endregion

        public MainViewModel()
        {
            ProcessesSource = getProcessApp(Process.GetProcesses());
            PId = PName = HWindow = " ";
        }
    }
}
