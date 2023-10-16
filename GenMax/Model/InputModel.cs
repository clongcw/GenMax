using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using GenMax.Common;
using GenMax.Database.EntityModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace GenMax.Model
{
    public class InputModel : ObservableObject
    {
        private int _groupId = 0;

        public int GroupId
        {
            get { return _groupId; }
            set
            {
                SetProperty(ref _groupId, value);
            }
        }

        private Protocol _protocolInput;

        public Protocol ProtocolInput
        {
            get { return _protocolInput; }
            set
            {
                SetProperty(ref _protocolInput, value);
            }
        }

        private Step _currentStep;

        public Step CurrentStep
        {
            get { return _currentStep; }
            set
            {
                SetProperty(ref _currentStep, value);
            }
        }

        private int _smpCount = 4;

        public int SmpCount
        {
            get { return _smpCount; }
            set
            {
                SetProperty(ref _smpCount, value);
            }
        }

        private string _barcode = "";

        public string Barcode
        {
            get { return _barcode; }
            set
            {
                SetProperty(ref _barcode, value);
            }
        }

        private List<Sample> _sampleList = new List<Sample>();
        private string _experimentName;

        public List<Sample> SampleList
        {
            get { return _sampleList; }
            set
            {
                SetProperty(ref _sampleList, value);
            }
        }

        public string ExperimentName
        {
            get => _experimentName;
            set
            {
                SetProperty(ref _experimentName, value);
                var experimentDir = ExperimentName == null ?
                   CommonSetting.PcrImageDir + @"\" + DateTime.Now.ToString("yyyyMMdd_HHmmss")
                    : CommonSetting.PcrImageDir + @"\" + ExperimentName;
                if (ExperimentName == null)
                    ExperimentName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                if (Directory.Exists(experimentDir))
                {
                    WeakReferenceMessenger.Default.Send("该实验名称已存在，请重新命名！", Common.Token.MessageBox);
                }
            }
        }

        public InputModel(int ch)
        {
            GroupId = ch;
            SampleList.Clear();
            for (int i = 0; i < DeviceConstant.SampleCountPerChannel; i++)
            {
                SampleList.Add(new Sample() { Channel = GroupId, Id = i + 1, SubId = i, IsValid = true });
            }
        }

    }
}
