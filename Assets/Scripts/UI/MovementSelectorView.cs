using System;
using System.Globalization;
using Demo.MoveExecutor;
using Demo.MoveBehaviour;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Demo
{
    public class MovementSelectorView : MonoBehaviour, IMovementSelectorView
    {
        [SerializeField]
        private GameObject uiGameObject;
        [SerializeField]
        private GameObject SpikeSettings;
        [SerializeField]
        private GameObject SpiralSettings;

        [SerializeField]
        private Button executeButton;
        [SerializeField]
        private TMP_InputField executionTimeInputField;
        [SerializeField]
        private TMP_InputField spikeAmountInputField;
        [SerializeField]
        private TMP_InputField circlesAmountInputField;
        [SerializeField]
        private TMP_InputField radiusInputField;
        [SerializeField]
        private TMP_Dropdown statesDropdown;

        public void Initialize(IMovementSelectorActions actions)
        {
            SetInputFieldListener(executionTimeInputField, actions.SetExecutionTime);
            SetInputFieldListener(spikeAmountInputField, actions.SetSpikeAmount);
            SetInputFieldListener(circlesAmountInputField, actions.SetCirclesAmount);
            SetInputFieldListener(radiusInputField, actions.SetSpiralRadius);

            executeButton.onClick.RemoveAllListeners();
            executeButton.onClick.AddListener(actions.ExecuteMove);

            statesDropdown.onValueChanged.RemoveAllListeners();
            statesDropdown.onValueChanged.AddListener(
                v => OnChangeState(v, actions.SetMoveState)
            );

            foreach (var state in Enum.GetValues(typeof(MoveState)))
            {
                var option = new TMP_Dropdown.OptionData(state.ToString());
                statesDropdown.options.Add(option);
            }
        }

        
        public void UpdateView(MovementSelectorModel model)
        {
            executionTimeInputField.text = model.ExecutionTime.ToString(CultureInfo.InstalledUICulture);
            radiusInputField.text = model.Radius.ToString(CultureInfo.InstalledUICulture);
            spikeAmountInputField.text = model.Spikes.ToString();
            circlesAmountInputField.text = model.Circles.ToString();

            statesDropdown.value = (int)model.CurrentMoveState;
            statesDropdown.RefreshShownValue();

            UpdateStateUi(model.CurrentMoveState);
            uiGameObject.SetActive(model.CurrentUiState == UiState.Waiting);
        }

        private void UpdateStateUi(MoveState state)
        {
            SpiralSettings.SetActive(false);
            SpikeSettings.SetActive(false);
            switch (state)
            {
                case MoveState.Line:
                    break;
                case MoveState.Spikes:
                    SpikeSettings.SetActive(true);
                    break;
                case MoveState.Spiral:
                    SpiralSettings.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void SetInputFieldListener(TMP_InputField inputField, Action<string> listener)
        {
            inputField.onValueChanged.RemoveAllListeners();
            inputField.onValueChanged.AddListener(listener.Invoke);
        }

        private void OnChangeState(int position, Action<MoveState> setState)
        {
            setState((MoveState)position);
        }
    }
}
