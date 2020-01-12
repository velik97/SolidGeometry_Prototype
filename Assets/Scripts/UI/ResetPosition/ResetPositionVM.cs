using UI.MVVM;
using UnityEngine.SceneManagement;
using Util.EventBusSystem;

namespace UI.ResetPosition
{
    public class ResetPositionVM : ViewModel
    {
        public void ResetPosition()
        {
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            EventBus.TriggerEvent<IResetPositionHandler>(h => h.HandleResetPosition());
        }
    }
}