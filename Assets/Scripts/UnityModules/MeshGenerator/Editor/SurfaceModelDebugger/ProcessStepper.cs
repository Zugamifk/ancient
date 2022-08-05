using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator.Editor
{
    public class ProcessStepper
    {
        int _currentStepIndex = 0;
        List<IStep> _steps = new();

        public void AddStep(IStep step)
        {
            _steps.Add(step);
        }

        public void StepForward()
        {
            if (_currentStepIndex < _steps.Count)
            {
                _steps[_currentStepIndex].Do();
                _currentStepIndex++;
            }
        }

        public void StepBack()
        {
            if(_currentStepIndex > 0)
            {
                _currentStepIndex--;
                _steps[_currentStepIndex].Undo();
            }
        }
    }
}
