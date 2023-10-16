using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GenMax.Common;
using GenMax.Database.DbContext;
using GenMax.Database.EntityModel;
using GenMax.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Linq;

namespace GenMax.ViewModel
{
    public partial class SingleInputViewModel : ObservableObject
    {
        [ObservableProperty] private InputModel _inputModel;
        [ObservableProperty] private ObservableCollection<Protocol> _protocols = new ObservableCollection<Protocol>();
        [ObservableProperty] private Protocol _currentProtocol;
        [ObservableProperty] private Step _currentStep;
        [ObservableProperty] private Channels _curChannel;



        public SingleInputViewModel(Channels ch)
        {
            CurChannel = ch;
            InputModel = new InputModel((int)ch);
            InitProtocols();
        }

        private void InitProtocols()
        {
            var context = App.Current._host.Services.GetRequiredService<ProtocolDbContext>();
            context.Project.GetList();
            context.Protocols.GetList()
                .Where(x => x.Project != null).ToList()
                .ForEach(p =>
                {
                    p.Steps = p.Steps.OrderBy(s => s.Sequence).ToList();
                    Protocols.Add(p);
                });
            if (Protocols.Count > 0)
            {
                InputModel.ProtocolInput = Protocols[0];
                if (InputModel.ProtocolInput != null && InputModel.ProtocolInput.Steps.Count > 0)
                {
                    InputModel.CurrentStep = InputModel.ProtocolInput.Steps[0];
                }
            }
        }

        [RelayCommand]
        public void Input()
        {
        }

        [RelayCommand]
        public void SelectProtocol()
        {
            CurrentProtocol = InputModel.ProtocolInput;
            if (CurrentProtocol != null)
                InputModel.CurrentStep = CurrentProtocol.Steps[0];
        }
    }
}
