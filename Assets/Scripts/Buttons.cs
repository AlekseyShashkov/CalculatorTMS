using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Calculator _calculator  = null;
    public GameObject _resultPanel = null;

    private void Start()
    {
        _calculator = _resultPanel.GetComponent<Calculator>();
    }

    private void OnMouseDown()
    {        
        string button = gameObject.name;

        switch(button) {
            case "ZeroButton":
            _calculator.ValuesInitialization(0.0);
            break;

            case "OneButton":
            _calculator.ValuesInitialization(1.0);     
            break;

            case "TwoButton":
            _calculator.ValuesInitialization(2.0);         
            break;

            case "ThreeButton":
            _calculator.ValuesInitialization(3.0);        
            break;

            case "FourButton":
            _calculator.ValuesInitialization(4.0);          
            break;

            case "FiveButton":
            _calculator.ValuesInitialization(5.0);        
            break;

            case "SixButton":
            _calculator.ValuesInitialization(6.0);        
            break;

            case "SevenButton":
            _calculator.ValuesInitialization(7.0);
            break;

            case "EightButton":
            _calculator.ValuesInitialization(8.0);
            break;

             case "NineButton":
            _calculator.ValuesInitialization(9.0);         
            break;

            case "PlusButton":
            _calculator.OperationInitialization('+');        
            break;

            case "MinusButton":
            _calculator.OperationInitialization('-');           
            break;

            case "MultiplyButton":
            _calculator.OperationInitialization('*');          
            break;

            case "DivideButton":
            _calculator.OperationInitialization('/');           
            break;

            case "EqualButton":
            _calculator.EquationResult();           
            break;

            case "ClearButton":
            _calculator.ClearImplementation();
            break;
        }
    }
}
