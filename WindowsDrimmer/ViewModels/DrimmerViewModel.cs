using WindowsDimmer.Base;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using System.Linq;

namespace WindowsDimmer.ViewModels
{
    internal class DrimmerViewModel : ViewModelBase
    {
        #region Fields
        private Process _selectProcess;
        private ICollection<Process> _processesSourceCommand;
        private string _pName,
                       _pId,
                       _hWindow;
        private RelayCommand _changeColor,
                             _updateProcesses;
        #endregion

        #region Properties

        public RelayCommand ChangeColorCommamd
        {
            get
            {
                return _changeColor ?? (_changeColor = new RelayCommand(obj =>
                {
                    var mainWindow = ServiceManager.GetService<MainViewModel>();
                    mainWindow.SelectedView = ServiceManager.GetService<ConfigViewModel>();
                },
                obj=> 
                {
                    return _selectProcess != null && _selectProcess.MainWindowHandle != IntPtr.Zero;
                }));
            }
        }

        public RelayCommand UpdateProcessesCommamd
        {
            get
            {
                return _updateProcesses ?? (_updateProcesses = new RelayCommand(obj =>
                {
                    ProcessesSource = getProcessesApp(Process.GetProcesses());
                },
                obj =>
                {
                    return _processesSourceCommand != null;
                }));
            }
        }

        public Process SelectProcess
        {
            get
            {
                if (_selectProcess != null)
                    setInfoProcess(_selectProcess);
                
                return _selectProcess;
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
            get => _processesSourceCommand;
            set => OnPropertyChanged(ref _processesSourceCommand, value);
        }
        #endregion

        #region Methods
     
        private Process setInfoProcess(Process process)
        {
            if (process.MainWindowHandle == IntPtr.Zero)
            {
                ProcessesSource = getProcessesApp(Process.GetProcesses());
                return null;
            }

            PId = $"Process Id : {process.Id}";
            PName = $"Process Name : {process.ProcessName}";
            HWindow = $"Handle window : {process.MainWindowHandle}";

            return null;
        }

        private ICollection<Process> getProcessesApp(ICollection<Process> rawProcesses) => rawProcesses.Where(p => p.MainWindowHandle != IntPtr.Zero).ToList();        
        #endregion

        public DrimmerViewModel()
        {
            ProcessesSource = getProcessesApp(Process.GetProcesses());
            PId = PName = HWindow = null;

            ServiceManager.SetService(this);
        }
    }
}
