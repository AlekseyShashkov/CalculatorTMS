using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Calculator : MonoBehaviour
{
    private const double MaxValue = 999999999;

    private TextMeshPro _resultText;

    private double _firstValue  = 0.0;
    private double _secondValue = 0.0;
    private double _result      = 0.0;
    private char _operation     = '\0';
    private bool _isFirstValue  = true;     

    private void Start()
    {
        _resultText = GetComponent<TextMeshPro>();
        _resultText.SetText($"{0}");
    }

    public void ValuesInitialization(double value)
    {
        // Start the second value without selecting an operation 
        // (stop working with the previous result)
        bool isNewEquation = !_isFirstValue && _operation.Equals('\0');

        if(_isFirstValue) {
            int digitCount = (int)Math.Log10(_firstValue) + 1;
            bool outOfBounds = digitCount >= 9;

            if(!outOfBounds) {
            _firstValue = _firstValue * 10.0 + value;
            _resultText.SetText($"{_firstValue}");
            }
        } 
        else if(isNewEquation) {
            _isFirstValue   = true;
            _firstValue     = value;
            _resultText.SetText($"{_firstValue}");
        } 
        else {
            int digitCount = (int)Math.Log10(_secondValue) + 1;
            bool outOfBounds = digitCount >= 9;

            if(!outOfBounds) {
            _secondValue = _secondValue * 10.0 + value;
            _resultText.SetText($"{_secondValue}"); 
            }
        }
    }

    public void OperationInitialization(char value)
    {
        if(_isFirstValue) {
            _isFirstValue = false;     
        }

        _operation = value;
        _resultText.SetText($"{value}");    
    }

    public void EquationResult()
    {
        switch(_operation) {
            case '+':
            _result = _firstValue + _secondValue;           
            InitializationAfterOperation();
            break;

            case '-':
            _result = _firstValue - _secondValue;           
            InitializationAfterOperation();
            break;

            case '*':
            _result = _firstValue * _secondValue;           
            InitializationAfterOperation();
            break;

            case '/':
            _result = _firstValue / _secondValue;           
            InitializationAfterOperation();
            break;
        }
    }
    
    private void InitializationAfterOperation()
    {
        int digitCount = (int)Math.Log10(_result) + 1;
        bool outOfBounds = digitCount > 9;
        
        if(outOfBounds) {
            _result = MaxValue;
        }

        _resultText.SetText($"{_result}");
            
        _firstValue     = _result;
        _secondValue    = 0.0;
        _operation      = '\0';
    }

    public void ClearImplementation()
    {
        _firstValue     = 0.0;
        _secondValue    = 0.0;
        _operation      = '\0';

        _resultText.SetText($"{0}");
    }
}
