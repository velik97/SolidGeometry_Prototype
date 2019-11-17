using PhaseControl;
using UI.MVVM;

namespace UI.PhaseDescription
{
    public class PhaseDescriptionVM : ViewModel
    {
        public int Number;
        public string Name;
        public string Description;

        public PhaseDescriptionVM()
        {
        }

        public PhaseDescriptionVM(int number, PhaseObject phase)
        {
            Number = number;
            Name = phase.Name;
            Description = phase.Description;
        }
    }
}